namespace AdvanceTopics.Tasks;

/// <summary>
/// Contains property of product.
/// </summary>
public class Product
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="name"> Product name. </param>
    /// <param name="category"> Product category. </param>
    /// <param name="price"> Product price. </param>
    public Product(string name, string category, decimal price)
    {
        this.Name = name;
        this.Category = category;
        this.Price = price;
    }

    /// <summary>
    /// Gets or sets product name.
    /// </summary>
    /// <value> Product name. </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets product category.
    /// </summary>
    /// <value> Product category. </value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets product price.
    /// </summary>
    /// <value> Product price. </value>
    public decimal Price { get; set; }
}
