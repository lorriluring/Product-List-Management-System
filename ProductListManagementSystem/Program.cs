using ProductListManagementSystem;

Console.WriteLine("Product List Management System");

// Create a manager that to stores and manages products
ProductManager manager = new();

// Add products to the list dynamically until the user types "q"
while (true)
{
    Console.Write("Enter product category (or type 'q' to quit):");
    string category = Console.ReadLine();
    // Check if the user entered an empty string for the category, if so, prompt them to enter a valid category
    if (string.IsNullOrWhiteSpace(category))
    {
        Console.WriteLine("Category cannot be empty. Please enter a valid category.");
        continue;
    }

    // Check if the user wants to quit, small q or capital q
    if (category.ToLower().Trim() == "q")
    {
        break;
    }

    // Add product name to the list dynamically until the user types "q"
    string name = string.Empty;
    while (string.IsNullOrWhiteSpace(name))

    {
        // Ask for and validate the name input
        Console.Write("Enter product name (or type 'q' to quit):");
        name = Console.ReadLine()?.Trim() ?? string.Empty;
    }
    // Check if the user entered an empty string for the name, if so, prompt them to enter a valid name
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
    }
    // Check if the user wants to quit, small q or capital q
    if (name.ToLower().Trim() == "q")
    {
        break;
    }

    // Add product price to the list dynamically until the user types "q"
    decimal? price = null;
    // Check if the user entered an empty string for the price, if so, prompt them to enter a valid price
    while (price is null)
    // Ask for and validate the price input
    {
        Console.Write("Enter product price (or type 'q' to quit):");
        string priceInput = Console.ReadLine()?.Trim() ?? string.Empty;

        // Error handling for OrdinalIgnoreCase comparison to check if the user wants to quit
        if (priceInput.Equals("q", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }
        // Error handling for invalid price input, including negative numbers
        if (!decimal.TryParse(priceInput, out decimal parsedPrice))
        {
            Console.WriteLine("Invalid price.");
        }
        else if (parsedPrice < 0)
        // Error handling for negative price input
        {
            Console.WriteLine("Price cannot be negative.");
        }
        // If the price input is valid, assign it to the price variable
        else
        {
            price = parsedPrice;
        }
    }
    // Check if the user wants to quit, small q or capital q
    if (price is null)
    {
        break;
    }
    // Create a new product with the provided category, name, and price
    Product product = new(category, name, price.Value);

    manager.AddProduct(product);
    // After a user has finished adding all info for a single product, give a success message
    Console.WriteLine("\nProduct added successfully!\n");
    manager.ShowProducts();
}
// Display a sorted list of products in a formatted table and the total price of all products added

manager.ShowProducts();

// Calculate the total price of all products in the list and display it
decimal total = manager.CalculateTotal();
{
    Console.WriteLine($"\nTotal Price: {total:C}");
}