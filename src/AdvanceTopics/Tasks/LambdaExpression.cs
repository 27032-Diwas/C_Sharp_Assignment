namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstration of lambda expression.
/// </summary>
public class LambdaExpression
{
    /// <summary>
    /// Demonstrate the task.
    /// </summary>
    public void Demonstrate()
    {
        List<int> numbers = new ();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(5);
        numbers.Add(6);
        numbers.Add(7);
        numbers.Add(8);
        numbers.Add(9);
        numbers.Add(10);

        List<int> evenNumbers = numbers.Where(number => number % 2 == 0).ToList();

        Console.Write("Even numbers :");
        foreach (int number in evenNumbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
        List<int> squareNumber = evenNumbers.Select(number => number * number).ToList();

        Console.Write("Square number: ");
        foreach (int number in squareNumber)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}
