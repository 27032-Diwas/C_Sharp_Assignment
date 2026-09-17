using ConsoleTables;
using FilesAndStreams;
using System.Net.Http.Headers;

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

        Task2 task2 = new Task2();
        List<long> asyncTimes = task2.RunAsync().Result;
        Task1 task1 = new Task1();
        List<long> times = task1.Run();

        ConsoleTable table = new ("Type of Execution", "Create File", "File stream", "Buffer stream", "Process data", "Write processed data");
        table.AddRow("Sync", times[0], times[1], times[2], times[3], times[4]);
        table.AddRow("Async", asyncTimes[0], asyncTimes[1], asyncTimes[2], asyncTimes[3], asyncTimes[4]);

        Console.WriteLine("\nComparison Table\n");
        table.Write();
        Console.ReadKey();
    }
}