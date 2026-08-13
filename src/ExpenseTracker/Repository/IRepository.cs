using System.Transactions;

namespace ExpenseTracker.Repository;

/// <summary>
/// Interface for repository layer containing CRUD operations.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Adds transaction to the transaction list.
    /// </summary>
    /// <param name="transaction"> Instance of the transaction. </param>
    void AddTransaction(Transaction transaction);

    /// <summary>
    /// Gets all transactions from the list.
    /// </summary>
    /// <returns> List of transactions. </returns>
    List<Transaction> GetAllTransactions();

    /// <summary>
    /// Search transactions in list based on search word entered by user.
    /// </summary>
    /// <param name="searchWord"> Word to search in the transaction list. </param>
    /// <returns> List of transactions that contains the search word. </returns>
    List<Transaction> SearchTransactions(string searchWord);

    /// <summary>
    /// Deletes the transaction from the list.
    /// </summary>
    /// <param name="transaction"> Instance of transaction to delete. </param>
    void DeleteTransaction(Transaction transaction);

    /// <summary>
    /// Update the value of a transaction in transaction list.
    /// </summary>
    /// <param name="transaction"> Instance of transaction containing edited values. </param>
    void EditTransaction(Transaction transaction);
}
