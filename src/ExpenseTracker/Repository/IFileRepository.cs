using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;

/// <summary>
/// Interface for file repository containing read and write operations.
/// </summary>
public interface IFileRepository
{
    /// <summary>
    /// Writes all the transactions into the file.
    /// </summary>
    /// <param name="filePath"> The path of the file where the transactions are stored. </param>
    /// <param name="list"> List of the transactions that are to be added. </param>
    public void WriteAll(string filePath, List<Transaction> list);

    /// <summary>
    /// Reads all the transactions from the file.
    /// </summary>
    /// <param name="filePath"> Path of the file. </param>
    /// <returns> List of transactions that are stored in the file. </returns>
    public List<Transaction> LoadAll(string filePath);
}
