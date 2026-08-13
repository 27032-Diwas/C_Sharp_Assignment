using System.Transactions;

namespace ExpenseTracker.Service;

/// <summary>
/// Interface for service layer containing add, view, search, delete and update transaction.
/// </summary>
public interface IService
{
    /// <summary>
    /// Adds transaction to transaction list.
    /// </summary>
    /// <param name="transaction"> Instance of transaction to add. </param>
    void AddTransaction(Transaction transaction);

    /// <summary>
    /// Gets all transactions from the list.
    /// </summary>
    /// <returns> List of transactions. </returns>
    List<Transaction> GetAllTransactions();

    /// <summary>
    /// Search transaction list for transaction containing search word.
    /// </summary>
    /// <param name="searchWord"> Word to search in transaction list. </param>
    /// <returns> List of transactions containing search word. </returns>
    List<Transaction> SearchTransaction(string searchWord);

    /// <summary>
    /// Deletes the transaction from the transaction list.
    /// </summary>
    /// <param name="transactionId"> Transaction id of transaction to delete. </param>
    void DeleteTransaction(Guid transactionId);

    /// <summary>
    /// Update the value of transaction in transaction list.
    /// </summary>
    /// <param name="transaction"> Instance of transaction containing updated values. </param>
    void EditTransaction(Transaction transaction);

    /// <summary>
    /// Gets summary of all transaction.
    /// </summary>
    /// <returns> Summary as string. </returns>
    string GetSummary();
}
