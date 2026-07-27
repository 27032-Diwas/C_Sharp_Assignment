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
    /// <returns> Sucess or failure message. </returns>
    public string AddAccount(string name, decimal amount, BankAccountContent.BankAccountTypes? accountType)
    {
        if (Validation.IsValidName(name) is false)
        {
            return MessageConstants.NameTooShort;
        }
        else if (!Validation.IsValidAmount(amount))
        {
            return MessageConstants.NegativeValue;
        }

        if (accountType == BankAccountContent.BankAccountTypes.CheckingAccount)
        {
            CheckingAccount currentAccount = new (name, accountNumber, amount);
            accountNumber += 1;
            this._bankSystemRepo.AddAccount(currentAccount);
            return $"{MessageConstants.AccountAddedSuccessfully}\n{this._bankSystemRepo.ViewAccount(accountNumber - 1)}";
        }

        if (amount < BankConstants.SavingAccountMinimumBalance)
        {
            return MessageConstants.LessThanMinimumBalance;
        }

        SavingsAccount savingsAccount = new (name, accountNumber, amount);
        accountNumber += 1;
        this._bankSystemRepo.AddAccount(savingsAccount);

        return $"{MessageConstants.AccountAddedSuccessfully}\n{this._bankSystemRepo.ViewAccount(accountNumber - 1)}";
    }

    /// <summary>
    /// Get details from repository.
    /// </summary>
    /// <param name="accountNumber"> Account Number. </param>
    /// <returns> Details as a string. </returns>
    public string ViewContact(decimal accountNumber)
    {
        return this._bankSystemRepo.ViewAccount(accountNumber);
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
