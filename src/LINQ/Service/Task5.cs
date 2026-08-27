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
    private readonly LinqView _linqView = new();

    public void run()
    {
        List<Product> products = this._repository.GetAllProducts();
        IEnumerable<Product> filteredProduct = new QueryBuilder<Product>(products)
            .Filter(product => product.ProductPrice > 500)
            .Execute();
        this._linqView.Display(filteredProduct);
    }
}
