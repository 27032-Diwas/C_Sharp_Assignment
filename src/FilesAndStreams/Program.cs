using FilesAndStreams;

namespace Assignments;

/// <summary>
/// Entry point to the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application.
    /// </summary>
    public static void Main()
    {
        Task1 task1 = new Task1();
        task1.Run("Data.txt");
    }
}