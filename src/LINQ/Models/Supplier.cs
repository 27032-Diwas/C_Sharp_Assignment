namespace LINQ.Models;

/// <summary>
/// Contains all the property and methods related to supplier.
/// </summary>
public class Supplier
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Supplier"/> class.
    /// </summary>
    /// <param name="supplierID"> ID of supplier. </param>
    /// <param name="supplierName"> Name of the supplier. </param>
    /// <param name="productID"> ID of the product. </param>
    public Supplier(int supplierID, string supplierName, int productID)
    {
        this.SupplierID = supplierID;
        this.SupplierName = supplierName;
        this.ProductID = productID;
    }

    /// <summary>
    /// Gets or init supplier ID.
    /// </summary>
    /// <value> ID of the supplier. </value>
    public int SupplierID { get; init; }

    /// <summary>
    /// Gets or sets supplier name.
    /// </summary>
    /// <value> Name of the supplier. </value>
    public string SupplierName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or init product it.
    /// </summary>
    /// <value> ID of the product. </value>
    public int ProductID { get; init; }

    /// <summary>
    /// Clones the supplier.
    /// </summary>
    /// <returns> Instance of clone. </returns>
    public Supplier Clone()
    {
        return new Supplier(this.SupplierID, this.SupplierName, this.ProductID);
    }
}
