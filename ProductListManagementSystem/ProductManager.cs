namespace ProductListManagementSystem;

// This class is responsible for managing the list of products in the system.
public class ProductManager
{
    // A list to store the products in the system, initialized as an empty list.
    public readonly List<Product> products = [];

    // This method adds a new product to the list of products.
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // This method displays all the products in the list from lowest to highest price in a formatted table.
    public void ShowProducts()
    {
        // Display the product list header with dark yellow text for better visibility
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n========== PRODUCT LIST ==========\n");
        Console.ResetColor();
        Console.WriteLine($"{"Category",-12} | {"Name",-12} | {"Price",8}");
        Console.WriteLine(new string('-', 40));

        // Sort using LINQ orderby method to sort the products by price in ascending order
        foreach (Product product in products.OrderBy(product => product.Price))
        {
            Console.WriteLine(
                $"{product.Category,-12} | {product.Name,-12} | {product.Price,8:C}");
        }
    }

    // This method calculates the total price of all products in the list.
    public decimal CalculateTotal()
    {
        return products.Sum(product => product.Price);
    }

    // This method searches for existing products in the list by name or category and returns a list of matching products.
    public List<Product> SearchProduct(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
            return [];

        // Use LINQ to filter the products list based on the search term, ignoring case sensitivity, and return a sorted list of matching products by price
        return products
                .Where(p =>
                p.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                p.Category.Contains(term, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Price)
                .ToList();
    }
}