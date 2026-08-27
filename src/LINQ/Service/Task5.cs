using LINQ.Models;
using LINQ.Repository;
using LINQ.View;

namespace LINQ.Service;

/// <summary>
/// Contains method related to task5
/// </summary>
public class Task5
{
    private readonly ProductRepository _repository = new();
    private readonly SupplierRepository _supplierRepository = new();
    private readonly LinqView _linqView = new();

    /// <summary>
    /// Runs all the query.
    /// </summary>
    public void Run()
    {
        List<Product> products = this._repository.GetAllProducts();
        List<Supplier> suppliers = this._supplierRepository.GetAllSuppliers();

        this._linqView.DisplayMessage("Filter product by product price greater than 500 and sort by price");
        IEnumerable<Product> filteredProduct = new QueryBuilder<Product>(products)
            .Filter(product => product.ProductPrice > 500)
            .Sort(product => product.ProductPrice)
            .Execute();
        this._linqView.Display(filteredProduct.ToList());

        this._linqView.DisplayMessage("Filter books with price greater than 50 and sort in descending order by name");
        IEnumerable<Product> expensiveBooks =
            new QueryBuilder<Product>(products)
                .Filter(product => product.Category == "Books")
                .Filter(product => product.ProductPrice > 50)
                .SortDescending(product => product.ProductName)
                .Execute();
        this._linqView.Display(expensiveBooks.ToList());

        this._linqView.DisplayMessage("Sort product by product name");
        IEnumerable<Product> sortedByName =
            new QueryBuilder<Product>(products)
                .Sort(product => product.ProductName)
                .Execute();
        this._linqView.Display(sortedByName.ToList());

        this._linqView.DisplayMessage("Join supplier to product");
        IEnumerable<(string ProductName, decimal ProductPrice, string SupplierName)> productSuppliers =
           new QueryBuilder<Product>(products)
               .Join(
                   suppliers,
                   product => product.ProductID,
                   supplier => supplier.ProductID,
                   (product, supplier) => (product.ProductName, product.ProductPrice, supplier.SupplierName))
               .Execute();
        this._linqView.Display(productSuppliers.ToList());
    }
}
