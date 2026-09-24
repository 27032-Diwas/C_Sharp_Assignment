namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstration of anonymous method.
/// </summary>
public class AnonymousMethod
{
    /// <summary>
    /// Demonstrates the task.
    /// </summary>
    public void Demonstrate()
    {
        int[] numbers = { 3, 2, 1, 8, 5, 6, 7 };

        Array.Sort(numbers, delegate(int number1, int number2)
        {
            return number1.CompareTo(number2);
        });

        Console.Write($"Number in order: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}
