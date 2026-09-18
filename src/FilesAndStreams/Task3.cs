using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Contains implementation for task 3.
/// </summary>
public static class Task3
{
    /// <summary>
    /// Runs the task.
    /// </summary>
    public static void Run()
    {
        string path = "file4.txt";
        string data = "This is some test data";

        using (MemoryStream memoryStream = new ())
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            memoryStream.Write(buffer, 0, buffer.Length);

            using FileStream fileStream = new (path, FileMode.Create);
            memoryStream.WriteTo(fileStream);
        }

        using (FileStream fileStream = new (path, FileMode.Open))
        {
            byte[] buffer = new byte[1024];

            while (fileStream.Read(buffer, 0, buffer.Length) > 0)
            {
                string chunk = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(chunk);
            }
        }
    }

    /// <summary>
    /// Reproduces the starter code.
    /// </summary>
    public static void RunOriginalCode()
    {
        string data = "This is some test data";
        string filePath = "file5.txt";

        using (MemoryStream memoryStream = new ())
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            memoryStream.Write(buffer, 0, buffer.Length);

            using FileStream fileStream = new (filePath, FileMode.Create);
            byte[] writeBuffer = memoryStream.ToArray();
            fileStream.Write(writeBuffer, 0, writeBuffer.Length);
        }

        using (FileStream fileStream = new (filePath, FileMode.Open))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int index = 0; index < bytesRead; index++)
                {
                    Console.Write((char)buffer[index]);
                }

                Console.WriteLine();
            }
        }
    }
}
