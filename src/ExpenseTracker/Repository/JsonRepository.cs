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

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonRepository"/> class.
    /// </summary>
    public JsonRepository()
    {
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
        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonSerializer.Serialize(list, this._options);
        string encodedJson = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
        using FileStream fileStream = new (filePath, FileMode.Create, FileAccess.Write);
        using StreamWriter writer = new (fileStream);
        writer.Write(encodedJson);
    }

    /// <summary>
    /// Reads all the transaction from the file.
    /// </summary>
    /// <param name="filePath"> Path of the file. </param>
    /// <returns> List of transactions that are stored in the file. </returns>
    public List<Transaction> LoadAll(string filePath)
    {
        try
        {
            using FileStream fileStream = new (filePath, FileMode.Open, FileAccess.Read);
            using StreamReader reader = new (fileStream);
            string encodedJson = reader.ReadToEnd();
            string json = Encoding.UTF8.GetString(Convert.FromBase64String(encodedJson));
            return JsonSerializer.Deserialize<List<Transaction>>(json, this._options) ?? new List<Transaction>();
        }
        catch (JsonException)
        {
            return new List<Transaction>();
        }
    }
}
