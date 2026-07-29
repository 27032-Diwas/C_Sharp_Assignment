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
    /// <param name="mpin"> Mpin. </param>
    public BankAccount(string name, decimal accountNumber, decimal balance, string mpin)
    {
        this.AccountHolderName = name;
        this.AccountNumber = accountNumber;
        this.Balance = balance;
        this.MPin = mpin;
    }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Account holder name. </value>
    public string AccountHolderName { get; set; }

    /// <summary>
    /// Gets or init.
    /// </summary>
    /// <value> Account number of user. </value>
    public decimal AccountNumber { get; private init; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Balance of user. </value>
    public decimal Balance { get; set; }

    /// <summary>
    /// Gets or init.
    /// </summary>
    /// <value> MPIN value. </value>
    public string MPin { get; private init; }

    /// <summary>
    /// Deposits the specified amount into the account.
    /// </summary>
    /// <param name="amount"> The amount to deposit. </param>
    /// <returns>
    /// A message indicating whether the deposit operation was successful.
    /// </returns>
    public abstract string Deposit(decimal amount);

    /// <summary>
    /// Withdraws the specified amount from the account.
    /// </summary>
    /// <param name="amount"> The amount to withdraw. </param>
    /// <returns>
    /// A message indicating whether the withdrawal operation was successful.
    /// </returns>
    public abstract string Withdraw(decimal amount);

    /// <summary>
    /// Returns the account holder details, including the account holder name, account number, and account balance.
    /// </summary>
    /// <returns>
    /// A string containing the account details.
    /// </returns>
    public abstract string PrintDetails();
}
