using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Contains write operation to write data into storage.
/// </summary>
public interface IWrite
{
    /// <summary>
    /// Writes product into storage
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void WriteProducts(List<Product> products);
}
