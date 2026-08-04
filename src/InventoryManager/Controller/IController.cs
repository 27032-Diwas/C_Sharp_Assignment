using InventoryManager.Models;

namespace InventoryManager.Controller;

/// <summary>
/// Interface for controller class containing add, view, update, delete, search.
/// </summary>
internal interface IController
{
    /// <summary>
    /// Get user inputs and add product.
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
    /// Get search word from user and displays product that match.
    /// </summary>
    /// <returns> List of product that matches the search word. </returns>
    public List<Product> SearchProducts();
}
