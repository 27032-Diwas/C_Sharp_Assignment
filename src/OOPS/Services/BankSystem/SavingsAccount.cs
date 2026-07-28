using OOPS.Constants;
using OOPS.Models;

namespace OOPS.Services.BankSystem;

/// <summary>
/// Contains methods related to saving account.
/// </summary>
public class SavingsAccount : BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
    /// </summary>
    /// <param name="name"> Account holder name. </param>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="balance"> Balance. </param>
    /// <param name="mpin"> Mpin. </param>
    public SavingsAccount(string name, decimal accountNumber, decimal balance, decimal mpin)
        : base(name, accountNumber, balance, mpin)
    {
    }

    /// <summary>
    /// Withdraw amount if balance is above minimum balance.
    /// </summary>
    /// <param name="amount"> Amount to withdraw. </param>
    /// <returns> Success or failure message.</returns>
    public override string Withdraw(decimal amount)
    {
        if (this.Balance - amount >= BankConstants.SavingAccountMinimumBalance)
        {
            this.Balance -= amount;
            return MessageConstants.WithdrawSuccess;
        }

        return MessageConstants.SavingsAccountInsufficientBalance;
    }

    /// <summary>
    /// Displays details of account holder such as name, account number, account type, balance.
    /// </summary>
    /// <returns> Details as a string. </returns>
    public override string PrintDetails() => $"\nAccount Holder Name: {this.AccountHolderName}\nAccount Number: {this.AccountNumber}\nAccount Type: Savings Account\nBalance: {this.Balance}";
}
