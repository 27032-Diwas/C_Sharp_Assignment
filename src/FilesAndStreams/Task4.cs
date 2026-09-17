using System.Runtime.CompilerServices;
using System.Text;

namespace FilesAndStreams;

/// <summary>
/// Contain implementation for logger.
/// </summary>
public class Task4
{
    private static readonly string _logFilePath = "log.txt";

    /// <summary>
    /// Logs the error details in the file.
    /// </summary>
    /// <param name="errorMessage"> The message to be logged. </param>
    public static void LogError(string errorMessage)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - {errorMessage}\n";

        byte[] bytes = Encoding.UTF8.GetBytes($"{logMessage}{Environment.NewLine}");
        lock (_logFilePath)
        {
            using FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write);
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
