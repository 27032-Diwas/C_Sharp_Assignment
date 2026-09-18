using System.Diagnostics;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Contains implementation for task2.
/// </summary>
public class Task2
{
    private const int BufferSize = 1024 * 1024;

    /// <summary>
    /// Runs the application.
    /// </summary>
    /// <returns> List of times. </returns>
    public async Task<List<long>> RunAsync()
    {
        Console.WriteLine("\n============== ASYNCHRONOUS VERSION ==============");

        List<long> times = new ();

        Stopwatch stopWatch = Stopwatch.StartNew();
        await Task.WhenAll(
            this.GenerateFileAsync("AsyncFile1.txt", 3000000),
            this.GenerateFileAsync("AsyncFile2.txt", 3000000),
            this.GenerateFileAsync("AsyncFile3.txt", 3000000));
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"3 File Creation Time : {stopWatch.ElapsedMilliseconds} ms");
        Console.WriteLine("\nAsync FileStream Read");

        stopWatch.Restart();
        await Task.WhenAll(
            this.ReadWithFileStreamAsync("AsyncFile1.txt"),
            this.ReadWithFileStreamAsync("AsyncFile2.txt"),
            this.ReadWithFileStreamAsync("AsyncFile3.txt"));
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"3 File Read Time : {stopWatch.ElapsedMilliseconds} ms");
        Console.WriteLine("\nAsync BufferedStream Read");

        stopWatch.Restart();
        await Task.WhenAll(
            this.ReadWithBufferedStreamAsync("AsyncFile1.txt"),
            this.ReadWithBufferedStreamAsync("AsyncFile2.txt"),
            this.ReadWithBufferedStreamAsync("AsyncFile3.txt"));
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"3 Buffered Reads : {stopWatch.ElapsedMilliseconds} ms");
        Console.WriteLine("\nProcessing Files");

        stopWatch.Restart();
        await Task.WhenAll(
            this.ProcessDataAsync("AsyncFile1.txt", "AsyncProcessed1.txt"),
            this.ProcessDataAsync("AsyncFile2.txt", "AsyncProcessed2.txt"),
            this.ProcessDataAsync("AsyncFile3.txt", "AsyncProcessed3.txt"));
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"Processing Time : {stopWatch.ElapsedMilliseconds} ms");
        Console.WriteLine("\nWriting Files Using MemoryStream");

        stopWatch.Restart();
        await Task.WhenAll(
            this.WriteProcessedDataAsync("AsyncProcessed1.txt", "AsyncOutput1.txt"),
            this.WriteProcessedDataAsync("AsyncProcessed2.txt", "AsyncOutput2.txt"),
            this.WriteProcessedDataAsync("AsyncProcessed3.txt", "AsyncOutput3.txt"));
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"Writing Time : {stopWatch.ElapsedMilliseconds} ms");

        return times;
    }

    private async Task GenerateFileAsync(string path, int recordCount)
    {
        if (File.Exists(path))
        {
            return;
        }

        using FileStream fs = new (path, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, true);
        await using StreamWriter writer = new (fs);
        string line = "weather,data,24.5,humidity,70,pressure,1013";
        StringBuilder block = new ();
        for (int i = 0; i < 10000; i++)
        {
            block.AppendLine(line);
        }

        string largeBlock = block.ToString();
        for (int i = 0; i < recordCount / 10000; i++)
        {
            await writer.WriteAsync(largeBlock);
        }

        await writer.FlushAsync();
    }

    private async Task<long> ReadWithFileStreamAsync(string path)
    {
        Stopwatch stopWatch = Stopwatch.StartNew();
        byte[] buffer = new byte[BufferSize];
        using FileStream fileStream = new (path, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true);
        while (await fileStream.ReadAsync(buffer) > 0)
        {
        }

        stopWatch.Stop();

        return stopWatch.ElapsedMilliseconds;
    }

    private async Task<long> ReadWithBufferedStreamAsync(string path)
    {
        Stopwatch stopWatch = Stopwatch.StartNew();
        byte[] buffer = new byte[BufferSize];
        using FileStream fileStream = new (path, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true);
        using BufferedStream bufferSteram = new (fileStream, BufferSize * 16);
        while (await bufferSteram.ReadAsync(buffer) > 0)
        {
        }

        stopWatch.Stop();

        return stopWatch.ElapsedMilliseconds;
    }

    private async Task ProcessDataAsync(string inputPath, string outputPath)
    {
        using FileStream input = new (inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true);
        using FileStream output = new (outputPath, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, true);
        using StreamReader reader = new (input);
        using StreamWriter writer = new (output);
        char[] buffer = new char[BufferSize];
        int charsRead;
        while ((charsRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            string upper = new string(buffer, 0, charsRead).ToUpperInvariant();
            await writer.WriteAsync(upper);
        }

        await writer.FlushAsync();
    }

    private async Task WriteProcessedDataAsync(string sourceFile, string destinationFile)
    {
        using MemoryStream memoryStream = new ();
        using (FileStream source = new (sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true))
        {
            await source.CopyToAsync(memoryStream);
        }

        memoryStream.Position = 0;
        using FileStream destination = new (destinationFile, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, true);
        await memoryStream.CopyToAsync(destination);
    }
}