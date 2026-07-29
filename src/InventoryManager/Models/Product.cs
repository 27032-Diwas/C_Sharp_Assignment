namespace InventoryManager.Models;

/// <summary>
/// Contains the property and methods of product.
/// </summary>
public class Product
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="productId"> Product id. </param>
    /// <param name="productName"> Product name. </param>
    public Product(string productId, string productName)
    {
        this.ProductId = productId;
        this.ProductName = productName;
    }

    /// <summary>
    /// Gets or init.
    /// </summary>
    /// <value> Product id. </value>
    public string ProductId { get; init; }

    /// <summary>
    /// Gets or init.
    /// </summary>
    /// <value> Product name. </value>
    public string ProductName { get; init; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Price of the product. </value>
    public decimal ProductPrice { get; set; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Product quantity. </value>
    public int ProductQuantity { get; set; }
}
