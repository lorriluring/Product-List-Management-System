using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

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
}