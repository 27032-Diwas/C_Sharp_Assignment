namespace Collections.Service;

/// <summary>
/// Contains operations for task 6.
/// </summary>
public class Task6
{
    /// <summary>
    /// Calculates the sum of all numbers in the collection.
    /// </summary>
    /// <param name="numbers"> The collection of numbers to sum. </param>
    /// <returns> The total sum of all numbers. </returns>
    public int SumOfElements(IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }
}
