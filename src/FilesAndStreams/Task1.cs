using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Implements task1.
/// </summary>
public class Task1
{
    private const int BufferSize = 1024 * 1024;

    /// <summary>
    /// Runs the application
    /// </summary>
    /// <returns> List of time. </returns>
    public List<long> Run()
    {
        Console.WriteLine("============== SYNCHRONOUS VERSION ==============");

        List<long> times = new ();
        Stopwatch stopWatch = new ();

        stopWatch.Start();
        this.GenerateFile("file1.txt", 3000000);
        this.GenerateFile("file2.txt", 3000000);
        this.GenerateFile("file3.txt", 3000000);
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"\n3 File Creation Time : {stopWatch.ElapsedMilliseconds} ms\n");

        stopWatch.Restart();
        long read1 = this.ReadWithFileStream("file1.txt");
        long read2 = this.ReadWithFileStream("file2.txt");
        long read3 = this.ReadWithFileStream("file3.txt");
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"File1 Read : {read1} ms");
        Console.WriteLine($"File2 Read : {read2} ms");
        Console.WriteLine($"File3 Read : {read3} ms");
        Console.WriteLine($"\nTotal FileStream Read : {stopWatch.ElapsedMilliseconds} ms\n");

        stopWatch.Restart();
        long buffer1 = this.ReadWithBufferedStream("file1.txt");
        long buffer2 = this.ReadWithBufferedStream("file2.txt");
        long buffer3 = this.ReadWithBufferedStream("file3.txt");
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"File1 Buffered Read : {buffer1} ms");
        Console.WriteLine($"File2 Buffered Read : {buffer2} ms");
        Console.WriteLine($"File3 Buffered Read : {buffer3} ms");
        Console.WriteLine($"\nTotal Buffered Read : {stopWatch.ElapsedMilliseconds} ms");

        stopWatch.Restart();
        this.ProcessData("file1.txt", "processed1.txt");
        this.ProcessData("file2.txt", "processed2.txt");
        this.ProcessData("file3.txt", "processed3.txt");
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"\nProcessing Time : {stopWatch.ElapsedMilliseconds} ms");

        stopWatch.Restart();
        this.WriteProcessedData("processed1.txt", "output1.txt");
        this.WriteProcessedData("processed2.txt", "output2.txt");
        this.WriteProcessedData("processed3.txt", "output3.txt");
        stopWatch.Stop();

        times.Add(stopWatch.ElapsedMilliseconds);
        Console.WriteLine($"\nWrite Time : {stopWatch.ElapsedMilliseconds} ms\n");

        return times;
    }

    private void GenerateFile(string path, int recordCount)
    {
        if (File.Exists(path))
        {
            return;
        }

        using FileStream fileStream = new (path, FileMode.Create, FileAccess.Write);
        using StreamWriter writer = new (fileStream);
        string line = "weather,data,24.5,humidity,70,pressure,1013";
        StringBuilder block = new ();
        for (int i = 0; i < 10000; i++)
        {
            block.AppendLine(line);
        }

        string largeBlock = block.ToString();
        for (int i = 0; i < recordCount / 10000; i++)
        {
            writer.Write(largeBlock);
        }
    }

    private long ReadWithFileStream(string path)
    {
        Stopwatch stopWatch = Stopwatch.StartNew();
        using FileStream fileStream = new (path, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[BufferSize];
        while (fileStream.Read(buffer, 0, buffer.Length) > 0)
        {
        }

        stopWatch.Stop();

        return stopWatch.ElapsedMilliseconds;
    }

    private long ReadWithBufferedStream(string path)
    {
        Stopwatch stopWatch = Stopwatch.StartNew();
        byte[] buffer = new byte[BufferSize];
        using FileStream fileStream = new (path, FileMode.Open, FileAccess.Read);
        using BufferedStream bs = new (fileStream, BufferSize * 16);
        while (bs.Read(buffer, 0, buffer.Length) > 0)
        {
        }

        stopWatch.Stop();

        return stopWatch.ElapsedMilliseconds;
    }

    private string ProcessData(string inputPath, string outputPath)
    {
        using FileStream input = new (inputPath, FileMode.Open, FileAccess.Read);
        using FileStream output = new (outputPath, FileMode.Create, FileAccess.Write);
        using StreamReader reader = new (input);
        using StreamWriter writer = new (output);
        char[] buffer = new char[BufferSize];
        int charsRead;
        while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
        {
            string upper = new string(buffer, 0, charsRead).ToUpperInvariant();

            writer.Write(upper);
        }

        return outputPath;
    }

    private void WriteProcessedData(string sourceFile, string destinationFile)
    {
        using MemoryStream memoryStream = new ();
        using (FileStream source = new (sourceFile, FileMode.Open, FileAccess.Read))
        {
            source.CopyTo(memoryStream);
        }

        memoryStream.Position = 0;
        using FileStream destination = new (destinationFile, FileMode.Create, FileAccess.Write);
        memoryStream.CopyTo(destination);
    }
}