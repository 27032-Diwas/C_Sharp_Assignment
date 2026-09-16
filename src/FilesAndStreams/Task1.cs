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
    public void Run(string filePath)
    {
        Console.WriteLine("Creating File");
        this.GenerateFile(filePath, 4000000);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

        Console.WriteLine("\nReading with FileStream");
        long timeTakenWithFileStream = this.ReadWithFileStream(filePath);
        Console.WriteLine("Time taken to read with file stream: " + timeTakenWithFileStream);

        Console.WriteLine("Reading with Buffered Stream");
        long timeTakenWithBufferedStream = this.ReadWithBufferStream(filePath);
        Console.WriteLine("Time taken to read with buffered stream: " + timeTakenWithBufferedStream);

        Console.WriteLine($"\nBuffer stream is {timeTakenWithFileStream - timeTakenWithBufferedStream} ms faster");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

        string data = this.ProcessData(filePath);
        this.WriteProcessedData("data.txt", data);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void GenerateFile(string path, int numberOfValues)
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
                writer.WriteLine("Implement a method that uses FileStream to read data from a large text file (at least 1GB in size, create your own file of size 1GB, and Use File write techniques to create it, the data can be text data downloaded from Site or numerical data such as Weather Data).  ");
            }
        }
    }

    private long ReadWithFileStream(string path)
    {
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[4 * 1024];
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
            using (BufferedStream bufferedStream = new (stream, 32 * 1024))
            {
                byte[] bytes = new byte[4 * 1024];
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
        string processedString = string.Empty;
        using (FileStream stream = new (path, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new (stream))
            {
                Stopwatch stopwatch = new ();
                stopwatch.Start();

                char[] buffer = new char[64 * 1024];
                int charRead;

                while ((charRead = reader.Read(buffer, 0, buffer.Length)) > 0)
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

    private void WriteProcessedData(string path, string processedData)
    {
        Console.WriteLine("\nCopying data....");

        using (MemoryStream stream = new MemoryStream())
        {
            byte[] encodedData = Encoding.UTF8.GetBytes(processedData);
            stream.Write(encodedData, 0, encodedData.Length);

            stream.Position = 0;

            using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
            stream.CopyTo(fileStream);
        }

        Console.WriteLine("Data copied to new file.");
    }
}
