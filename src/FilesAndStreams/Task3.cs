using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Task 3
/// </summary>
public class Task3
{
    /// <summary>
    /// Runs the task.
    /// </summary>
    public void Run()
    {
        string path = "path-to-your-file";
        string data = "This is some test data";

        // Writing to file using MemoryStream
        using (MemoryStream memoryStream = new ())
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            memoryStream.Write(buffer, 0, buffer.Length);

            // Write from MemoryStream to file
            using (FileStream fileStream = new (path, FileMode.Create))
            {
                memoryStream.WriteTo(fileStream);
            }
        }

        // Reading from file using FileStream
        using (FileStream fileStream = new (path, FileMode.Open))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string chunk = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(chunk);
            }
        }
    }
}
