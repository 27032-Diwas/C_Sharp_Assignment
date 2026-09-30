using System.Diagnostics;
using System.Text.Json;
using AsynchronousProgramming;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method.
    /// </summary>
    /// <returns>Task instance.</returns>
    public static async Task Main()
    {
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
        {
            Console.WriteLine(
                $"Unhandled Exception: {((Exception)e.ExceptionObject).Message}");
        };

        await ExecuteTask1();
        ExecuteTask2();
        ExecuteTask3();
        await ExecuteTask4();
        await ExecuteTask5();
        await ExecuteTask6();
        await ExecuteTask7();
    }

    /// <summary>
    /// Demonstrates Async/Await with HttpClient.
    /// </summary>
    private static async Task ExecuteTask1()
    {
        DisplayHeader("TASK 1 : ASYNC / AWAIT");

        WebsiteContentExtractor extractor = new ();

        string url = "https://microsoft.com";

        try
        {
            Console.WriteLine("Downloading content...");

            string content = await extractor.ExtractContent(url);

            Console.WriteLine(content[..Math.Min(content.Length, 500)]);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error : {exception.Message}");
        }

        PauseExecution();
    }

    /// <summary>
    /// Demonstrates the Task Parallel Library.
    /// </summary>
    private static void ExecuteTask2()
    {
        DisplayHeader("TASK 2 : TASK PARALLEL LIBRARY");

        int[] numbers = Enumerable.Range(1, 10000).ToArray();
        int[] sequentialNumbers = Enumerable.Range(1, 10000).ToArray();

        Stopwatch stopwatch = Stopwatch.StartNew();

        Parallel.ForEach(
            Enumerable.Range(0, numbers.Length),
            index =>
            {
                numbers[index] *= numbers[index];
            });

        stopwatch.Stop();

        Console.WriteLine(
            $"Parallel execution time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();

        for (int index = 0; index < sequentialNumbers.Length; index++)
        {
            sequentialNumbers[index] *= sequentialNumbers[index];
        }

        stopwatch.Stop();

        Console.WriteLine(
            $"Sequential execution time: {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine($"First Value : {numbers[0]}");
        Console.WriteLine($"Last Value : {numbers[^1]}");

        PauseExecution();
    }

    /// <summary>
    /// Demonstrates multithreading.
    /// </summary>
    private static void ExecuteTask3()
    {
        DisplayHeader("TASK 3 : MULTITHREADING");

        int[] values = { 2, 5, 1, 8, 6, 9, 13 };

        int[] sortedValues = Array.Empty<int>();
        int sum = 0;

        Thread sortingThread = new (() =>
        {
            sortedValues = SortArray(values);
        });

        Thread sumThread = new (() =>
        {
            sum = CalculateSum(values);
        });

        sortingThread.Start();
        sumThread.Start();

        sortingThread.Join();
        sumThread.Join();

        Console.WriteLine("Sorted Values:");
        PrintArray(sortedValues);

        Console.WriteLine($"Sum = {sum}");

        PauseExecution();
    }

    /// <summary>
    /// Sorts an array.
    /// </summary>
    private static int[] SortArray(int[] array)
    {
        Console.WriteLine(
            $"Sorting Thread Id : {Thread.CurrentThread.ManagedThreadId}");

        int[] copy = (int[])array.Clone();

        Array.Sort(copy);

        return copy;
    }

    /// <summary>
    /// Calculates total.
    /// </summary>
    private static int CalculateSum(int[] array)
    {
        Console.WriteLine(
            $"Calculation Thread Id : {Thread.CurrentThread.ManagedThreadId}");

        int total = 0;

        foreach (int number in array)
        {
            total += number;
        }

        return total;
    }

    /// <summary>
    /// Prints array contents.
    /// </summary>
    private static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write($"{number} ");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Demonstrates layered Async/Await.
    /// </summary>
    private static async Task ExecuteTask4()
    {
        DisplayHeader("TASK 4 : MULTI-LAYERED ASYNC/AWAIT");

        await MethodC();

        PauseExecution();
    }

    /// <summary>
    /// CPU-bound operation.
    /// </summary>
    private static Task<string> MethodA()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Analyzing large dataset...");

            long result = 0;

            for (int i = 0; i < 100_000_000; i++)
            {
                result += i;
            }

            Console.WriteLine($"Analysis Result: {result}");

            return "https://jsonplaceholder.typicode.com/users";
        });
    }

    /// <summary>
    /// Simulates web service access.
    /// </summary>
    private static async Task<string> MethodB()
    {
        WebsiteContentExtractor extractor = new ();

        string url = await MethodA();

        return await extractor.ExtractContent(url);
    }

    /// <summary>
    /// Processes JSON response.
    /// </summary>
    private static async Task MethodC()
    {
        string response = await MethodB();

        using JsonDocument document =
            JsonDocument.Parse(response);

        int count = 0;

        foreach (JsonElement element in
                 document.RootElement.EnumerateArray())
        {
            count += element.EnumerateObject().Count();
        }

        Console.WriteLine($"Total Key Value Pairs : {count}");
    }

    /// <summary>
    /// Demonstrates deadlock avoidance.
    /// </summary>
    private static async Task ExecuteTask5()
    {
        DisplayHeader("TASK 5 : DEADLOCK RESOLUTION");

        await DeadlockMethod();

        PauseExecution();
    }

    /// <summary>
    /// Uses await instead of Result/Wait.
    /// </summary>
    private static async Task DeadlockMethod()
    {
        string result = await SomeAsyncOperation();

        Console.WriteLine(result);
    }

    /// <summary>
    /// Simulated async work.
    /// </summary>
    private static async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(1000);

        return "Hello World!";
    }

    /// <summary>
    /// Demonstrates ConfigureAwait.
    /// </summary>
    private static async Task ExecuteTask6()
    {
        DisplayHeader("TASK 6 : CONFIGUREAWAIT");

        string result = await MethodB1();

        Console.WriteLine($"Final Result : {result}");

        PauseExecution();
    }

    /// <summary>
    /// Long running operation.
    /// </summary>
    private static async Task<string> MethodA1()
    {
        Console.WriteLine(
            $"Thread Before Await : {Thread.CurrentThread.ManagedThreadId}");

        await Task.Delay(5000)
            .ConfigureAwait(false);

        Console.WriteLine(
            $"Thread After Await : {Thread.CurrentThread.ManagedThreadId}");

        return "Hello";
    }

    /// <summary>
    /// Calls MethodA1.
    /// </summary>
    private static async Task<string> MethodB1()
    {
        Console.WriteLine("Method B Started");

        string result = await MethodA1();

        Console.WriteLine("Further Processing Completed");

        return result;
    }

    /// <summary>
    /// Demonstrates Async Void vs Async Task.
    /// </summary>
    private static async Task ExecuteTask7()
    {
        DisplayHeader("TASK 7 : ASYNC VOID VS ASYNC TASK");

        Console.WriteLine("Calling async void method...");

        VoidMethod();

        await Task.Delay(1500);

        try
        {
            Console.WriteLine("Calling async Task method...");

            await TaskMethod();
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"Caught exception from TaskMethod: {exception.Message}");
        }

        PauseExecution();
    }

    /// <summary>
    /// Async void demonstration.
    /// </summary>
    private static async void VoidMethod()
    {
        await Task.Delay(1000);

        throw new Exception("Exception from async void.");
    }

    /// <summary>
    /// Async Task demonstration.
    /// </summary>
    private static async Task TaskMethod()
    {
        await Task.Delay(1000);

        throw new Exception("Exception from async Task.");
    }

    /// <summary>
    /// Waits for key press.
    /// </summary>
    private static void PauseExecution()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Displays section header.
    /// </summary>
    private static void DisplayHeader(string title)
    {
        Console.WriteLine(new string('=', 70));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 70));
    }
}