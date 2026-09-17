using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Contains implementation for task 2.
/// </summary>
public class Task2
{
    private IFileSystem _fileSystem = new System.IO.Abstractions.FileSystem();

    /// <summary>
    /// Executes task 1 asynchronously.
    /// </summary>
    /// <returns> List of times. </returns>
    public async Task<List<long>> RunAsync()
    {
        Console.WriteLine("=================================================================================================");
        List<long> times = new ();
        Console.WriteLine("Creating File\n");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        await Task.WhenAll(this.GenerateFile("file1.txt", 4000000), this.GenerateFile("file2.txt", 4000000), this.GenerateFile("file3.txt", 4000000));
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);
        Console.WriteLine($"\nTime taken to create three files {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
        Console.WriteLine("------------------------------------------------------------------------------------------------");

        Console.WriteLine("\nReading with FileStream\n");

        stopwatch.Restart();
        Task<long> task1 = this.ReadWithFileStream("file1.txt");
        Task<long> task2 = this.ReadWithFileStream("file2.txt");
        Task<long> task3 = this.ReadWithFileStream("file3.txt");

        await Task.WhenAll(task1, task2, task3);
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        long timeTakenWithFileStream1 = await task1;
        long timeTakenWithFileStream2 = await task2;
        long timeTakenWithFileStream3 = await task3;
        Console.WriteLine("Time taken to read with file stream 1: " + timeTakenWithFileStream1);
        Console.WriteLine("Time taken to read with file stream 2: " + timeTakenWithFileStream2);
        Console.WriteLine("Time taken to read with file stream 3: " + timeTakenWithFileStream3);
        Console.WriteLine($"\nTime taken to read three files {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("------------------------------------------------------------------------------------------------");

        Console.WriteLine("\nReading with Buffered Stream\n");

        stopwatch.Restart();
        Task<long> buffer1 = this.ReadWithBufferStream("file1.txt");
        Task<long> buffer2 = this.ReadWithBufferStream("file2.txt");
        Task<long> buffer3 = this.ReadWithBufferStream("file3.txt");

        await Task.WhenAll(buffer1, buffer2, buffer3);
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        long timeTakenWithBufferStream1 = await buffer1;
        long timeTakenWithBufferStream2 = await buffer2;
        long timeTakenWithBufferStream3 = await buffer3;
        Console.WriteLine("Time taken to read with buffered stream 1: " + timeTakenWithBufferStream1);
        Console.WriteLine("Time taken to read with buffered stream 2: " + timeTakenWithBufferStream2);
        Console.WriteLine("Time taken to read with buffered stream 3: " + timeTakenWithBufferStream3);
        Console.WriteLine($"\nTime take to read three files using buffer {stopwatch.ElapsedMilliseconds}\n");

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
        Console.WriteLine("------------------------------------------------------------------------------------------------");

        stopwatch.Restart();
        Task<string> data1 = this.ProcessData("file1.txt");
        Task<string> data2 = this.ProcessData("file2.txt");
        Task<string> data3 = this.ProcessData("file3.txt");

        await Task.WhenAll(data1, data2, data3);
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);
        Console.WriteLine($"\nTime taken to process three files {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();

        Console.WriteLine("------------------------------------------------------------------------------------------------");
        stopwatch.Restart();
        await Task.WhenAll(this.WriteProcessedData("data1.txt", data1.Result), this.WriteProcessedData("data2.txt", data2.Result), this.WriteProcessedData("data3.txt", data3.Result));
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);
        Console.WriteLine($"\nTime taken to write three files {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
        Console.WriteLine("=================================================================================================");

        return times;
    }

    private async Task GenerateFile(string path, int numberOfValues)
    {
        if (this._fileSystem.File.Exists(path))
        {
            Console.WriteLine("File already exists");
            return;
        }

        const int FlushThreshold = 1024 * 1024; // 1 MB

        string line =
            "Implement a method that uses FileStream to read data from a large text file (at least 1GB in size, create your own file of size 1GB, and Use File write techniques to create it, the data can be text data downloaded from Site or numerical data such as Weather Data)." +
            Environment.NewLine;

        StringBuilder buffer = new (FlushThreshold);

        await using FileStream fileStream = new(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 1024 * 1024,
            useAsync: true);

        await using StreamWriter writer = new (fileStream);

        for (int i = 0; i < numberOfValues; i++)
        {
            buffer.Append(line);

            if (buffer.Length >= FlushThreshold)
            {
                await writer.WriteAsync(buffer.ToString());
                buffer.Clear();
            }
        }

        if (buffer.Length > 0)
        {
            await writer.WriteAsync(buffer.ToString());
        }

        await writer.FlushAsync();
    }

    private async Task<long> ReadWithFileStream(string path)
    {
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024 * 1024];
            int bytesRead;
            long totalBytesRead = 0;

            Stopwatch stopwatch = new ();
            stopwatch.Start();

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }

    private async Task<long> ReadWithBufferStream(string path)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (BufferedStream bufferedStream = new (stream, 1024 * 1024 * 32))
            {
                byte[] bytes = new byte[1024 * 1024];
                int bytesRead;
                long totalBytesRead = 0;

                Stopwatch stopWatch = new ();
                stopWatch.Start();

                while ((bytesRead = await bufferedStream.ReadAsync(bytes, 0, bytes.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                stopWatch.Stop();

                return stopWatch.ElapsedMilliseconds;
            }
        }
    }

    private async Task<string> ProcessData(string path)
    {
        Console.WriteLine("\nProcessing Data....");
        StringBuilder processedString = new StringBuilder();
        using (FileStream stream = new(path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new(stream))
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();

                char[] buffer = new char[1024 * 1024];
                int charRead;

                while ((charRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    processedString.Append(new string(buffer, 0, charRead));
                }

                stopwatch.Stop();

                Console.WriteLine("Processing Ended");
                Console.WriteLine($"Time taken to process: {stopwatch.ElapsedMilliseconds}");
            }
        }

        return processedString.ToString();
    }

    private async Task WriteProcessedData(string path, string processedData)
    {
        Console.WriteLine("\nCopying data....");

        using (MemoryStream stream = new MemoryStream())
        {
            byte[] encodedData = Encoding.UTF8.GetBytes(processedData);
            await stream.WriteAsync(encodedData, 0, encodedData.Length);

            stream.Position = 0;

            using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            stream.CopyTo(fileStream);
        }

        Console.WriteLine("Data copied to new file.");
    }
}
