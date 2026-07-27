using OOPS.Constants;

namespace OOPS.Models;

/// <summary>
/// Abstract bank account call containing account number , balance and deposit and withdraw methods.
/// </summary>
public abstract class BankAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="name"> Account holder name. </param>
    /// <param name="accountNumber"> Account number of user. </param>
    /// <param name="balance"> Balance of user. </param>
    public BankAccount(string name, decimal accountNumber, decimal balance)
    {
        this.AccountHolderName = name;
        this.AccountNumber = accountNumber;
        this.Balance = balance;
    }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Account holder name. </value>
    public string AccountHolderName { get; set; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Account number of user. </value>
    public decimal AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Balance of user. </value>
    public decimal Balance { get; set; }

    /// <summary>
    /// Deposits amount into users account.
    /// </summary>
    /// <param name="amount"> Amount to deposit. </param>
    /// <returns> Success or failure message. </returns>
    public string Deposit(decimal amount)
    {
        this.Balance += amount;
        return MessageConstants.DepositSuccess;
    }

    /// <summary>
    /// Withdraw amount from the account.
    /// </summary>
    /// <param name="amount"> Amount to withdraw. </param>
    /// <returns> success or failure message. </returns>
    public abstract string Withdraw(decimal amount);

    /// <summary>
    /// Displays details of account holder such as name, account number, balance.
    /// </summary>
    /// <returns> Details as a string. </returns>
    public abstract string PrintDetails();
}
