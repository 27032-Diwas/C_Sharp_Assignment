using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Helper;
using InventoryManager.Repository;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
/// Contoller that containing method for add, view, update, delete, search, display product, get product details and get product id.
/// </summary>
public class InventoryController
{
    private readonly InventoryService _inventoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="inventoryService"> Service that manage logical operations. </param>
    public InventoryController(InventoryService inventoryService)
    {
        this._inventoryService = inventoryService;
    }

    /// <summary>
    /// Calls get product details and create object with the details.
    /// </summary>
    public void AddProduct()
    {
        ProductEnums.ProductCategories productCategory = DisplayEnum.GetMenuChoice<ProductEnums.ProductCategories>(MessageConstants.ProductCategories);

        string? userInput;
        do
        {
            userInput = InventoryView.GetStringInput(MessageConstants.GetProductName);
            if (userInput == null)
            {
                return;
            }

            if (!Validation.IsProductNameValid(userInput))
            {
                InventoryView.DisplayMessage(MessageConstants.InvalidProductName);
                continue;
            }

            break;
        }
        while (true);
        string productName = userInput;

        decimal? decimalInput;
        do
        {
            decimalInput = InventoryView.GetDecimalInput(MessageConstants.GetProductPrice);
            if (decimalInput == null)
            {
                return;
            }

            if (!Validation.IsProductPriceValid(decimalInput.Value))
            {
                InventoryView.DisplayMessage(MessageConstants.InvalidProductPrice);
                continue;
            }

            break;
        }
        while (true);
        decimal productPrice = decimalInput.Value;

        int? integerInput;
        do
        {
            integerInput = InventoryView.GetIntegerInput(MessageConstants.GetProductQuantity);
            if (integerInput == null)
            {
                return;
            }

            if (!Validation.IsProductPriceValid(integerInput.Value))
            {
                InventoryView.DisplayMessage(MessageConstants.InvalidProductQuantity);
                continue;
            }

            break;
        }
        while (true);
        int productQuantity = integerInput.Value;
        this._inventoryService.AddProduct(productName, productCategory, productPrice, productQuantity, out string message);
        InventoryView.ClearConsole();
        InventoryView.DisplayMessage(message);
    }

    /// <summary>
    /// Get product id of product to remove and call service.
    /// </summary>
    public void RemoveProduct()
    {
    }

    /// <summary>
    /// Get new details and create an object and pass it to service.
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
