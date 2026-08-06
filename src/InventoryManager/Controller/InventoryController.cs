using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
///  Gets inputs and display outputs for add, view, update, delete, search, display product, get product details and get product id.
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

        string? productName;
        do
        {
            productName = InventoryView.GetStringInput(UserPrompts.GetProductName);
            if (productName == null)
            {
                return;
            }

            if (!Validation.IsProductNameValid(productName))
            {
                InventoryView.DisplayMessage(ErrorMessages.InvalidProductName);
                continue;
            }

            break;
        }
        while (true);

        decimal? productPrice = this.GetProductPrice();
        if (productPrice is null)
        {
            return;
        }

        int? productQuantity = this.GetProductQuantity();
        if (productQuantity is null)
        {
            return;
        }

        this._inventoryService.AddProduct(productName, productCategory, productPrice.Value, productQuantity.Value, out string message);
        InventoryView.ClearConsole();
        InventoryView.DisplayMessage(message);
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
        InventoryView.ClearConsole();
        InventoryView.DisplayMessage(message);
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

        int? productQuantity = this.GetProductQuantity();
        if (productQuantity is null)
        {
            return;
        }

        this._inventoryService.UpdateProduct(product, productPrice.Value, productQuantity.Value, out string message);
        InventoryView.ClearConsole();
        InventoryView.DisplayMessage(message);
    }

    /// <summary>
    /// Displays all products.
    /// </summary>
    public void ViewAllProducts()
    {
        List<Product> products = this._inventoryService.GetAllProducts();
        if (!products.Any())
        {
            InventoryView.DisplayMessage($"{ErrorMessages.EmptyList}");
            return;
        }

        InventoryView.DisplayProducts(products);
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
            InventoryView.DisplayMessage($"\n{ErrorMessages.EmptyList}");
            return null;
        }

        InventoryView.DisplayProducts(products);
        return products;
    }

    /// <summary>
    /// Gets instance of product to update or delete.
    /// </summary>
    /// <returns> Instance of product. </returns>
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
                choice = InventoryView.GetStringInput(UserPrompts.GetYesOrNo);
                if (choice is null || choice.ToUpper().Equals("N"))
                {
                    return null;
                }
                else if (!choice.ToUpper().Equals("Y") || !choice.ToUpper().Equals("YES"))
                {
                    Console.WriteLine(ErrorMessages.InvalidOption);
                    continue;
                }

                break;
            }
            while (true);
            return products[0];
        }

        do
        {
            serialNo = InventoryView.GetIntegerInput($"{UserPrompts.SelectSerialNumber} [ 1 - {products.Count} ]");
            if (serialNo is null)
            {
                return null;
            }

            if (serialNo > products.Count || serialNo < 1)
            {
                InventoryView.DisplayMessage($"{ErrorMessages.InvalidSerialNumber} [ 1 - {products.Count} ]");
                continue;
            }

            break;
        }
        while (true);
        return products[serialNo.Value - 1];
    }

    /// <summary>
    /// Gets price of the product.
    /// </summary>
    /// <returns> Price of the product. </returns>
    private decimal? GetProductPrice()
    {
        decimal? decimalInput;
        do
        {
            decimalInput = InventoryView.GetDecimalInput(UserPrompts.GetProductPrice);
            if (decimalInput == null)
            {
                return null;
            }

            if (!Validation.IsProductPriceValid(decimalInput.Value))
            {
                InventoryView.DisplayMessage(ErrorMessages.InvalidProductPrice);
                continue;
            }

            break;
        }
        while (true);
        return decimalInput;
    }

    /// <summary>
    /// Gets quantity of the product.
    /// </summary>
    /// <returns> Quantity of the product. </returns>
    private int? GetProductQuantity()
    {
        int? integerInput;
        do
        {
            integerInput = InventoryView.GetIntegerInput(UserPrompts.GetProductQuantity);
            if (integerInput == null)
            {
                return null;
            }

            if (!Validation.IsProductPriceValid(integerInput.Value))
            {
                InventoryView.DisplayMessage(ErrorMessages.InvalidProductQuantity);
                continue;
            }

            break;
        }
        while (true);
        return integerInput;
    }
}
