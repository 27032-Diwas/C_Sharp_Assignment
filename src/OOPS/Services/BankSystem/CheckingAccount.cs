using OOPS.Constants;
using OOPS.Models;

namespace OOPS.Services.BankSystem;

/// <summary>
/// Contains methods related to saving account.
/// </summary>
public class CheckingAccount : BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
    /// </summary>
    /// <param name="name"> Account holder name. </param>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="balance"> Balance. </param>
    public CheckingAccount(string name, decimal accountNumber, decimal balance)
        : base(name, accountNumber, balance)
    {
    }

    /// <summary>
    /// Withdraw amount if balance is above minimum balance.
    /// </summary>
    /// <param name="amount"> Amount to withdraw. </param>
    /// <returns> Success or failure message.</returns>
    public override string Withdraw(decimal amount)
    {
        if (this.Balance - amount >= BankConstants.CheckingAccountMinimumThresold)
        {
            this.Balance -= amount;
            return MessageConstants.WithdrawSuccess;
        }

        return MessageConstants.CheckingAccountInsufficientBalance;
    }

    /// <summary>
    /// Displays details of account holder such as name, account number, account type, balance.
    /// </summary>
    /// <returns> Details as a string. </returns>
    public override string PrintDetails() => $"\nAccount Holder Name: {this.AccountHolderName}\nAccount Number: {this.AccountNumber}\nAccount Type: Checking Account\nBalance: {this.Balance}";
}
