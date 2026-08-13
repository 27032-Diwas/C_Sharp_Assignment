using System.Transactions;

namespace ExpenseTracker.Controller;

/// <summary>
/// Interface for controller layer containing add, view, search, delete and update transaction.
/// </summary>
public interface IController
{
    /// <summary>
    /// Adds transaction to transaction list.
    /// </summary>
    void AddTransaction();

    /// <summary>
    /// Gets all transactions from the list.
    /// </summary>
    void GetAllTransactions();

    /// <summary>
    /// Search transaction list for transaction containing search word.
    /// </summary>
    /// <returns> List of transactions containing search word. </returns>
    List<Transaction> SearchTransaction();

    /// <summary>
    /// Deletes the transaction from the transaction list.
    /// </summary>
    void DeleteTransaction();

    /// <summary>
    /// Update the value of transaction in transaction list.
    /// </summary>
    void EditTransaction();

    /// <summary>
    /// Gets summary of all transaction.
    /// </summary>
    void GetSummary();
}
