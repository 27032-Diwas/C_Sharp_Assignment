using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Performs read and write operation in list (CRUD).
/// </summary>
public class InventoryRepository : IRepository
{
    private readonly IRead _readRepository;
    private readonly IWrite _writeRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryRepository"/> class.
    /// </summary>
    /// <param name="read"> Instance for read repository. </param>
    /// <param name="write"> Instance for write repository. </param>
    public InventoryRepository(IRead read, IWrite write)
    {
        this._readRepository = read;
        this._writeRepository = write;
    }

    /// <summary>
    /// Add product to the list.
    /// </summary>
    /// <param name="product"> Instance of product. </param>
    public void AddProduct(Product product)
    {
        List<Product> products = this._readRepository.ReadProducts();
        products.Add(product);
        this._writeRepository.WriteProducts(products);
    }

    /// <summary>
    /// Gets all products from product list.
    /// </summary>
    /// <returns> List of all products. </returns>
    public List<Product> GetAllProducts() => this._readRepository.ReadProducts();

    /// <summary>
    /// Removes product from the list.
    /// </summary>
    /// <param name="productId"> Id of product that needs to be removed. </param>
    public void RemoveProduct(string productId)
    {
        List<Product> products = this._readRepository.ReadProducts();
        foreach (Product product in products)
        {
            if (productId.Equals(product.ProductId))
            {
                products.Remove(product);
                break;
            }
        }

        this._writeRepository.WriteProducts(products);
    }

    /// <summary>
    /// Search product in list based on search word entered by user.
    /// </summary>
    /// <param name="searchWord"> Word to be searched in product list. </param>
    /// <returns> List of products that match the search word. </returns>
    public List<Product> SearchProduct(string searchWord) => this._readRepository.ReadProducts()
                                                            .Where(product =>
                                                            product.ProductId.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                                                            product.ProductName.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                                                            .OrderBy(product => product.ProductId)
                                                            .Select(product => product.Clone())
                                                            .ToList();

    /// <summary>
    /// Update the details of product in the product list.
    /// </summary>
    /// <param name="updatedProduct"> Instance of updated product. </param>
    public void UpdateProduct(Product updatedProduct)
    {
        List<Product> products = this._readRepository.ReadProducts();
        foreach (Product product in products)
        {
            if (product.ProductId.Equals(updatedProduct.ProductId))
            {
                product.ProductPrice = updatedProduct.ProductPrice;
                product.ProductQuantity = updatedProduct.ProductQuantity;
                break;
            }
        }

        this._writeRepository.WriteProducts(products);
    }
}
