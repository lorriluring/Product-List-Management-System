using ProductListManagementSystem;

// This is the main entry point of the Product List Management System application.
// Title in dark yellow text for better visibility
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Product List Management System");
Console.WriteLine(new string('-', 40));
Console.WriteLine("Write q to quit at any time.");
Console.ResetColor();
Console.WriteLine();

// Create a manager that to stores and manages products
ProductManager manager = new();

// A method to highlight the search term in the product list when displaying search results
void WriteHighlighted(string text, string term)
{
    int start = 0;
    int index;

    // Loop through the text and find all occurrences of the search term, highlighting them in cyan color
    while ((index = text.IndexOf(term, start, StringComparison.OrdinalIgnoreCase)) >= 0)
    {
        Console.Write(text[start..index]);
        // Highlight the search term in cyan color for better visibility
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(text.Substring(index, term.Length));
        Console.ResetColor();
        start = index + term.Length;
    }
    Console.Write(text[start..]);
}

// Add products to the list dynamically until the user types "q"
while (true)
{
    Console.Write("Enter product category:");
    string category = Console.ReadLine();

    // Check if the user entered an empty string for the category, if so, prompt them to enter a valid category
    if (string.IsNullOrWhiteSpace(category))
    {
        // Error message in red text
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Category cannot be empty. Please enter a valid category.");
        Console.ResetColor();
        continue;
    }

    // Check if the user wants to quit, small q or capital q
    if (category.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }

    // Add product name to the list dynamically until the user types "q"
    string name = string.Empty;

    while (string.IsNullOrWhiteSpace(name))

    {
        // Ask for and validate the name input
        Console.Write("Enter product name:");
        name = Console.ReadLine()?.Trim() ?? string.Empty;

        // Check if the user entered an empty string for the name, if so, prompt them to enter a valid name
        if (string.IsNullOrWhiteSpace(name))
        {
            // Error message in red text
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            Console.ResetColor();
            continue;
        }
        // Check if the user wants to quit, small q or capital q
        if (name.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        // Add product price to the list dynamically until the user types "q"
        decimal? price = null;
        // Check if the user entered an empty string for the price, if so, prompt them to enter a valid price
        while (price is null)
        // Ask for and validate the price input
        {
            Console.Write("Enter product price:");
            string priceInput = Console.ReadLine()?.Trim() ?? string.Empty;

            // Error handling for OrdinalIgnoreCase comparison to check if the user wants to quit
            if (priceInput.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            // Error handling for invalid price input, including negative numbers
            if (!decimal.TryParse(priceInput, out decimal parsedPrice))
            {
                // Error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid price.");
                Console.ResetColor();
            }
            // Error handling for negative price input
            else if (parsedPrice < 0)

            {
                // Error message in red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Price cannot be negative.");
                Console.ResetColor();
            }
            // If the price input is valid, assign it to the price variable
            else
            {
                price = parsedPrice;
            }
        }
        // Create a new product with the provided category, name, and price
        Product product = new(category, name, price.Value);
        Console.WriteLine();

        manager.AddProduct(product);

        // After a user has finished adding all info for a single product, give a success message
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nProduct added successfully!\n");
        Console.ResetColor();

        // Added a separator line for better readability
        Console.WriteLine(new string('-', 40));
        manager.ShowProducts();
    }
    // Display a sorted list of products in a formatted table and the total price of all products added

    // Calculate the total price of all products in the list and display it
    decimal total = manager.CalculateTotal();
    {
        Console.WriteLine($"\nTotal Price: {total:C}\n");
    }

    // Search for products by name or category until the user types "q"
    Console.WriteLine("Search or press Enter to continue adding products:");
    string searchTerm = Console.ReadLine()?.Trim() ?? string.Empty;

    // Check if the user entered an empty string for the search term, if so, keep adding products without searching
    if (string.IsNullOrWhiteSpace(searchTerm))
    {
        continue;
    }
    // Check if the user wants to quit, small q or capital q
    if (searchTerm.Equals("q", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }
    // Search for products by name or category and display the results in a formatted table with highlighted search terms
    var matches = manager.SearchProduct(searchTerm);
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("\nSEARCH RESULTS\n");
    Console.ResetColor();
    Console.WriteLine($"{"Category",-12} | {"Name",-12} | {"Price",8}");
    Console.WriteLine(new string('-', 40));

    // Loop through the list of matching products and display them in a formatted table with highlighted search terms
    foreach (var p in matches)
    {
        WriteHighlighted(p.Category.PadRight(12), searchTerm);
        Console.Write(" | ");
        WriteHighlighted(p.Name.PadRight(12), searchTerm);
        Console.WriteLine($" | {p.Price,8:C}");
    }
    // If no products were found matching the search term, display a message in red text
    if (matches.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No products found matching the search term.");
        Console.ResetColor();
    }
    Console.WriteLine();
}