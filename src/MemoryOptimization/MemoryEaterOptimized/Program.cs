namespace Assignments;

/// <summary>
/// Entry point to the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the program.
    /// </summary>
    public static void Main()
    {
        MemoryEater memoryEater = new ();
        memoryEater.Allocate();

        Console.ReadKey();
    }
}

/// <summary>
/// Contains logic to allocate memory.
/// </summary>
internal class MemoryEater
{
    /// <summary>
    /// Allocates memory and adds it to a list.
    /// </summary>
    public void Allocate()
    {
        List<int[]> memAlloc = new ();
        int[] list = new int[1000];
        while (true)
        {
            memAlloc.Add(list);

            // Assume memAlloc variable is used within the loop.
            Thread.Sleep(10);
        }
    }
}