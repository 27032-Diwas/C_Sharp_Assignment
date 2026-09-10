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
    private readonly int[] _buffer = new int[1000];

    /// <summary>
    /// Reuses the same buffer in each iteration.
    /// </summary>
    public void Allocate()
    {
        while (true)
        {
            // A small example showing the buffer reuse.
            for (int i = 0; i < this._buffer.Length; i++)
            {
                this._buffer[i] = i;
            }

            Thread.Sleep(10);
        }
    }
}