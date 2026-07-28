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
        if (account != null)
        {
            if (!mpin.Equals(account.MPin))
            {
                return MessageConstants.WrongMpin;
            }

            return account.PrintDetails();
        }

        return MessageConstants.AccountNotFound;
    }

    /// <summary>
    /// Deposit amount into account.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="amount">amount to deposit. </param>
    /// <returns> Success message. </returns>
    public string Deposit(decimal accountNumber, decimal amount)
    {
        BankAccount? account = this.GetAccount(accountNumber);
        if (account != null)
        {
            return account.Deposit(amount);
        }

        return MessageConstants.AccountNotFound;
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
    /// <param name="amount">amount to deposit. </param>
    /// <returns> Success or failure message. </returns>
    public string Withdraw(decimal accountNumber, decimal amount)
    {
        BankAccount? account = this.GetAccount(accountNumber);
        if (account != null)
        {
            return account.Withdraw(amount);
        }

        return MessageConstants.AccountNotFound;
    }
}
