using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Interface for repository containing add, view, update, delete and search methods.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Add product to the product list.
    /// </summary>
    /// <param name="product"> Product object containing details. </param>
    public void AddProduct(Product product);

    /// <summary>
    /// Removes product from the product list.
    /// </summary>
    /// <param name="productId"> Id of the product. </param>
    public void RemoveProduct(string productId);

    /// <summary>
    /// Update product in product list.
    /// </summary>
    /// <param name="product"> Product object containing updated details. </param>
    public void UpdateProduct(Product product);

    /// <summary>
    /// Get all products from the list.
    /// </summary>
    /// <returns> List of products. </returns>
    public List<Product> GetAllProducts();

    /// <summary>
    /// Get products that matches the search word.
    /// </summary>
    /// <param name="searchWord"> Word to be searched. </param>
    /// <returns> List of products that match the word. </returns>
    public List<Product> SearchProduct(string searchWord);
}
