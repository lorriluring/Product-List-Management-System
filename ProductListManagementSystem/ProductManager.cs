using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductListManagementSystem;

// This class is responsible for managing the list of products in the system.
public class ProductManager
{
    public readonly List<Product> products = [];

    // This method adds a new product to the list of products.
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // This method displays all the products in the list from lowest to highest price in a formatted table.
    public void ShowProducts()
    {
        Console.WriteLine("\nPRODUCT LIST\n");
        Console.WriteLine($"{"Category",-20} | {"Name",-20} | {"Price",12}");
        Console.WriteLine(new string('-', 60));

        foreach (Product product in products.OrderBy(product => product.Price))
        {
            Console.WriteLine(
                $"{product.Category,-20} | {product.Name,-20} | {product.Price,12}");
        }
    }

    // This method calculates the total price of all products in the list.
    public decimal CalculateTotal()
    {
        decimal total = 0;

        foreach (Product product in products)
        {
            total += product.Price;
        }
        return total;
    }
}