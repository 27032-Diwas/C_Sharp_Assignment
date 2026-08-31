using System.Diagnostics;
using LINQ.Models;
using LINQ.Repository;
using LINQ.View;

namespace LINQ.Service;

/// <summary>
/// Contains method related to task 4.
/// </summary>
public class Task4
{
    private readonly ProductRepository _repository = new ();
    private readonly LinqView _linqView = new ();

    /// <summary>
    /// Gets book category and order by price.
    /// </summary>
    public void GetTask4Products()
    {
        List<Product> products = this._repository.GetAllProducts();

        this._linqView.DisplayMessage("Time to order by price first then get by category.");

        Stopwatch stopwatch1 = Stopwatch.StartNew();

        List<Product> books1 = products
            .OrderBy(product => product.ProductPrice)
            .Where(product => product.Category == "Books")
            .ToList();

        this._linqView.Display(books1);

        stopwatch1.Stop();

        this._linqView.DisplayMessage($"Order Then Filter: {stopwatch1.Elapsed.TotalMilliseconds} ms\n");

        Stopwatch stopwatch2 = Stopwatch.StartNew();

        this._linqView.DisplayMessage("Time to get by category first and then order by price [ IEnumerable ].");
        IEnumerable<Product> books = products
            .Where(product => product.Category == "Books")
            .OrderBy(product => product.ProductPrice);

        this._linqView.DisplayMessage($"{books.Count()}");
        this._linqView.Display(books);
        stopwatch2.Stop();

        this._linqView.DisplayMessage($"Filter then order: {stopwatch2.Elapsed.TotalMilliseconds} ms\n");

        Stopwatch stopwatch3 = Stopwatch.StartNew();

        this._linqView.DisplayMessage("Time to get by category first and then order by price [ List ].");
        List<Product> bookList = products
            .Where(product => product.Category == "Books")
            .OrderBy(product => product.ProductPrice)
            .ToList();

        this._linqView.DisplayMessage($"{bookList.Count()}");
        this._linqView.Display(bookList);

        stopwatch3.Stop();

        this._linqView.DisplayMessage($"Filter then order: {stopwatch3.Elapsed.TotalMilliseconds} ms");
    }
}
