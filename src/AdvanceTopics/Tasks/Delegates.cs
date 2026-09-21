using ConsoleTables;

namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstrates sorting with help of delegate.
/// </summary>
public class Delegates
{
    /// <summary>
    /// Delegate that take two product as parameter and return integer.
    /// </summary>
    /// <param name="product1"> Instance of product 1. </param>
    /// <param name="product2"> Instance of product 2.</param>
    /// <returns> Result of sorting. </returns>
    public delegate int SortDelegate(Product product1, Product product2);

    /// <summary>
    /// Demonstrates the task.
    /// </summary>
    public void Demonstrate()
    {
        List<Product> products = new ();
        products.Add(new Product("Cake", "Food", 50));
        products.Add(new Product("Bus", "Transport", 100));
        products.Add(new Product("Milk", "Drinks", 20));
        products.Add(new Product("IceCream", "Food", 70));
        products.Add(new Product("Red", "Color", 30));

        SortDelegate sortByName = this.SortByName;
        SortDelegate sortByCategory = this.SortByCategory;
        SortDelegate sortByPrice = this.SortByPrice;

        Console.WriteLine("Sort By Name");
        this.SortAndDisplay(sortByName, new List<Product>(products));

        Console.WriteLine("Sort By Category");
        this.SortAndDisplay(sortByCategory, new List<Product>(products));

        Console.WriteLine("Sort By Price");
        this.SortAndDisplay(sortByPrice, new List<Product>(products));
    }

    /// <summary>
    /// Sorts the products based on field.
    /// </summary>
    /// <param name="sortBy"> Delegate that contains sort method. </param>
    /// <param name="products"> List of product. </param>
    public void SortAndDisplay(SortDelegate sortBy, List<Product> products)
    {
        products.Sort(new Comparison<Product>(sortBy));

        ConsoleTable table = new ("Product Name", "Product Category", "Product Price");
        foreach (Product product in products)
        {
            table.AddRow(product.Name, product.Category, product.Price);
        }

        table.Write();
    }

    /// <summary>
    /// Sorts the product by name.
    /// </summary>
    /// /// <param name="product1"> Instance of product 1. </param>
    /// <param name="product2"> Instance of product 2.</param>
    /// <returns> Result of sorting. </returns>
    private int SortByName(Product product1, Product product2)
    {
        return string.Compare(product1.Name, product2.Name, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Sorts the product by category.
    /// </summary>
    /// /// <param name="product1"> Instance of product 1. </param>
    /// <param name="product2"> Instance of product 2.</param>
    /// <returns> Result of sorting. </returns>
    private int SortByCategory(Product product1, Product product2)
    {
        return string.Compare(product1.Category, product2.Category, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Sorts the product by price.
    /// </summary>
    /// /// <param name="product1"> Instance of product 1. </param>
    /// <param name="product2"> Instance of product 2.</param>
    /// <returns> Result of sorting. </returns>
    private int SortByPrice(Product product1, Product product2)
    {
        return product1.Price.CompareTo(product2.Price);
    }
}
