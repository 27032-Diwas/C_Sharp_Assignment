using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;

/// <summary>
/// Performs read and write operations into the list (CRUD).
/// </summary>
public class TransactionRepository : IRepository
{
    private readonly List<Transaction> _transactions;
    private readonly IFileRepository _jsonFileManager;
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
    /// </summary>
    /// <param name="path"> File path. </param>
    /// <param name="fileManager"> Json file manager instance. </param>
    public TransactionRepository(string path, IFileRepository fileManager)
    {
        this._filePath = path;
        this._jsonFileManager = fileManager;
        if (!File.Exists(this._filePath))
        {
            this._transactions = new List<Transaction>();
            File.WriteAllText(this._filePath, string.Empty);
            return;
        }

        this._transactions = this._jsonFileManager.LoadAll(this._filePath);
    }

    /// <summary>
    /// Adds transaction to the transaction list.
    /// </summary>
    /// <param name="transaction"> Instance of the transaction. </param>
    public void AddTransaction(Transaction transaction)
    {
        this._transactions.Add(transaction);
    }

    /// <summary>
    /// Gets all transactions from the list.
    /// </summary>
    /// <returns> List of transactions. </returns>
    public List<Transaction> GetAllTransactions() => this._transactions.Select(transaction => transaction.Clone()).OrderBy(transaction => transaction.Date).ToList();

    /// <summary>
    /// Search transactions in list based on search word entered by user.
    /// </summary>
    /// <param name="searchWord"> Word to search in the transaction list. </param>
    /// <returns> List of transactions that contains the search word. </returns>
    public List<Transaction> SearchTransactions(string searchWord) => this._transactions.Where(transaction => transaction.Description.Contains(searchWord, StringComparison.OrdinalIgnoreCase)
                                                                      || transaction.Category.Contains(searchWord, StringComparison.OrdinalIgnoreCase)
                                                                      || transaction.Date.ToString().Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                                                                      .Select(transaction => transaction.Clone())
                                                                      .ToList();

    /// <summary>
    /// Deletes the transaction from the list.
    /// </summary>
    /// <param name="transactionId"> Transaction id of transaction to delete. </param>
    public void DeleteTransaction(Guid transactionId)
    {
        int index = this._transactions.FindIndex(t => t.TransactionId == transactionId);
        if (index >= 0)
        {
            this._transactions.RemoveAt(index);
        }
    }

    /// <summary>
    /// Deletes all transactions in the list.
    /// </summary>
    public void DeleteAllTransactions()
    {
        this._transactions.Clear();
    }

    /// <summary>
    /// Update the value of a transaction in transaction list.
    /// </summary>
    /// <param name="updatedTransaction"> Instance of transaction containing edited values. </param>
    public void EditTransaction(Transaction updatedTransaction)
    {
        Transaction transaction = this._transactions.First(existing => existing.TransactionId == updatedTransaction.TransactionId);

        transaction.Date = updatedTransaction.Date;
        transaction.Amount = updatedTransaction.Amount;
        transaction.TransactionType = updatedTransaction.TransactionType;
        transaction.Category = updatedTransaction.Category;
        transaction.Description = updatedTransaction.Description;
    }

    /// <summary>
    /// Saves the file.
    /// </summary>
    public void SaveFile()
    {
        this._jsonFileManager.WriteAll(this._filePath, this._transactions);
    }
}
