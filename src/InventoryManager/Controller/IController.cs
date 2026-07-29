namespace InventoryManager.Controller;

/// <summary>
/// Interface for contoller class containing add, view, update, delete, search, display product, get product details and get product id.
/// </summary>
public interface IController
{
    /// <summary>
    /// Calls get product details and create object with the detials.
    /// </summary>
    public void AddContact();

    /// <summary>
    /// Get product id of product to remove and call service.
    /// </summary>
    public void RemoveContact();

    /// <summary>
    /// Getnew details and create an object and pass it to service.
    /// </summary>
    public void UpdateContact();

    /// <summary>
    /// Get product list and call display product.
    /// </summary>
    public void ViewAllProducts();

    /// <summary>
    /// Get search word from user and calls service.
    /// </summary>
    public void SearchProducts();
}
