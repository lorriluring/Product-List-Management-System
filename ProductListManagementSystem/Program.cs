using ProductListManagementSystem;

Console.WriteLine("Product List Management System");

// Create a manager that to stores and manages products
ProductManager manager = new();

// Add products to the list dynamically until the user types "q"
while (true)
{
    Console.Write("Enter product category (or type 'q' to quit):");
    string category = Console.ReadLine();

    // Check if the user wants to quit, small q or capital q
    if (category.ToLower().Trim() == "q")
    {
        break;
    }
    // Add product name to the list dynamically until the user types "q"
    Console.Write("Enter product name (or type 'q' to quit):");
    string name = Console.ReadLine();

    if (name.ToLower().Trim() == "q")
    {
        break;
    }
    // Add product price to the list dynamically until the user types "q"
    Console.Write("Enter product price (or type 'q' to quit):");
    string priceInput = Console.ReadLine();
    if (priceInput.ToLower().Trim() == "q")
    {
        break;
    }
    // Check if the price input is a valid decimal number
    if (!decimal.TryParse(priceInput, out decimal price))
    {
        Console.WriteLine("Invalid price. Please enter a valid number.");
        continue;
    }
    // Create a new product with the provided category, name, and price
    Product product = new(category, name, price);

    manager.AddProduct(product);
    // After a user has finished adding all info for a single product, give a success message
    Console.WriteLine("\nProduct added successfully!\n");
}
// Display a sorted list of products in a formatted table and the total price of all products added

manager.ShowProducts();

decimal total = manager.CalculateTotal();
{
    Console.WriteLine($"\nTotal Price: {total:C}");
}