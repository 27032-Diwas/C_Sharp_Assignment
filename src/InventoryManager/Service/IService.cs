using InventoryManager.Models;

namespace InventoryManager.Service;

/// <summary>
/// Interface for service class containing add, view, update, delete, search and validation methods.
/// </summary>
public interface IService
{
    /// <summary>
    /// Calls validateInputs to validate details and repository to add product into product list.
    /// </summary>
    /// <param name="product"> Product object containing details. </param>
    /// <param name="message"> Success or error message. </param>
    public void AddProduct(Product product, out string message);

    /// <summary>
    /// Calls repository and passes productId to remove product from list.
    /// </summary>
    /// <param name="productId"> ProductId of product to be removed. </param>
    /// <param name="message"> Success or error message. </param>
    public void RemoveProduct(string productId, out string message);

    /// <summary>
    /// Calls validation to validate detials and repository to update product with new details.
    /// </summary>
    /// <param name="product"> Product object containing details. </param>
    /// <param name="message"> Success or error message. </param>
    public void UpdateProduct(Product product, out string message);

    /// <summary>
    /// Calls the repository to get list of all products.
    /// </summary>
    /// <returns> List of all products. </returns>
    public List<Product> GetAllProducts();

    /// <summary>
    /// Calls the repository to get products that match the search word.
    /// </summary>
    /// <param name="searchWord"> Word need to be searched. </param>
    /// <returns> List of product that has search word. </returns>
    public List<Product> SearchProducts(string searchWord);

    /// <summary>
    /// Calls helper class to validate inputs.
    /// </summary>
    /// <param name="product"> Product object containing data. </param>
    /// <param name="message"> Success or eroor message. </param>
    public void ValiadateInputs(Product product, out string message);
}
