using System.Runtime.CompilerServices;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Contain implementation for logger.
/// </summary>
public class Task4
{
    private static readonly object _lockObject = new ();

    /// <summary>
    /// Logs the error into the file.
    /// </summary>
    /// <param name="userId"> Id of user. </param>
    /// <param name="errorMessage"> Error message to log. </param>
    public static void LogError(
        string userId,
        string errorMessage)
    {
        string filePath = $"Logs\\{userId}.txt";

        string logMessage =
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - {errorMessage}";

        byte[] bytes =
            Encoding.UTF8.GetBytes(logMessage + Environment.NewLine);

        lock (_lockObject)
        {
            using FileStream fileStream =
                new FileStream(filePath, FileMode.Append, FileAccess.Write);

            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
