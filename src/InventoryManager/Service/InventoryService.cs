using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Repository;

namespace InventoryManager.Service;

/// <summary>
/// Provide methods for managing inventory and coordination between product repository and product controller.
/// </summary>
public class InventoryService : IService
{
    private static Dictionary<string, int> _categoryCounters = new ();
    private readonly InventoryRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryService"/> class.
    /// </summary>
    /// <param name="inventoryRepository"> Repository that manage inventory data. </param>
    public InventoryService(InventoryRepository inventoryRepository)
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
    public void AddProduct(string productName, ProductEnums.ProductCategories category, decimal productPrice, int productQuantity, out string message)
    {
        if (!Validation.IsProductNameValid(productName))
        {
            message = MessageConstants.InvalidProductName;
            return;
        }
        else if (!Validation.IsProductPriceValid(productPrice))
        {
            message = MessageConstants.InvalidProductPrice;
            return;
        }
        else if (!Validation.IsProductQuantiyValid(productQuantity))
        {
            message = MessageConstants.InvalidProductQuantity;
            return;
        }

        Product product = new (this.GenerateProductId(category), productName)
        {
            ProductPrice = productPrice,
            ProductQuantity = productQuantity,
        };

        this._inventoryRepository.AddProduct(product);
        message = MessageConstants.SuccessfulAdditionOfProduct;
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
    /// <param name="productId"> Id of product that need to be removed. </param>
    /// <param name="message"> A message indicating the result of the product removal operation. </param>
    public void RemoveProduct(string productId, out string message)
    {
        message = string.Empty;
    }

    /// <summary>
    /// Return list of products that containing the search word.
    /// </summary>
    /// <param name="searchWord"> Word that need to be searched. </param>
    /// <returns> List of products. </returns>
    public List<Product> SearchProducts(string searchWord)
    {
        return new List<Product>();
    }

    /// <summary>
    /// Update new value to existing list.
    /// </summary>
    /// <param name="product"> Object containing new details. </param>
    /// <param name="message"> A message indicating the result of product updation operation. </param>
    public void UpdateProduct(Product product, out string message)
    {
        message = string.Empty;
    }

    /// <summary>
    /// Validate inputs by calling validation class.
    /// </summary>
    /// <param name="product"> Object containing product details. </param>
    /// <param name="message"> A message indicating the result of product detail validation. </param>
    public void ValiadateInputs(Product product, out string message)
    {
        message = string.Empty;
    }

    private string GenerateProductId(ProductEnums.ProductCategories category)
    {
        string productIdPrefix = "Misc";
        switch (category)
        {
            case ProductEnums.ProductCategories.Clothing:
                productIdPrefix = "CLTH";
                break;
            case ProductEnums.ProductCategories.Sports:
                productIdPrefix = "SPRT";
                break;
            case ProductEnums.ProductCategories.Grocery:
                productIdPrefix = "GROC";
                break;
            case ProductEnums.ProductCategories.Consumable:
                productIdPrefix = "CONS";
                break;
            case ProductEnums.ProductCategories.Electronics:
                productIdPrefix = "ELEC";
                break;
            case ProductEnums.ProductCategories.Furniture:
                productIdPrefix = "FURN";
                break;
            case ProductEnums.ProductCategories.Miscellaneous:
                productIdPrefix = "MISC";
                break;
        }

        if (!_categoryCounters.ContainsKey(productIdPrefix))
        {
            _categoryCounters[productIdPrefix] = 0;
        }

        return $"{productIdPrefix} - {_categoryCounters[productIdPrefix]:D4}";
    }
}
