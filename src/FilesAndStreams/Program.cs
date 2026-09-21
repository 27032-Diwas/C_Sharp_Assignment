// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FilesAndStreams;

using System.Diagnostics;
using ConsoleTables;

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
        Task1 task1 = new ();
        List<long> times = task1.Run();

        Console.WriteLine("PRESS ANY KEY TO CONTINUE");
        Console.ReadKey();

        Task2 task2 = new ();
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
        Task3.RunOriginalCode();
        stopwatch.Stop();
        Console.WriteLine($"\nOriginal code execution time: {stopwatch.ElapsedMilliseconds} ms\n");
        stopwatch.Restart();
        Task3.Run();
        stopwatch.Stop();
        Console.WriteLine($"\nOptimizer Code execution time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine("\nPRESS ANY KEY TO CONTINUE");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("============== LOGGING ==============");
        Console.WriteLine("Task 4 - Analyze and Resolve Performance Issues with Logging System");
        if (!File.Exists("Logs\\User1.txt"))
        {
            using FileStream stream = File.Create("Logs\\User1.txt");
        }

        FileInfo fileInfo = new ("Logs\\User1.txt");
        long sizeInBytes = fileInfo.Length;
        Console.WriteLine($"\nFile size in bytes before logging: {sizeInBytes} B");
        stopwatch.Restart();
        Parallel.For(0, 50, index =>
        {
            Task4.LogError("User1", $"Error message");
            Task4.LogError("User2", $"Error message");
        });

        stopwatch.Stop();
        Console.WriteLine($"\nExecution Time : {stopwatch.ElapsedMilliseconds} ms");
        fileInfo.Refresh();
        sizeInBytes = fileInfo.Length;
        Console.WriteLine($"\nFile size in bytes after logging: {sizeInBytes} B");

        Console.ReadKey();
    }
}