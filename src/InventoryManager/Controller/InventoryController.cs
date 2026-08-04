using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
///  Get inputs and display outputs for add, view, update, delete, search, display product, get product details and get product id.
/// </summary>
public class InventoryController : IController
{
    private readonly IService _inventoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="inventoryService"> Instance of inventory service </param>
    public InventoryController(IService inventoryService)
    {
        this._inventoryService = inventoryService;
    }

    /// <summary>
    /// Gets user inputs and add product.
    /// </summary>
    public void AddProduct()
    {
        ProductCategories productCategory = DisplayEnum.GetMenuChoice<ProductCategories>(HeaderMessages.ProductCategories);
        if (productCategory == ProductCategories.Exit)
        {
            return;
        }

        InventoryView.ClearConsole();

        string? userInput;
        do
        {
            userInput = InventoryView.GetStringInput(UserPrompts.GetProductName);
            if (userInput == null)
            {
                return;
            }

            if (!Validation.IsProductNameValid(userInput))
            {
                InventoryView.DisplayMessage(ErrorMessages.InvalidProductName);
                continue;
            }

            break;
        }
        while (true);
        string productName = userInput;

        decimal? decimalInput;
        do
        {
            decimalInput = InventoryView.GetDecimalInput(UserPrompts.GetProductPrice);
            if (decimalInput == null)
            {
                return;
            }

            if (!Validation.IsProductPriceValid(decimalInput.Value))
            {
                InventoryView.DisplayMessage(ErrorMessages.InvalidProductPrice);
                continue;
            }

            break;
        }
        while (true);
        decimal productPrice = decimalInput.Value;

        int? integerInput;
        do
        {
            integerInput = InventoryView.GetIntegerInput(UserPrompts.GetProductQuantity);
            if (integerInput == null)
            {
                return;
            }

            if (!Validation.IsProductPriceValid(integerInput.Value))
            {
                InventoryView.DisplayMessage(ErrorMessages.InvalidProductQuantity);
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
    /// Gets product id and remove product.
    /// </summary>
    public void RemoveProduct()
    {
    }

    /// <summary>
    /// Gets new details and create an object.
    /// </summary>
    public void UpdateProduct()
    {
        Product? product = this.GetProduct();
        if (product is null)
        {
            return;
        }

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

        this._inventoryService.UpdateProduct(product, productPrice, productQuantity, out string message);
        InventoryView.DisplayMessage(message);
    }

    /// <summary>
    /// Display all products.
    /// </summary>
    public void ViewAllProducts()
    {
    }

    /// <summary>
    /// Gets search word from user and displays the result of the search.
    /// </summary>
    /// <returns> List of product that matches the search word. </returns>
    public List<Product>? SearchProducts()
    {
        string? userInput = InventoryView.GetStringInput(UserPrompts.GetSearchWord);
        if (userInput == null)
        {
            return null;
        }

        string searchWord = userInput;

        List<Product> products = this._inventoryService.SearchProducts(searchWord);
        if (!products.Any())
        {
            InventoryView.DisplayMessage(ErrorMessages.EmptyList);
            return null;
        }

        InventoryView.DisplayProducts(products);
        return products;
    }

    private Product? GetProduct()
    {
        int? serialNo;
        List<Product>? products = this.SearchProducts();
        if (products is null)
        {
            return null;
        }
        else if (products.Count == 1)
        {
            string? choice;
            do
            {
                choice = InventoryView.GetStringInput(MessageConstants.GetYesOrNo);
                if (choice is null || choice.ToUpper().Equals("N"))
                {
                    return null;
                }
                else if (!choice.ToUpper().Equals("Y"))
                {
                    Console.WriteLine(MessageConstants.InvalidOption);
                    continue;
                }

                break;
            }
            while (true);
            return products[0];
        }

        do
        {
            serialNo = InventoryView.GetIntegerInput($"{MessageConstants.SelectSerialNumber} [ 1 - {products.Count} ]");
            if (serialNo is null)
            {
                return null;
            }

            if (serialNo > products.Count || serialNo < 1)
            {
                InventoryView.DisplayMessage($"{MessageConstants.InvalidSerialNumber} [ 1 - {products.Count} ]");
                continue;
            }

            break;
        }
        while (true);

        return products[serialNo.Value - 1];
    }
}
