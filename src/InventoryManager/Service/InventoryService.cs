using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Repository;

namespace InventoryManager.Service;

/// <summary>
/// Provide service such as add, view, search, update, delete product and coordination between product repository and product controller.
/// </summary>
public class InventoryService : IService
{
    private static Dictionary<string, int> _categoryCounters = new ();
    private readonly IRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryService"/> class.
    /// </summary>
    /// <param name="inventoryRepository"> Instance of inventory repository. </param>
    public InventoryService(IRepository inventoryRepository)
    {
        this._inventoryRepository = inventoryRepository;
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="productName"> Name of the product. </param>
    /// <param name="category"> Category of product. </param>
    /// <param name="productPrice"> Price of the product. </param>
    /// <param name="productQuantity"> Quantity of the product. </param>
    /// <param name="message"> A message indicating the result of the product addition operation. </param>
    public void AddProduct(string productName, ProductCategories category, decimal productPrice, int productQuantity, out string message)
    {
        if (!Validation.IsProductNameValid(productName))
        {
            message = ErrorMessages.InvalidProductName;
            return;
        }
        else if (!Validation.IsProductPriceValid(productPrice))
        {
            message = ErrorMessages.InvalidProductPrice;
            return;
        }
        else if (!Validation.IsProductQuantityValid(productQuantity))
        {
            message = ErrorMessages.InvalidProductQuantity;
            return;
        }

        Product product = new (GenerateProductId(category), productName)
        {
            ProductPrice = productPrice,
            ProductQuantity = productQuantity,
        };

        this._inventoryRepository.AddProduct(product);
        message = SuccessMessages.SuccessfulAdditionOfProduct;
    }

    /// <summary>
    /// Returns list of all products from product list.
    /// </summary>
    /// <returns> List containing all products. </returns>
    public List<Product> GetAllProducts()
    {
        return new List<Product>();
    }

    /// <summary>
    /// Removes product from product list.
    /// </summary>
    /// <param name="productId"> Id of the product that needs to be removed. </param>
    /// <param name="message"> A message indicating the result of the product removal operation. </param>
    public void RemoveProduct(string productId, out string message)
    {
        message = string.Empty;
    }

    /// <summary>
    /// Search product list for product thats contains search word.
    /// </summary>
    /// <param name="searchWord"> Word that needs to be searched. </param>
    /// <returns> List of products. </returns>
    public List<Product> SearchProducts(string searchWord) => this._inventoryRepository.SearchProduct(searchWord.Trim());

    /// <summary>
    /// Updates new value to existing list.
    /// </summary>
    /// <param name="product"> Instance of product. </param>
    /// /// <param name="productPrice"> Updated price of product. </param>
    /// <param name="productQuantity"> Updated quantity of the product. </param>
    /// <param name="message"> A message indicating the result of product updating operation. </param>
    public void UpdateProduct(Product product, decimal productPrice, int productQuantity, out string message)
    {
        message = string.Empty;
    }

    private static string GenerateProductId(ProductCategories category)
    {
        string productIdPrefix = "Misc";
        switch (category)
        {
            case ProductCategories.Clothing:
                productIdPrefix = "CLTH";
                break;
            case ProductCategories.Sports:
                productIdPrefix = "SPRT";
                break;
            case ProductCategories.Grocery:
                productIdPrefix = "GROC";
                break;
            case ProductCategories.Consumable:
                productIdPrefix = "CONS";
                break;
            case ProductCategories.Electronics:
                productIdPrefix = "ELEC";
                break;
            case ProductCategories.Furniture:
                productIdPrefix = "FURN";
                break;
            case ProductCategories.Miscellaneous:
                productIdPrefix = "MISC";
                break;
            default:
                break;
        }

        if (!_categoryCounters.ContainsKey(productIdPrefix))
        {
            _categoryCounters[productIdPrefix] = 0;
        }

        return $"{productIdPrefix} - {++_categoryCounters[productIdPrefix]:D4}";
    }
}
