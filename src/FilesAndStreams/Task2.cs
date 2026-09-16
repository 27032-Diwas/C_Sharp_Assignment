using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Task2.
/// </summary>
public class Task2
{
    private IFileSystem _fileSystem = new System.IO.Abstractions.FileSystem();

    /// <summary>
    /// Executes task1.
    /// </summary>
    /// <returns> List of times. </returns>
    public async Task<List<long>> RunAsync()
    {
        List<long> times = new ();
        Console.WriteLine("Creating File");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        await Task.WhenAll(this.GenerateFile("file1.txt", 1000000), this.GenerateFile("file2.txt", 1000000), this.GenerateFile("file3.txt", 1000000));
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

        Console.WriteLine("\nReading with FileStream");

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

        Console.WriteLine("Reading with Buffered Stream");

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

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

        stopwatch.Restart();
        Task<string> data1 = this.ProcessData("file1.txt");
        Task<string> data2 = this.ProcessData("file2.txt");
        Task<string> data3 = this.ProcessData("file3.txt");

        await Task.WhenAll(data1, data2, data3);
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        stopwatch.Restart();
        await Task.WhenAll(this.WriteProcessedData("data1.txt", data1.Result), this.WriteProcessedData("data2.txt", data2.Result), this.WriteProcessedData("data3.txt", data3.Result));
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

        return times;
    }

    private async Task GenerateFile(string path, int numberOfValues)
    {
        if (this._fileSystem.File.Exists(path))
        {
            Console.WriteLine("File Already exists");
            return;
        }

        using (StreamWriter writer = new (path))
        {
            for (int i = 0; i < numberOfValues; i++)
            {
                await writer.WriteLineAsync("Implement a method that uses FileStream to read data from a large text file (at least 1GB in size, create your own file of size 1GB, and Use File write techniques to create it, the data can be text data downloaded from Site or numerical data such as Weather Data).  ");
            }
        }
    }

    private async Task<long> ReadWithFileStream(string path)
    {
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[4 * 1024];
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
            using (BufferedStream bufferedStream = new (stream, 32 * 1024))
            {
                byte[] bytes = new byte[4 * 1024];
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
        string processedString = string.Empty;
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new (stream))
            {
                Stopwatch stopwatch = new ();
                stopwatch.Start();

                char[] buffer = new char[64 * 1024];
                int charRead;

                while ((charRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string chuck = new string(buffer, 0, buffer.Length);

                    processedString = chuck.ToUpper();
                }

                stopwatch.Stop();

                Console.WriteLine("Processing Ended");
                Console.WriteLine($"Time taken to process: {stopwatch.ElapsedMilliseconds}");
            }
        }

        return processedString.ToUpper();
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
