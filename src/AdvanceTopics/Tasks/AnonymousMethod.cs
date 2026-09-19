namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstration of anonymous method.
/// </summary>
public class AnonymousMethod
{
    /// <summary>
    /// Demonstrate the task.
    /// </summary>
    public void Demonstrate()
    {
        int[] numbers = { 3, 2, 1, 8, 5, 6, 7 };

        Array.Sort(numbers, delegate(int number1, int number2)
        {
            if (number1 > number2)
            {
                return 1;
            }
            else if (number1 < number2)
            {
                return -1;
            }

            return 0;
        });

        Console.Write($"Number in order: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}
