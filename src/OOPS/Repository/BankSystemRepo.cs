using OOPS.Constants;
using OOPS.Models;

namespace OOPS.Repository;

/// <summary>
/// Contains methods to work with list (CRUD).
/// </summary>
public class BankSystemRepo
{
    private readonly List<BankAccount> _accounts = new ();

    /// <summary>
    /// Add account to the list.
    /// </summary>
    /// <param name="account"> Account details as an object. </param>
    public void AddAccount(BankAccount account) => this._accounts.Add(account);

    /// <summary>
    /// Get account details by account number.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="mpin"> Mpin. </param>
    /// <returns> Account object. </returns>
    public string ViewAccount(decimal accountNumber, string mpin)
    {
        BankAccount? account = this.GetAccount(accountNumber);
        if (account == null)
        {
            return MessageConstants.AccountNotFound;
        }

        if (!mpin.Equals(account.MPin))
        {
            return MessageConstants.WrongMpin;
        }

        return account.PrintDetails();
    }

    /// <summary>
    /// Deposit amount into account.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="amount"> Amount to deposit. </param>
    /// <param name="message"> Success or error message</param>
    public void Deposit(decimal accountNumber, decimal amount, out string message)
    {
        BankAccount? account = this.GetAccount(accountNumber);
        if (account == null)
        {
            message = MessageConstants.AccountNotFound;
            return;
        }

        message = account.Deposit(amount);
    }

    /// <summary>
    /// Get account detials by account number.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <returns> Account object. </returns>
    public BankAccount? GetAccount(decimal accountNumber)
    {
        foreach (var account in this._accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }

        return null;
    }

    /// <summary>
    /// Withdraw amount into account.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="amount"> Amount to deposit. </param>
    /// <param name="message"> Success or error message</param>
    public void Withdraw(decimal accountNumber, decimal amount, out string message)
    {
        BankAccount? account = this.GetAccount(accountNumber);
        if (account == null)
        {
            message = MessageConstants.AccountNotFound;
            return;
        }

        message = account.Withdraw(amount);
    }
}
