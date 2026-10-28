namespace ProductListManagementSystem
{
    // This class represents a product with a category, name, and price.
    public class Product
    {
        public Product(string category, string name, decimal price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        // Properties for the product's category, name, and price.
        public string Category { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}