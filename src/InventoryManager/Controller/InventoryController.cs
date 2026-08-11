using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
///  Get inputs and display outputs for add, view, update, delete, search and display product.
/// </summary>
public class InventoryController : IController
{
    private readonly IService _inventoryService;
    private readonly IView _inventoryView;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="inventoryService"> Instance of inventory service. </param>
    /// <param name="inventoryView"> Instance of inventory view. </param>
    public InventoryController(IView inventoryView, IService inventoryService)
    {
        this._inventoryView = inventoryView;
        this._inventoryService = inventoryService;
    }

    /// <summary>
    /// Gets user inputs and add product.
    /// </summary>
    public void AddProduct()
    {
        ProductCategories productCategory = this._inventoryView.GetMenuChoice<ProductCategories>(HeaderMessages.ProductCategories);
        if (productCategory is ProductCategories.Exit)
        {
            return;
        }

        this._inventoryView.ClearConsole();

        string? productName = this.GetProductName();

        if (productName is null)
        {
            return;
        }

        decimal? productPrice = this.GetProductPrice();
        if (productPrice is null)
        {
            return;
        }

        long? productQuantity = this.GetProductQuantity();
        if (productQuantity is null)
        {
            return;
        }

        this._inventoryService.AddProduct(productName, productCategory, productPrice.Value, productQuantity.Value, out string message);
        this._inventoryView.ClearConsole();
        this._inventoryView.DisplayMessage(message);
    }

    /// <summary>
    /// Gets product id and remove product.
    /// </summary>
    public void RemoveProduct()
    {
        Product? product = this.GetProduct();
        if (product is null)
        {
            return;
        }

        this._inventoryService.RemoveProduct(product.ProductId, out string message);
        this._inventoryView.ClearConsole();
        this._inventoryView.DisplayMessage(message);
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

        decimal? productPrice = this.GetProductPrice();
        if (productPrice is null)
        {
            return;
        }

        long? productQuantity = this.GetProductQuantity();
        if (productQuantity is null)
        {
            return;
        }

        this._inventoryService.UpdateProduct(product, productPrice.Value, productQuantity.Value, out string message);
        this._inventoryView.ClearConsole();
        this._inventoryView.DisplayMessage(message);
    }

    /// <summary>
    /// Displays all products.
    /// </summary>
    public void ViewAllProducts()
    {
        List<Product> products = this._inventoryService.GetAllProducts();
        if (!products.Any())
        {
            this._inventoryView.DisplayMessage($"{ErrorMessages.EmptyList}");
            return;
        }

        this._inventoryView.DisplayProducts(products);
    }

    /// <summary>
    /// Gets search word from user and displays the result of the search.
    /// </summary>
    /// <returns> List of product that matches the search word. </returns>
    public List<Product>? SearchProducts()
    {
        string? userInput = this._inventoryView.GetStringInput(UserPrompts.GetSearchWord);
        if (userInput is null)
        {
            return null;
        }

        string searchWord = userInput;

        List<Product> products = this._inventoryService.SearchProducts(searchWord);
        if (!products.Any())
        {
            this._inventoryView.DisplayMessage($"\n{ErrorMessages.EmptyList}");
            return null;
        }

        this._inventoryView.DisplayProducts(products);
        return products;
    }

    /// <summary>
    /// Gets name of the product.
    /// </summary>
    /// <returns> Name of the product. </returns>
    private string? GetProductName()
    {
        string? stringInput;
        while (true)
        {
            stringInput = this._inventoryView.GetStringInput(UserPrompts.GetProductName);
            if (stringInput is null)
            {
                return null;
            }

            if (!Validation.IsProductNameValid(stringInput))
            {
                this._inventoryView.DisplayMessage(ErrorMessages.InvalidProductName);
                continue;
            }

            break;
        }

        return stringInput;
    }

    /// <summary>
    /// Gets price of the product.
    /// </summary>
    /// <returns> Price of the product. </returns>
    private decimal? GetProductPrice()
    {
        decimal? decimalInput;
        while (true)
        {
            decimalInput = this._inventoryView.GetDecimalInput(UserPrompts.GetProductPrice);
            if (decimalInput is null)
            {
                return null;
            }

            if (!Validation.IsProductPriceValid(decimalInput.Value))
            {
                this._inventoryView.DisplayMessage(ErrorMessages.InvalidProductPrice);
                continue;
            }

            break;
        }

        return decimalInput;
    }

    /// <summary>
    /// Gets quantity of the product.
    /// </summary>
    /// <returns> Quantity of the product. </returns>
    private long? GetProductQuantity()
    {
        long? longInput;
        while (true)
        {
            longInput = this._inventoryView.GetLongInput(UserPrompts.GetProductQuantity);
            if (longInput is null)
            {
                return null;
            }

            if (!Validation.IsProductQuantityValid(longInput.Value))
            {
                this._inventoryView.DisplayMessage(ErrorMessages.InvalidProductQuantity);
                continue;
            }

            break;
        }

        return longInput;
    }

    /// <summary>
    /// Gets instance of product to update or delete.
    /// </summary>
    /// <returns> Instance of product. </returns>
    private Product? GetProduct()
    {
        int index;
        List<Product>? products = this.SearchProducts();
        if (products is null)
        {
            return null;
        }
        else if (products.Count == 1)
        {
            string? choice;
            while (true)
            {
                choice = this._inventoryView.GetStringInput(UserPrompts.GetYesOrNo);
                if (choice is null || choice.ToUpper().Equals("N") || choice.ToUpper().Equals("NO"))
                {
                    return null;
                }
                else if (!(choice.ToUpper().Equals("Y") || choice.ToUpper().Equals("YES")))
                {
                    this._inventoryView.DisplayMessage(ErrorMessages.InvalidOption);
                    continue;
                }

                break;
            }

            return products[0];
        }

        while (true)
        {
            long? serialNo = this._inventoryView.GetLongInput($"{UserPrompts.SelectSerialNumber} [ 1 - {products.Count} ]");
            if (serialNo is null)
            {
                return null;
            }

            if (serialNo > products.Count || serialNo < 1)
            {
                this._inventoryView.DisplayMessage($"{ErrorMessages.InvalidSerialNumber} [ 1 - {products.Count} ]");
                continue;
            }

            index = (int)serialNo.Value;
            break;
        }

        return products[index - 1];
    }
}
