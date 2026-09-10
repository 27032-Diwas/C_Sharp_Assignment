using LINQ.Models;
using LINQ.Repository;
using LINQ.View;

namespace LINQ.Service;

/// <summary>
/// Contains method related to task 2.
/// </summary>
public class Task2
{
    private readonly ProductRepository _repository = new ();
    private readonly SupplierRepository _supplierRepository = new ();
    private readonly LinqView _linqView = new ();

    /// <summary>
    /// Group product by category and select product, count and most expensive product.
    /// Joins supplier and product.
    /// </summary>
    public void GetTask2Products()
    {
        this._linqView.DisplayMessage("Task 2: Group by category and inner join supplier to product.\n");
        List<Product> products = this._repository.GetAllProducts();
        List<Supplier> suppliers = this._supplierRepository.GetAllSuppliers();

        List<(string Category, int Count, Product MaxPricedProduct)> groupedProducts = products.GroupBy(product => product.Category)
            .Select(product => (
                product.Key,
                product.Count(),
                product.OrderByDescending(product => product.ProductPrice).First()))
            .ToList();

        this._linqView.Display(groupedProducts);

        List<(string ProductName, decimal ProductPrice, string SupplierName)> productSuppliers = products.Join(
            suppliers,
            product => product.ProductID,
            supplier => supplier.ProductID,
            (product, supplier) => (product.ProductName, product.ProductPrice, supplier.SupplierName)).ToList();

        this._linqView.Display(productSuppliers);
    }
}
