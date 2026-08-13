using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;

/// <summary>
/// Performs read and write operations into the list (CRUD).
/// </summary>
public class Repository : IRepository
{
    private readonly List<Transaction> _transactions = new ();

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
    public List<Transaction> GetAllTransactions()
    {
        return this._transactions.Select(transaction => transaction.Clone()).ToList();
    }

    /// <summary>
    /// Search transactions in list based on search word entered by user.
    /// </summary>
    /// <param name="searchWord"> Word to search in the transaction list. </param>
    /// <returns> List of transactions that contains the search word. </returns>
    public List<Transaction> SearchTransactions(string searchWord)
    {
        return this._transactions.Where(transaction => transaction.Description.Contains(searchWord, StringComparison.OrdinalIgnoreCase)
                                 || transaction.Category.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                                 .Select(transaction => transaction.Clone())
                                 .ToList();
    }

    /// <summary>
    /// Deletes the transaction from the list.
    /// </summary>
    /// <param name="transactionId"> Transaction id of transaction to delete. </param>
    public void DeleteTransaction(Guid transactionId)
    {
        foreach (Transaction transaction in this._transactions)
        {
            if (transaction.TransactionId.Equals(transactionId))
            {
                this._transactions.Remove(transaction);
                break;
            }
        }
    }

    /// <summary>
    /// Update the value of a transaction in transaction list.
    /// </summary>
    /// <param name="updatedTransaction"> Instance of transaction containing edited values. </param>
    public void EditTransaction(Transaction updatedTransaction)
    {
        foreach (Transaction transaction in this._transactions)
        {
            if (transaction.TransactionId.Equals(updatedTransaction.TransactionId))
            {
                transaction.Date = updatedTransaction.Date;
                transaction.Amount = updatedTransaction.Amount;
                transaction.Category = updatedTransaction.Category;
                transaction.Description = updatedTransaction.Description;
                break;
            }
        }
    }
}
