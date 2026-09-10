using LINQ.Models;
using LINQ.Repository;
using LINQ.View;

namespace LINQ.Service;

/// <summary>
/// Contains method related to task 1.
/// </summary>
public class Task1
{
    private readonly ProductRepository _repository = new ();
    private readonly LinqView _linqView = new ();

    /// <summary>
    /// Filter product by electronics category and price greater than 500.
    /// Order in descending by product price.
    /// </summary>
    public void GetTask1Products()
    {
        this._linqView.DisplayMessage("Task 1: Filter by electronics category and price greater than 500, order by price descending.\n");
        List<Product> products = this._repository.GetAllProducts();

        List<(string ProductName, decimal ProductPrice)> filteredProduct = products.Where(product => product.Category.Equals("Electronics") && product.ProductPrice > 500)
            .Select(product => (product.ProductName, product.ProductPrice)).ToList();

        var filteredProductSort = filteredProduct.OrderByDescending(product => product.ProductPrice).ToList();

        decimal averageProductPrice = filteredProductSort.Average(product => product.ProductPrice);

        this._linqView.Display(filteredProductSort);
        this._linqView.DisplayMessage($"Average price: {averageProductPrice:F2}");
    }
}
