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
    }
}
