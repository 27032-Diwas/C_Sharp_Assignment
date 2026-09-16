using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Task 4.
/// </summary>
public class Task4
{
    private static string _logFilePath = "log.txt";

    /// <summary>
    /// Logs the error.
    /// </summary>
    /// <param name="errorMessage"> Error Message. </param>
    public static void LogError(string errorMessage)
    {
        using (MemoryStream memoryStream = new ())
        {
            byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
            memoryStream.Write(errorBytes, 0, errorBytes.Length); 

            using (FileStream fileStream = new (_logFilePath, FileMode.Append))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}
