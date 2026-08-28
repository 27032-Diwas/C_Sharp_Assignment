using LINQ.Repository;
using LINQ.View;

namespace LINQ.Service;

/// <summary>
/// Contains method related to task 3.
/// </summary>
public class Task3
{
    private readonly ProductRepository _repository = new();
    private readonly SupplierRepository _supplierRepository = new();
    private readonly LinqView _linqView = new();

    /// <summary>
    /// Gets all distinct number.
    /// Gets all pairs whose sum is equal to target.
    /// </summary>
    public void GetTask3Products()
    {
        int[] numbers = { 10, 5, 20, 8, 15, 12, 20, 7, 13, 5 };
        int target = 25;

        int secondHighest = numbers
            .Distinct()
            .OrderByDescending(num => num)
            .Skip(1)
            .First();

        this._linqView.DisplayMessage($"Second Highest Number: {secondHighest}");

        List<(int number1, int number2)> pairs = numbers
            .SelectMany(
                (first, index) => numbers
                .Skip(index + 1)
                .Where(second => first + second == target)
                .Select(second => (
                        Math.Min(first, second),
                        Math.Max(first, second))))
            .Distinct()
            .ToList();

        this._linqView.Display(pairs);
    }
}
