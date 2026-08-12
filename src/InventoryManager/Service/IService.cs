using InventoryManager.EnumConstants;
using InventoryManager.Models;

namespace InventoryManager.Service;

/// <summary>
/// Interface for service class containing add, view, update, delete, search and validation methods.
/// </summary>
public interface IService
{
    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="productName"> Name of the product. </param>
    /// <param name="category"> Category of product. </param>
    /// <param name="productPrice"> Price of the product. </param>
    /// <param name="productQuantity"> Quantity of the product. </param>
    /// <param name="message"> A message indicating the result of the product addition operation. </param>
    public void AddProduct(string productName, ProductCategories category, decimal productPrice, long productQuantity, out string message);

    /// <summary>
    /// Removes product from the list.
    /// </summary>
    /// <param name="productId"> Id of the product that needs to be removed. </param>
    /// <param name="message"> Success or error message. </param>
    public void RemoveProduct(string productId, out string message);

    /// <summary>
    /// Removes all the products from the list.
    /// </summary>
    public void DeleteAllProduct();
    /// <summary>
    /// Updates product with new data.
    /// </summary>
    /// <param name="product"> Instance of updated product. </param>
    /// <param name="productPrice"> Updated price of product. </param>
    /// <param name="productQuantity"> Updated quantity of the product. </param>
    /// <param name="message"> Success or error message. </param>
    public void UpdateProduct(Product product, decimal productPrice, long productQuantity, out string message);

    /// <summary>
    /// Gets all product from product list.
    /// </summary>
    /// <returns> List of all products. </returns>
    public List<Product> GetAllProducts();

    /// <summary>
    /// Search product list for products that contains search word.
    /// </summary>
    /// <param name="searchWord"> Word to be searched. </param>
    /// <returns> List of products that contains search word. </returns>
    public List<Product> SearchProducts(string searchWord);
}
