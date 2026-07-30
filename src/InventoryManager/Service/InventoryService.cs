using InventoryManager.Constants;
using InventoryManager.Models;
using InventoryManager.Repository;

namespace InventoryManager.Service;

/// <summary>
/// Provide methods for managing inventory and coordination between product repository and product controller.
/// </summary>
public class InventoryService : IService
{
    private readonly InventoryRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryService"/> class.
    /// </summary>
    /// <param name="inventoryRepository"> Repository that manage inventory data. </param>
    public InventoryService(InventoryRepository inventoryRepository)
    {
        this._inventoryRepository = inventoryRepository;
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="product"> Object containing product details. </param>
    /// <param name="message"> A message indicating the result of the product addition operation. </param>
    public void AddProduct(Product product, out string message)
    {
        message = MessageConstants.SuccessfulAdditionOfProduct;
    }

    /// <summary>
    /// Returns list of all products from product list.
    /// </summary>
    /// <returns> List containing all products. </returns>
    public List<Product> GetAllProducts()
    {
        return new List<Product>();
    }

    /// <summary>
    /// Removes product from product list.
    /// </summary>
    /// <param name="productId"> Id of product that need to be removed. </param>
    /// <param name="message"> A message indicating the result of the product removal operation. </param>
    public void RemoveProduct(string productId, out string message)
    {
        message = string.Empty;
    }

    /// <summary>
    /// Return list of products that containing the search word.
    /// </summary>
    /// <param name="searchWord"> Word that need to be searched. </param>
    /// <returns> List of products. </returns>
    public List<Product> SearchProducts(string searchWord)
    {
        return new List<Product>();
    }

    /// <summary>
    /// Update new value to existing list.
    /// </summary>
    /// <param name="product"> Object containing new details. </param>
    /// <param name="message"> A message indicating the result of product updation operation. </param>
    public void UpdateProduct(Product product, out string message)
    {
        message = string.Empty;
    }

    /// <summary>
    /// Validate inputs by calling validation class.
    /// </summary>
    /// <param name="product"> Object containing product details. </param>
    /// <param name="message"> A message indicating the result of product detail validation. </param>
    public void ValiadateInputs(Product product, out string message)
    {
        message = string.Empty;
    }
}
