using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Performs read and write operation in list (CRUD).
/// </summary>
public class InventoryRepository : IRepository
{
    private List<Product> _products = new ();

    /// <summary>
    /// Add product to the list.
    /// </summary>
    /// <param name="product"> Instance of product. </param>
    public void AddProduct(Product product)
    {
        this._products.Add(product);
    }

    /// <summary>
    /// Gets all products from product list.
    /// </summary>
    /// <returns> List of all products. </returns>
    public List<Product> GetAllProducts() => this._products;

    /// <summary>
    /// Removes product from the list.
    /// </summary>
    /// <param name="productId"> Id of product that needs to be removed. </param>
    public void RemoveProduct(string productId)
    {
        foreach (Product product in this._products)
        {
            if (productId.Equals(product.ProductId))
            {
                this._products.Remove(product);
                break;
            }
        }
    }

    /// <summary>
    /// Search product in list based on search word entered by user.
    /// </summary>
    /// <param name="searchWord"> Word to be searched in product list. </param>
    /// <returns> List of products that match the search word. </returns>
    public List<Product> SearchProduct(string searchWord) => this._products
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
        foreach (Product product in this._products)
        {
            if (product.ProductId.Equals(updatedProduct.ProductId))
            {
                product.ProductPrice = updatedProduct.ProductPrice;
                product.ProductQuantity = updatedProduct.ProductQuantity;
                break;
            }
        }
    }
}
