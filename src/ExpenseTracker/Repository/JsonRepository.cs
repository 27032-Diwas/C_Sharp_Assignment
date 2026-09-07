using System.IO.Abstractions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;

/// <summary>
/// Writes and reads data in json file.
/// </summary>
public class JsonRepository : IFileRepository
{
    private readonly JsonSerializerOptions _options;
    private readonly IFileSystem _fileSystem;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonRepository"/> class.
    /// </summary>
    /// <param name="fileSystem"> Instance of file system. </param>
    public JsonRepository(IFileSystem fileSystem)
    {
        this._fileSystem = fileSystem;
        this._options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
        };
    }

    /// <summary>
    /// Writes all the transactions into the file.
    /// </summary>
    /// <param name="filePath"> The path of the file where the transactions are stored. </param>
    /// <param name="list"> List of the transactions that are to be added. </param>
    public void WriteAll(string filePath, List<Transaction> list)
    {
        using Stream stream = this._fileSystem.File.Open(filePath, FileMode.Open, FileAccess.Write);
        JsonSerializer.Serialize(stream, list, this._options);
    }

    /// <summary>
    /// Reads all the transaction from the file.
    /// </summary>
    /// <param name="filePath"> Path of the file. </param>
    /// <returns> List of transactions that are stored in the file. </returns>
    /// <exception cref="JsonException"> Exception thrown when file is not read properly. </exception>
    public List<Transaction> LoadAll(string filePath)
    {
        try
        {
            using Stream stream = this._fileSystem.File.Open(filePath, FileMode.Open, FileAccess.Read);
            return JsonSerializer.Deserialize<List<Transaction>>(stream, this._options) ?? new List<Transaction>();
        }
        catch (JsonException ex)
        {
            throw new JsonException($"Failed in loading file, Try again.{ex.Message}", ex);
        }
    }
}
