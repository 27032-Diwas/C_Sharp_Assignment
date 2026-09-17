using System.Diagnostics;
using System.IO.Abstractions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Implements task 1.
/// </summary>
public class Task1
{
    private IFileSystem _fileSystem = new System.IO.Abstractions.FileSystem();

    /// <summary>
    /// Executes task1.
    /// </summary>
    /// <param name="filePath"> Path of the file. </param>
    /// <returns> List of times. </returns>
    public List<long> Run()
    {
        List<long> times = new List<long>();
        Console.WriteLine("Creating File\n");

        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();
        this.GenerateFile("SyncFile1.txt", 1000000);
        this.GenerateFile("SyncFile2.txt", 1000000);
        this.GenerateFile("SyncFile3.txt", 1000000);
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        Console.WriteLine($"\nTime taken to create three files {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();

        Console.WriteLine("------------------------------------------------------------------------------------------------");
        Console.WriteLine("\nReading with FileStream\n");
        stopwatch.Restart();
        long timeTakenWithFileStream1 = this.ReadWithFileStream("SyncFile1.txt");
        long timeTakenWithFileStream2 = this.ReadWithFileStream("SyncFile2.txt");
        long timeTakenWithFileStream3 = this.ReadWithFileStream("SyncFile3.txt");
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        Console.WriteLine($"Time taken to read with file stream 1: {timeTakenWithFileStream1}");
        Console.WriteLine($"Time taken to read with file stream 2: {timeTakenWithFileStream2}");
        Console.WriteLine($"Time taken to read with file stream 3: {timeTakenWithFileStream3}");

        Console.WriteLine($"\nTime taken to read three files {stopwatch.ElapsedMilliseconds}");

        Console.WriteLine("------------------------------------------------------------------------------------------------");
        Console.WriteLine("\nReading with Buffered Stream\n");
        stopwatch.Restart();
        long timeTakenWithBufferedStream1 = this.ReadWithBufferStream("SyncFile1.txt");
        long timeTakenWithBufferedStream2 = this.ReadWithBufferStream("SyncFile2.txt");
        long timeTakenWithBufferedStream3 = this.ReadWithBufferStream("SyncFile3.txt");
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        Console.WriteLine($"Time taken to read with buffered stream 1: {timeTakenWithBufferedStream1}");
        Console.WriteLine($"Time taken to read with buffered stream 2: {timeTakenWithBufferedStream2}");
        Console.WriteLine($"Time taken to read with buffered stream 3: {timeTakenWithBufferedStream3}");

        Console.WriteLine($"\nTime take to read three files using buffer {stopwatch.ElapsedMilliseconds}\n");

        Console.WriteLine("------------------------------------------------------------------------------------------------");

        Console.WriteLine($"Buffer stream 1 is {timeTakenWithFileStream1 - timeTakenWithBufferedStream1} ms faster");
        Console.WriteLine($"Buffer stream 2 is {timeTakenWithFileStream2 - timeTakenWithBufferedStream2} ms faster");
        Console.WriteLine($"Buffer stream 3 is {timeTakenWithFileStream3 - timeTakenWithBufferedStream3} ms faster");

        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();

        Console.WriteLine("------------------------------------------------------------------------------------------------");
        stopwatch.Restart();
        string data1 = this.ProcessData("SyncFile1.txt");
        string data2 = this.ProcessData("SyncFile2.txt");
        string data3 = this.ProcessData("SyncFile3.txt");
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        Console.WriteLine($"\nTime taken to process three files {stopwatch.ElapsedMilliseconds}");

        Console.WriteLine("------------------------------------------------------------------------------------------------");
        stopwatch.Restart();
        this.WriteProcessedData("SyncData1.txt", data1);
        this.WriteProcessedData("SyncData2.txt", data2);
        this.WriteProcessedData("SyncData3.txt", data3);
        stopwatch.Stop();
        times.Add(stopwatch.ElapsedMilliseconds);

        Console.WriteLine($"\nTime taken to write three files {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
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

        StringBuilder buffer = new(FlushThreshold);

        await using FileStream fileStream = new(
            path,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 1024 * 1024,
            useAsync: true);

        await using StreamWriter writer = new(fileStream);

        for (int i = 0; i < numberOfValues; i++)
        {
            buffer.Append(line);

            if (buffer.Length >= FlushThreshold)
            {
                writer.Write(buffer.ToString());
                buffer.Clear();
            }
        }

        if (buffer.Length > 0)
        {
            writer.Write(buffer.ToString());
        }

        writer.Flush();
    }

    private long ReadWithFileStream(string path)
    {
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024 * 1024];
            int bytesRead;
            long totalBytesRead = 0;

            Stopwatch stopwatch = new ();
            stopwatch.Start();

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }

    private long ReadWithBufferStream(string path)
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

                while ((bytesRead = bufferedStream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                stopWatch.Stop();

                return stopWatch.ElapsedMilliseconds;
            }
        }
    }

    private string ProcessData(string path)
    {
        Console.WriteLine("\nProcessing Data....");
        StringBuilder processedString = new StringBuilder();
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new (stream))
            {
                Stopwatch stopwatch = new ();
                stopwatch.Start();

                char[] buffer = new char[1024 * 1024];
                int charRead;

                while ((charRead = reader.Read(buffer, 0, buffer.Length)) > 0)
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

    private void WriteProcessedData(string path, string processedData)
    {
        Console.WriteLine("\nCopying data....");

        using (MemoryStream stream = new MemoryStream())
        {
            byte[] encodedData = Encoding.UTF8.GetBytes(processedData);
            stream.Write(encodedData, 0, encodedData.Length);

            stream.Position = 0;

            using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            stream.CopyTo(fileStream);
        }

        Console.WriteLine("Data copied to new file.");
    }
}
