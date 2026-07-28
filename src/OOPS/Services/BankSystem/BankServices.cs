using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Repository;

namespace OOPS.Services.BankSystem;

/// <summary>
/// Contains all the methods connecting view, repository and accounts.
/// </summary>
public class BankServices
{
    /// <summary>
    /// Starting account number of customer.
    /// </summary>
    private static decimal accountNumber = 1000000001;

    private readonly BankSystemRepo _bankSystemRepo;

    /// <summary>
    /// Initializes a new instance of the <see cref="BankServices"/> class.
    /// </summary>
    /// <param name="bankSystemRepo"> Link to repo </param>
    public BankServices(BankSystemRepo bankSystemRepo)
    {
        this._bankSystemRepo = bankSystemRepo;
    }

    /// <summary>
    /// Add account to the list.
    /// </summary>
    /// <param name="name"> Account holder name. </param>
    /// <param name="amount"> Account number. </param>
    /// <param name="accountType"> Account type. </param>
    /// <param name="mpin"> Mpin. </param>
    /// <returns> Sucess or failure message. </returns>
    public string AddAccount(string name, decimal amount, BankAccountContent.BankAccountTypes? accountType, string mpin)
    {
        if (Validation.IsValidName(name) is false)
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

        if (accountType == BankAccountContent.BankAccountTypes.CheckingAccount)
        {
            CheckingAccount currentAccount = new (name, accountNumber, amount, mpin);
            accountNumber += 1;
            this._bankSystemRepo.AddAccount(currentAccount);
            return $"{MessageConstants.AccountAddedSuccessfully}\n{this._bankSystemRepo.ViewAccount(accountNumber - 1, mpin)}";
        }

        if (amount < BankConstants.SavingAccountMinimumBalance)
        {
            return MessageConstants.LessThanMinimumBalance;
        }

        SavingsAccount savingsAccount = new (name, accountNumber, amount, mpin);
        accountNumber += 1;
        this._bankSystemRepo.AddAccount(savingsAccount);

        return $"{MessageConstants.AccountAddedSuccessfully}\n{this._bankSystemRepo.ViewAccount(accountNumber - 1, mpin)}";
    }

    /// <summary>
    /// Get details from repository.
    /// </summary>
    /// <param name="accountNumber"> Account Number. </param>
    /// <param name="mpin"> Mpin. </param>
    /// <returns> Details as a string. </returns>
    public string ViewContact(decimal accountNumber, string mpin)
    {
        return this._bankSystemRepo.ViewAccount(accountNumber, mpin);
    }

    /// <summary>
    /// Deposit amount into account.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="amount">Amount to deposit. </param>
    /// <returns> Success message. </returns>
    public string Deposit(decimal accountNumber, decimal amount)
    {
        return this._bankSystemRepo.Deposit(accountNumber, amount);
    }

    /// <summary>
    /// Withdraw amount into account.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <param name="amount">Amount to deposit. </param>
    /// <returns> Success message. </returns>
    public string Withdraw(decimal accountNumber, decimal amount)
    {
        return this._bankSystemRepo.Withdraw(accountNumber, amount);
    }
}
