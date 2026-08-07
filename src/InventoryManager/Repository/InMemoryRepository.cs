using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Reads and writes data into storage.
/// </summary>
public class InMemoryRepository : IWrite, IRead
{
    private List<Product> _products = new ();

    /// <summary>
    /// Gets all product from the list.
    /// </summary>
    /// <returns> List of products. </returns>
    public List<Product> ReadProducts()
    {
        return new List<Product>(this._products);
    }

    /// <summary>
    /// Write list of products into list.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void WriteProducts(List<Product> products)
    {
        this._products = products;
    }
}
