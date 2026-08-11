using InventoryManager.Models;

namespace InventoryManager.Controller;

/// <summary>
/// Interface for controller class containing add, view, update, delete, search.
/// </summary>
public interface IController
{
    /// <summary>
    /// Gets user inputs and add product.
    /// </summary>
    public void AddProduct();

    /// <summary>
    /// Gets product id and remove product.
    /// </summary>
    public void RemoveProduct();

    /// <summary>
    /// Gets new details and create an object.
    /// </summary>
    public void UpdateProduct();

    /// <summary>
    /// Display all products.
    /// </summary>
    public void ViewAllProducts();

    /// <summary>
    /// Gets search word from user and displays the result of the search.
    /// </summary>
    /// <returns> List of products that matches the search word. </returns>
    public List<Product>? SearchProducts();
}
