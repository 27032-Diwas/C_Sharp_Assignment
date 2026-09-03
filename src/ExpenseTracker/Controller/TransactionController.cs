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
        TransactionTypes transactionType = this._transactionView.GetMenuChoice<TransactionTypes>(HeaderMessages.TransactionTypes, $"\n{UserPrompts.SelectOption} [ 1 - 2 ] {UserPrompts.ExitProcess}");

        this._transactionView.ClearConsole();
        DateTime date = this._transactionView.GetDate();
        decimal amount = this._transactionView.GetAmount();
        string category = this._transactionView.GetCategory();
        string description = this._transactionView.GetDescription();
        string message = this._transactionService.AddTransaction(date, amount, category, transactionType, description);
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
    public List<Transaction> SearchTransaction()
    {
        if (this.IsEmptyList())
        {
            return new List<Transaction>();
        }

        string searchWord = this._transactionView.GetStringInput(UserPrompts.GetSearchWord);

        List<Transaction> transactions = this._transactionService.SearchTransactions(searchWord);
        if (!transactions.Any())
        {
            this._transactionView.DisplayMessage($"\n{ErrorMessages.EmptyList}");
            return transactions;
        }

        this._transactionView.DisplayTransactions(transactions);
        return transactions;
    }

    /// <summary>
    /// Deletes the transaction from the transaction list.
    /// </summary>
    public void DeleteTransaction()
    {
        List<Transaction> transactions = this.SearchTransaction();
        if (!transactions.Any())
        {
            return;
        }

        Transaction transaction = transactions[0];
        if (transactions.Count() > 1)
        {
            transaction = this.GetTransaction(transactions);
        }

        if (!this.GetConfirmation(UserPrompts.GetYesOrNo))
        {
            throw new OperationCanceledException();
        }

        this._transactionService.DeleteTransaction(transaction.TransactionId);
        this._transactionView.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfTransaction);
    }

    /// <summary>
    /// Deletes all transactions in the list.
    /// </summary>
    public void DeleteAllTransactions()
    {
        if (this.IsEmptyList())
        {
            return;
        }

        if (!this.GetConfirmation(UserPrompts.GetConformation))
        {
            throw new OperationCanceledException();
        }

        this._transactionService.DeleteAllTransactions();
        this._transactionView.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfAllTransaction);
    }

    /// <summary>
    /// Update the value of transaction in transaction list.
    /// </summary>
    public void EditTransaction()
    {
        List<Transaction>? transactions = this.SearchTransaction();
        if (!transactions.Any())
        {
            return;
        }

        Transaction transaction = transactions[0];
        if (transactions.Count() > 1)
        {
            transaction = this.GetTransaction(transactions);
        }

        if (!this.GetConfirmation(UserPrompts.GetYesOrNo))
        {
            throw new OperationCanceledException();
        }

        transaction = this.GetNewValue(transaction);

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
        if (this.IsEmptyList())
        {
            return;
        }

        this._transactionView.DisplaySummary(this._transactionService.GetSummary());
    }

    /// <summary>
    /// Saves the data.
    /// </summary>
    public void SaveData()
    {
        this._transactionService.SaveData();
    }

    /// <summary>
    /// Check whether list contain any transaction or not.
    /// </summary>
    /// <returns> True if list is empty; otherwise false. </returns>
    private bool IsEmptyList()
    {
        List<Transaction> transactions = this._transactionService.GetAllTransactions();
        if (!transactions.Any())
        {
            this._transactionView.DisplayMessage(ErrorMessages.EmptyList);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets instance of transaction to update or delete.
    /// </summary>
    /// <returns> Instance of transaction. </returns>
    private Transaction GetTransaction(List<Transaction> transactions)
    {
        while (true)
        {
            int serialNo = this._transactionView.GetIntegerInput($"{UserPrompts.SelectSerialNumber} [ 1 - {transactions.Count} ]");
            if (serialNo > transactions.Count || serialNo < 1)
            {
                this._transactionView.DisplayErrorMessage($"{ErrorMessages.InvalidSerialNumber} [ 1 - {transactions.Count} ]");
                continue;
            }

            return transactions[serialNo - 1];
        }
    }

    /// <summary>
    /// Gets new value for transaction to update.
    /// </summary>
    /// <param name="transaction"> Instance of transaction. </param>
    /// <returns> Instance of new transaction with updated value. </returns>
    private Transaction GetNewValue(Transaction transaction)
    {
        TransactionFields transactionField = this._transactionView.GetMenuChoice<TransactionFields>($"\n{HeaderMessages.EditableFields}", $"\n{UserPrompts.SelectOption} [ 1 - {Configurables.MaxEditableFieldRange} ] {UserPrompts.ExitProcess}");
        switch (transactionField)
        {
            case TransactionFields.TransactionDate:
                transaction.Date = this._transactionView.GetDate();
                break;
            case TransactionFields.TransactionAmount:
                transaction.Amount = this._transactionView.GetAmount();
                break;
            case TransactionFields.TransactionCategory:
                transaction.Category = this._transactionView.GetCategory();
                break;
            case TransactionFields.TransactionType:
                transaction.TransactionType = this._transactionView.GetMenuChoice<TransactionTypes>(HeaderMessages.TransactionTypes, $"\n{UserPrompts.SelectOption} [ 1 - 2 ] {UserPrompts.ExitProcess}");
                break;
            case TransactionFields.TransactionDescription:
                transaction.Description = this._transactionView.GetDescription();
                break;
            default:
                this._transactionView.DisplayErrorMessage(ErrorMessages.InvalidOption);
                break;
        }

        return transaction;
    }

    /// <summary>
    /// Gets input from user to confirm transaction selection.
    /// </summary>
    /// <param name="message"> Message displayed to user to get input. </param>
    /// <returns> True if user confirm; otherwise false. </returns>
    private bool GetConfirmation(string message)
    {
        string? choice;
        while (true)
        {
            choice = this._transactionView.GetStringInput(message);
            if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else if (!choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                this._transactionView.DisplayErrorMessage(ErrorMessages.InvalidOption);
                continue;
            }

            return true;
        }
    }
}