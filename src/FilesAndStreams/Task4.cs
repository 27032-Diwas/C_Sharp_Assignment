// <copyright file="Task4.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FilesAndStreams;

using System.Text;

/// <summary>
/// Contain implementation for logger.
/// </summary>
public class Task4
{
    private static readonly object LockObject = new ();

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

        lock (LockObject)
        {
            using FileStream fileStream = new (filePath, FileMode.Append, FileAccess.Write);

            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
