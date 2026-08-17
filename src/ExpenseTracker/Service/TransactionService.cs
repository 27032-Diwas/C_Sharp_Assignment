using ExpenseTracker.Constants;
using ExpenseTracker.Enums;
using ExpenseTracker.Helper;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service;

/// <summary>
/// Provides service such as add, view, search, edit and delete transactions.
/// </summary>
public class TransactionService : IService
{
    private readonly IRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionService"/> class.
    /// </summary>
    /// <param name="repository"> Instance of repository. </param>
    public TransactionService(IRepository repository)
    {
        this._repository = repository;
    }

    /// <summary>
    /// Adds transaction to transaction list.
    /// </summary>
    /// <param name="date"> Date of transaction. </param>
    /// <param name="amount"> Amount transferred in the transaction. </param>
    /// <param name="category"> Transfer category. </param>
    /// <param name="transactionType"> Type of transaction. </param>
    /// <param name="description"> Transaction description. </param>
    /// <returns> Success or failure message. </returns>
    public string AddTransaction(DateTime date, decimal amount, string category, TransactionTypes transactionType, string description)
    {
        if (!Validation.IsValidAmount(amount))
        {
            return ErrorMessages.InvalidAmount;
        }

        if (!Validation.IsValidCategory(category))
        {
            return ErrorMessages.InvalidCategory;
        }

        if (!Validation.IsValidDescription(description))
        {
            return ErrorMessages.InvalidDescription;
        }

        this._repository.AddTransaction(new Transaction()
        {
            TransactionId = Guid.NewGuid(),
            Date = date,
            Amount = amount,
            Category = category,
            TransactionType = transactionType,
            Description = description,
        });

        return SuccessMessages.SuccessfulAdditionOfTransaction;
    }

    /// <summary>
    /// Gets all transactions from the list.
    /// </summary>
    /// <returns> List of transactions. </returns>
    public List<Transaction> GetAllTransactions()
    {
        return this._repository.GetAllTransactions();
    }

    /// <summary>
    /// Search transaction list for transaction containing search word.
    /// </summary>
    /// <param name="searchWord"> Word to search in transaction list. </param>
    /// <returns> List of transactions containing search word. </returns>
    public List<Transaction> SearchTransaction(string searchWord)
    {
        return this._repository.SearchTransactions(searchWord.Trim());
    }

    /// <summary>
    /// Deletes the transaction from the transaction list.
    /// </summary>
    /// <param name="transactionId"> Transaction id of transaction to delete. </param>
    public void DeleteTransaction(Guid transactionId)
    {
        this._repository.DeleteTransaction(transactionId);
    }

    /// <summary>
    /// Update the value of transaction in transaction list.
    /// </summary>
    /// <param name="transaction"> Instance of transaction containing updated values. </param>
    /// <returns> Success or failure message. </returns>
    public string EditTransaction(Transaction transaction)
    {
        if (!Validation.IsValidAmount(transaction.Amount))
        {
            return ErrorMessages.InvalidAmount;
        }

        if (!Validation.IsValidCategory(transaction.Category))
        {
            return ErrorMessages.InvalidCategory;
        }

        if (!Validation.IsValidDescription(transaction.Description))
        {
            return ErrorMessages.InvalidDescription;
        }

        this._repository.EditTransaction(transaction);
        return SuccessMessages.SuccessfullyUpdatedTheTransaction;
    }

    /// <summary>
    /// Gets summary of all transaction.
    /// </summary>
    /// <returns> Summary as string. </returns>
    public string GetSummary()
    {
        List<Transaction> transactions = this.GetAllTransactions();
        return $"Total Expense: {this.CalculateExpense(transactions)}\nTotal Income: {this.CalculateIncome(transactions)}";
    }

    private decimal CalculateIncome(List<Transaction> transactions)
    {
        return transactions.Where(transaction => transaction.TransactionType.Equals(TransactionTypes.Income))
            .Sum(transaction => transaction.Amount);
    }

    private decimal CalculateExpense(List<Transaction> transactions)
    {
        return transactions.Where(transaction => transaction.TransactionType.Equals(TransactionTypes.Expense))
            .Sum(transaction => transaction.Amount);
    }
}
