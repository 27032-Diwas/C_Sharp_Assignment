using InventoryManager.Repository;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
/// Contoller that containing method for add, view, update, delete, search, display product, get product details and get product id.
/// </summary>
public class InventoryController
{
    private readonly InventoryService _inventorySerivce;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="inventorySerivce"> Service that mangae logical operations. </param>
    public InventoryController(InventoryService inventorySerivce)
    {
        this._inventorySerivce = inventorySerivce;
    }

    /// <summary>
    /// Calls get product details and create object with the detials.
    /// </summary>
    public void AddProduct()
    {

    }

    /// <summary>
    /// Get product id of product to remove and call service.
    /// </summary>
    public void RemoveProduct()
    {
    }

    /// <summary>
    /// Getnew details and create an object and pass it to service.
    /// </summary>
    public void UpdateProduct()
    {
    }

    /// <summary>
    /// Get product list and call display product.
    /// </summary>
    public void ViewAllProducts()
    {
    }

    /// <summary>
    /// Get search word from user and calls service.
    /// </summary>
    public void SearchProducts()
    {
    }
}
