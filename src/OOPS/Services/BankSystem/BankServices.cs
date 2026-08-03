using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Repository;

namespace OOPS.Services.BankSystem;

/// <summary>
/// Provides methods for managing bank accounts and coordinating interactions between the repository and the user interface.
/// </summary>
public class BankServices
{
    /// <summary>
    /// Represents the starting account number assigned to new accounts.
    /// </summary>
    private static string accountNumber = "ACC000001";

    private readonly BankSystemRepo _bankSystemRepo;

    /// <summary>
    /// Initializes a new instance of the <see cref="BankServices"/> class.
    /// </summary>
    /// <param name="bankSystemRepo"> The repository used to manage bank account data. </param>
    public BankServices(BankSystemRepo bankSystemRepo)
    {
        this._bankSystemRepo = bankSystemRepo;
    }

    /// <summary>
    /// Adds a new bank account.
    /// </summary>
    /// <param name="name"> The name of the account holder. </param>
    /// <param name="amount"> The initial account balance. </param>
    /// <param name="accountType"> The type of account to create. </param>
    /// <param name="mpin"> The MPIN for the account. </param>
    /// <returns>
    /// A message indicating the result of the account creation operation.
    /// </returns>
    public string AddAccount(string name, decimal amount, BankAccountDetails.BankAccountTypes? accountType, string mpin)
    {
        if (!Validation.IsValidName(name))
        {
            return MessageConstants.NameTooShort;
        }
        else if (!Validation.IsValidAmount(amount))
        {
            return MessageConstants.NegativeValue;
        }
        else if (!Validation.IsValidMpin(mpin))
        {
            return MessageConstants.InvalidMpin;
        }

        if (accountType == BankAccountDetails.BankAccountTypes.CheckingAccount)
        {
            CheckingAccount currentAccount = new (name, accountNumber, amount, mpin);
            this._bankSystemRepo.AddAccount(currentAccount);
            string checkingAccountDetails = $"{MessageConstants.AccountAddedSuccessfully}\n{this._bankSystemRepo.ViewAccount(accountNumber, mpin)}";
            IncrementAccountNumber();
            return checkingAccountDetails;
        }

        if (amount < BankConfigurable.SavingAccountMinimumBalance)
        {
            return MessageConstants.LessThanMinimumBalance;
        }

        SavingsAccount savingsAccount = new (name, $"{accountNumber}", amount, mpin);
        this._bankSystemRepo.AddAccount(savingsAccount);
        string savingAccountDetails = $"{MessageConstants.AccountAddedSuccessfully}\n{this._bankSystemRepo.ViewAccount(accountNumber, mpin)}";
        IncrementAccountNumber();
        return savingAccountDetails;
    }

    /// <summary> 
    /// Retrieves the details of an account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    /// <param name="mpin"> The MPIN associated with the account. </param>
    /// <returns>
    /// A string containing the account details or an appropriate status message.
    /// </returns>
    public string ViewAccount(string accountNumber, string mpin) => this._bankSystemRepo.ViewAccount(accountNumber, mpin);

    /// <summary>
    /// Deposits an amount into the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    /// <param name="amount"> The amount to deposit. </param>
    /// <returns>
    /// A message indicating the result of the deposit operation.
    /// </returns>
    public string Deposit(string accountNumber, decimal amount)
    {
        this._bankSystemRepo.Deposit(accountNumber, amount, out string message);
        return message;
    }

    /// <summary>
    /// Withdraws an amount from the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    /// <param name="amount"> The amount to withdraw. </param>
    /// <returns>
    /// A message indicating the result of the withdrawal operation.
    /// </returns>
    public string Withdraw(string accountNumber, decimal amount)
    {
        this._bankSystemRepo.Withdraw(accountNumber, amount, out string message);
        return message;
    }

    private static void IncrementAccountNumber()
    {
        int number = int.Parse(accountNumber[3..]);
        number++;

        accountNumber = $"ACC{number:D6}";
    }
}
