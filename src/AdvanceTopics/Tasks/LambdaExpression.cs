namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstration of lambda expression.
/// </summary>
public class LambdaExpression
{
    /// <summary>
    /// Demonstrates the task.
    /// </summary>
    public void Demonstrate()
    {
        List<int> numbers = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        List<int> evenNumbers = numbers.Where(number => number % 2 != 0).ToList();

        Console.Write("Odd numbers :");
        foreach (int number in evenNumbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
        List<int> squareNumber = evenNumbers.Select(num =>
        {
            int square = num * num;
            return square;
        }).ToList();

        Console.Write("Square number: ");
        foreach (int number in squareNumber)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}
