namespace LINQ.Models;

/// <summary>
/// Contains properties and method related to product.
/// </summary>
public class Product
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="productID"> ID of the product. </param>
    /// <param name="productName"> Name of the product. </param>
    /// <param name="productPrice"> Price of the product. </param>
    /// <param name="category"> Category of the product. </param>
    public Product(int productID, string productName, decimal productPrice, string category)
    {
        this.ProductID = productID;
        this.ProductName = productName;
        this.ProductPrice = productPrice;
        this.Category = category;
    }

    /// <summary>
    /// Gets or init product ID.
    /// </summary
    /// <value> ID of the product. </value>
    public int ProductID { get; init; }

    /// <summary>
    /// Gets or sets product name.
    /// </summary>
    /// <value> Name of the product. </value>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product price.
    /// </summary>
    /// <value> Price of the product. </value>
    public decimal ProductPrice { get; set; }

    /// <summary>
    /// Gets or sets product category.
    /// </summary>
    /// <value> Category of the product. </value>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Clones the product.
    /// </summary>
    /// <returns> Instance of cloned product. </returns>
    public Product Clone()
    {
        return new Product(this.ProductID, this.ProductName, this.ProductPrice, this.Category);
    }
}
