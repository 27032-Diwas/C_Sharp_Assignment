using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Contains read operation to read data from storage.
/// </summary>
public interface IRead
{
    /// <summary>
    /// Gets all product from storage.
    /// </summary>
    /// <returns> List of products. </returns>
    public List<Product> ReadProducts();
}
