using ConsoleTables;
using FilesAndStreams;
using System.Diagnostics;

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
        Task1 task1 = new();
        List<long> times = task1.Run();

        Console.WriteLine("PRESS ANY KEY TO CONTINUE");
        Console.ReadKey();

        Task2 task2 = new();
        List<long> asyncTimes = task2.RunAsync().Result;

        ConsoleTable table = new ("Type of Execution", "Create File", "File stream", "Buffer stream", "Process data", "Write processed data", "Total");
        table.AddRow("Sync", times[0], times[1], times[2], times[3], times[4], times.Sum());
        table.AddRow("Async", asyncTimes[0], asyncTimes[1], asyncTimes[2], asyncTimes[3], asyncTimes[4], asyncTimes.Sum());

        Console.WriteLine("\nComparison Table\n");
        table.Write();

        Console.WriteLine("PRESS ANY KEY TO CONTINUE");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("============== Task 3 ==============");

        Stopwatch stopwatch = Stopwatch.StartNew();
        Task3.Run();
        stopwatch.Stop();
        Console.WriteLine($"Optimizer Code: {stopwatch.ElapsedMilliseconds}");
        stopwatch.Restart();
        Task3.RunOriginalCode();
        stopwatch.Stop();
        Console.WriteLine($"Original code: {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("PRESS ANY KEY TO CONTINUE");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("============== LOGGING ==============");
        Console.WriteLine("Task 4 - Analyze and Resolve Performance Issues with Logging System");
        FileInfo fileInfo = new FileInfo("log.txt");
        long sizeInBytes = fileInfo.Length;
        Console.WriteLine($"\nFile size in bytes before logging: {sizeInBytes} B");
        stopwatch.Restart();
        Parallel.For(0, 50, index =>
        {
            Task4.LogError($"{index}Error message");
        });

        stopwatch.Stop();
        Console.WriteLine($"\nExecution Time : {stopwatch.ElapsedMilliseconds} ms");
        fileInfo.Refresh();
        sizeInBytes = fileInfo.Length;
        Console.WriteLine($"\nFile size in bytes after logging: {sizeInBytes} B");

        Console.ReadKey();
    }
}