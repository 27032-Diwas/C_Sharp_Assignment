using OOPS.Constants;
using OOPS.Models;

namespace OOPS.Services.BankSystem;

/// <summary>
/// Contains methods related to savings accounts.
/// </summary>
public class SavingsAccount : BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
    /// </summary>
    /// <param name="name"> The name of the account holder. </param>
    /// <param name="accountNumber"> The account number. </param>
    /// <param name="balance"> The account balance. </param>
    /// <param name="mpin"> The MPIN associated with the account. </param>
    public SavingsAccount(string name, decimal accountNumber, decimal balance, string mpin)
        : base(name, accountNumber, balance, mpin)
    {
    }

    /// <summary>
    /// Deposits the specified amount into the account.
    /// </summary>
    /// <param name="amount"> The amount to deposit. </param>
    /// <returns>
    /// A message indicating the result of the deposit operation.
    /// </returns>
    public override string Deposit(decimal amount)
    {
        this.Balance += amount;
        return MessageConstants.DepositSuccess;
    }

    /// <summary>
    /// Withdraws the specified amount from the account if the minimum balance requirement is maintained.
    /// </summary>
    /// <param name="amount"> The amount to withdraw. </param>
    /// <returns>
    /// A message indicating the result of the withdrawal operation.
    /// </returns>
    public override string Withdraw(decimal amount)
    {
        if (this.Balance - amount >= BankConfigurables.SavingAccountMinimumBalance)
        {
            this.Balance -= amount;
            return MessageConstants.WithdrawSuccess;
        }

        return MessageConstants.SavingsAccountInsufficientBalance;
    }

    /// <summary>
    /// Returns the account details, including the account holder name, account number, account type, and balance.
    /// </summary>
    /// <returns>
    /// A string containing the account details.
    /// </returns>
    public override string PrintDetails() => $"\nAccount Holder Name: {this.AccountHolderName}\nAccount Number: {this.AccountNumber}\nAccount Type: Savings Account\nBalance: {this.Balance}\n";
}
