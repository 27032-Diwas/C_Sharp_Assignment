using ExpenseTracker.Constants;
using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace ExpenseTracker.Controller;

/// <summary>
/// Controller coordinating between view and service.
/// </summary>
public class TransactionController : IController
{
    private readonly IView _transactionView;
    private readonly IService _transactionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionController"/> class.
    /// </summary>
    /// <param name="transactionView"> Instance of transaction view. </param>
    /// <param name="transactionService"> Instance of transaction service. </param>
    public TransactionController(IView transactionView, IService transactionService)
    {
        this._transactionView = transactionView;
        this._transactionService = transactionService;
    }

    /// <summary>
    /// Adds transaction to transaction list.
    /// </summary>
    public void AddTransaction()
    {
        TransactionTypes transactionType = this._transactionView.GetMenuChoice<TransactionTypes>(HeaderMessages.TransactionTypes);
        if (transactionType is TransactionTypes.Back)
        {
            return;
        }

        this._transactionView.ClearConsole();
        DateTime? date = this._transactionView.GetDate();
        if (date is null)
        {
            return;
        }

        decimal? amount = this._transactionView.GetAmount();
        if (amount is null)
        {
            return;
        }

        string? category = this._transactionView.GetCategory();
        if (category is null)
        {
            return;
        }

        string? description = this._transactionView.GetDescription();
        if (description is null)
        {
            return;
        }

        string message = this._transactionService.AddTransaction(date.Value, amount.Value, category, transactionType, description);
        if (message.Equals(SuccessMessages.SuccessfulAdditionOfTransaction))
        {
            this._transactionView.DisplaySuccessMessage(message);
        }
        else
        {
            this._transactionView.DisplayErrorMessage(message);
        }
    }

    /// <summary>
    /// Gets all transactions from the list.
    /// </summary>
    public void GetAllTransactions()
    {
        List<Transaction> transactions = this._transactionService.GetAllTransactions();
        if (!transactions.Any())
        {
            this._transactionView.DisplayMessage(ErrorMessages.EmptyList);
            return;
        }

        this._transactionView.DisplayTransactions(transactions);
    }

    /// <summary>
    /// Search transaction list for transaction containing search word.
    /// </summary>
    /// <returns> List of transactions containing search word. </returns>
    public List<Transaction>? SearchTransaction()
    {
        string? searchWord = this._transactionView.GetStringInput(UserPrompts.GetSearchWord);
        if (searchWord is null)
        {
            return null;
        }

        List<Transaction> transactions = this._transactionService.SearchTransactions(searchWord);
        if (!transactions.Any())
        {
            this._transactionView.DisplayMessage($"\n{ErrorMessages.EmptyList}");
            return null;
        }

        this._transactionView.DisplayTransactions(transactions);
        return transactions;
    }

    /// <summary>
    /// Deletes the transaction from the transaction list.
    /// </summary>
    public void DeleteTransaction()
    {
        Transaction? transactions = this.GetTransaction();
        if (transactions is null)
        {
            return;
        }

        this._transactionService.DeleteTransaction(transactions.TransactionId);
        this._transactionView.ClearConsole();
        this._transactionView.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfTransaction);
    }

    /// <summary>
    /// Deletes all transactions in the list.
    /// </summary>
    public void DeleteAllTransactions()
    {
        this._transactionService.DeleteAllTransactions();
        this._transactionView.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfAllTransaction);
    }

    /// <summary>
    /// Update the value of transaction in transaction list.
    /// </summary>
    public void EditTransaction()
    {
        Transaction? transaction = this.GetTransaction();
        if (transaction is null)
        {
            return;
        }

        transaction = this.GetNewValues(transaction);
        if (transaction is null)
        {
            return;
        }

        string message = this._transactionService.EditTransaction(transaction);
        if (message.Equals(SuccessMessages.SuccessfullyUpdatedTheTransaction))
        {
            this._transactionView.DisplaySuccessMessage(message);
        }
        else
        {
            this._transactionView.DisplayErrorMessage(message);
        }
    }

    /// <summary>
    /// Gets summary of all transaction.
    /// </summary>
    public void GetSummary()
    {
        this._transactionView.DisplaySummary(this._transactionService.GetSummary());
    }

    /// <summary>
    /// Gets instance of transaction to update or delete.
    /// </summary>
    /// <returns> Instance of transaction. </returns>
    private Transaction? GetTransaction()
    {
        List<Transaction>? transactions = this.SearchTransaction();
        if (transactions is null)
        {
            return null;
        }
        else if (transactions.Count == 1)
        {
            string? choice;
            while (true)
            {
                choice = this._transactionView.GetStringInput(UserPrompts.GetYesOrNo);
                if (choice is null || choice.ToUpper().Equals("N") || choice.ToUpper().Equals("NO"))
                {
                    this._transactionView.DisplayMessage($"\n{SuccessMessages.ProcessCancelled}");
                    return null;
                }
                else if (!(choice.ToUpper().Equals("Y") || choice.ToUpper().Equals("YES")))
                {
                    this._transactionView.DisplayMessage(ErrorMessages.InvalidOption);
                    continue;
                }

                break;
            }

            return transactions[0];
        }

        while (true)
        {
            int? serialNo = this._transactionView.GetIntegerInput($"{UserPrompts.SelectSerialNumber} [ 1 - {transactions.Count} ]");
            if (serialNo is null)
            {
                return null;
            }

            if (serialNo > transactions.Count || serialNo < 1)
            {
                this._transactionView.DisplayErrorMessage($"{ErrorMessages.InvalidSerialNumber} [ 1 - {transactions.Count} ]");
                continue;
            }

            return transactions[serialNo.Value - 1];
        }
    }

    private Transaction? GetNewValues(Transaction transaction)
    {
        TransactionFields transactionField = this._transactionView.GetMenuChoice<TransactionFields>(HeaderMessages.EditableFields);
        switch (transactionField)
        {
            case TransactionFields.Back:
                this._transactionView.DisplayMessage(SuccessMessages.ProcessCancelled);
                return null;
            case TransactionFields.TransactionDate:
                DateTime? date = this._transactionView.GetDate();
                if (date is null)
                {
                    return null;
                }

                transaction.Date = date.Value;
                break;
            case TransactionFields.TransactionAmount:
                decimal? amount = this._transactionView.GetAmount();
                if (amount is null)
                {
                    return null;
                }

                transaction.Amount = amount.Value;
                break;
            case TransactionFields.TransactionCategory:
                string? category = this._transactionView.GetCategory();
                if (category is null)
                {
                    return null;
                }

                transaction.Category = category;
                break;
            case TransactionFields.TransactionType:
                TransactionTypes transactionType = this._transactionView.GetMenuChoice<TransactionTypes>(HeaderMessages.TransactionTypes);
                if (transactionType is TransactionTypes.Back)
                {
                    return null;
                }

                transaction.TransactionType = transactionType;
                break;
            case TransactionFields.TransactionDescription:
                string? description = this._transactionView.GetDescription();
                if (description is null)
                {
                    return null;
                }

                transaction.Description = description;
                break;
            default:
                this._transactionView.DisplayErrorMessage(ErrorMessages.InvalidOption);
                break;
        }

        return transaction;
    }
}