using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Contains methods to work with product list (CRUD).
/// </summary>
public class InventoryRepository : IRepository
{
    private readonly List<Product> _products = new ();

    /// <summary>
    /// Add product to the list.
    /// </summary>
    /// <param name="product"> Object containing product details. </param>
    public void AddProduct(Product product)
    {
        this._products.Add(product);
    }

    /// <summary>
    /// Gets all products from product list.
    /// </summary>
    /// <returns> List of all products. </returns>
    public List<Product> GetAllProducts()
    {
        return new List<Product>();
    }

    /// <summary>
    /// Removes product from the list.
    /// </summary>
    /// <param name="productId"> Id of product that need to be removed. </param>
    public void RemoveProduct(string productId)
    {
    }

    /// <summary>
    /// Search product in list based on search word entered by user.
    /// </summary>
    /// <param name="searchWord"> Word need to be searched in product list. </param>
    /// <returns> List of products that match the search word. </returns>
    public List<Product> SearchProduct(string searchWord)
    {
        return new List<Product>();
    }

    /// <summary>
    /// Update the details of product in the product list.
    /// </summary>
    /// <param name="product"> Product object with new details to update. </param>
    public void UpdateProduct(Product product)
    {
    }
}
