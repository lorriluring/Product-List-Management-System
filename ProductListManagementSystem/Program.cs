using ProductListManagementSystem;

Console.WriteLine("Product List Management System");

// Create a list to store products
List<Product> products = new List<Product>();

// add products to the list dynamically until the user types "q"
while (true)
{
    Console.Write("Enter product category (or type 'q' to quit):");
    string category = Console.ReadLine();

    // Check if the user wants to quit, small q or capital q
    if (category.ToLower().Trim() == "q")
    {
        break;
    }

    Console.Write("Enter product name (or type 'q' to quit):");
    string name = Console.ReadLine();

    // Check if the user wants to quit, small q or capital q
    if (name.ToLower().Trim() == "q")
    {
        break;
    }


    Console.Write("Enter product price (or type 'q' to quit):");
    // Check if the user wants to quit, small q or capital q
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
    // Create a new product and add it to the list
    Product product = new Product(category, name, price);
    products.Add(product);
    // After a user has finished adding all info for a single product, give a success message 

    Console.WriteLine("\nProduct added successfully!\n");

}
// Present the user with all added products in a formatted list

Console.WriteLine("\nPRODUCT LIST\n");
Console.WriteLine($"{"Category",-20} | {"Name",-20} | {"Price",12}");
Console.WriteLine(new string('-', 60));
foreach (var product in products)
{
    Console.WriteLine($"{product.Category,-20} | {product.Name,-20} | {product.Price,12:C}");
}