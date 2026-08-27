using LINQ.Models;

namespace LINQ.Repository;

/// <summary>
/// Contains all read and write operations (CRUD).
/// </summary>
public class ProductRepository
{
    private readonly List<Product> _products = new ()
    {
        new (1, "iPhone 15", 999m, "Electronics"),
        new (2, "Samsung Galaxy S24", 899m, "Electronics"),
        new (3, "Sony Headphones", 299m, "Electronics"),
        new (4, "Dell XPS 15", 1499m, "Electronics"),
        new (5, "MacBook Pro", 1999m, "Electronics"),
        new (6, "LG OLED TV", 1299m, "Electronics"),
        new (7, "Office Chair", 250m, "Furniture"),
        new (8, "Dining Table", 700m, "Furniture"),
        new (9, "Refrigerator", 1200m, "Appliances"),
        new (10, "Washing Machine", 800m, "Appliances"),
        new (11, "Gaming PC", 1800m, "Electronics"),
        new (12, "Monitor", 450m, "Electronics"),
        new (13, "Smart Watch", 550m, "Electronics"),
        new (14, "Bluetooth Speaker", 150m, "Electronics"),
        new (15, "Canon DSLR Camera", 1100m, "Electronics"),
        new (16, "Clean Code", 45m, "Books"),
        new (17, "The Pragmatic Programmer", 50m, "Books"),
        new (18, "Design Patterns", 60m, "Books"),
        new (19, "C# in Depth", 55m, "Books"),
        new (20, "Introduction to Algorithms", 80m, "Books"),
        new (21, "iPhone 15", 999m, "Electronics"),
        new (22, "Dell XPS 15", 1499m, "Electronics"),
        new (23, "Canon DSLR Camera", 1100m, "Electronics"),
        new (24, "Office Chair", 250m, "Furniture"),
        new (25, "Dining Table", 700m, "Furniture"),
    };

    /// <summary>
    /// Adds the product to the list.
    /// </summary>
    /// <param name="product"> Instance of product. </param>
    public void AddProduct(Product product)
    {
        this._products.Add(product);
    }

    /// <summary>
    /// Gets all product from the list.
    /// </summary>
    /// <returns> List of all products. </returns>
    public List<Product> GetAllProducts() => this._products;
}
