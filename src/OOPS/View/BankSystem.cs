using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Repository;
using OOPS.Services.BankSystem;

namespace OOPS.View;

/// <summary>
/// Provides functionality for managing bank system operations.
/// </summary>
public class BankSystem
{
    /// <summary>
    /// Repository used to manage bank account data.
    /// </summary>
    private readonly BankSystemRepo _bankSystemRepo;

    /// <summary>
    /// Service used to perform bank account operations.
    /// </summary>
    private readonly BankServices _bankServices;

    /// <summary>
    /// Initializes a new instance of the <see cref="BankSystem"/> class.
    /// </summary>
    public BankSystem()
    {
        this._bankSystemRepo = new BankSystemRepo();
        this._bankServices = new BankServices(this._bankSystemRepo);
    }

    /// <summary>
    /// Displays the bank system menu and processes the selected option.
    /// </summary>
    public void GetMenuOption()
    {
        while (true)
        {
            BankSystemMenu choice = DisplayEnum.GetMenuChoice<BankSystemMenu>(MessageConstants.BankSystemMenu);

            Console.Clear();
            switch (choice)
            {
                case BankSystemMenu.Back:
                    return;
                case BankSystemMenu.AddAccount:
                    this.AddAccount();
                    break;
                case BankSystemMenu.ExistingAccount:
                    this.ExistingAccount();
                    break;
            }
        }
    }

    /// <summary>
    /// Collects account details from the user and creates a new account.
    /// </summary>
    private void AddAccount()
    {
        BankAccountTypes accountType = DisplayEnum.GetMenuChoice<BankAccountTypes>(MessageConstants.BankAccountTypes);

        if (accountType == BankAccountTypes.Back)
        {
            Console.Clear();
            return;
        }

        Console.Clear();
        string? inputString = ValidInput.GetName(MessageConstants.GetAccountHolderName);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string name = inputString;

        inputString = ValidInput.GetMpin(MessageConstants.GetMpin);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string mpin = inputString;

        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmountDeposit);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = inputDecimal.Value;
        string message = this._bankServices.AddAccount(name, amount, accountType, mpin);
        Console.WriteLine(message);
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Displays the available operations for an existing account.
    /// </summary>
    private void ExistingAccount()
    {
        string? inputDecimal = ValidInput.GetAccountNumber(MessageConstants.GetAccountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        string accountNumber = inputDecimal;
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            return;
        }
        else if (mpin.Equals(MessageConstants.MpinAttemptFailed))
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        while (true)
        {
            AccountMenu choice = DisplayEnum.GetMenuChoice<AccountMenu>(MessageConstants.AccountFunctionality);
            Console.Clear();
            switch (choice)
            {
                case AccountMenu.Back:
                    return;
                case AccountMenu.ViewAccount:
                    this.ViewAccount(accountNumber);
                    break;
                case AccountMenu.Deposit:
                    this.Deposit(accountNumber);
                    break;
                case AccountMenu.Withdraw:
                    this.Withdraw(accountNumber);
                    break;
            }
        }
    }

    /// <summary>
    /// Gets a valid MPIN for the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    /// <returns>
    /// The validated MPIN, null if the operation is cancelled, or a failure indicator when the maximum number of attempts is exceeded.
    /// </returns>
    private string? GetValidMpin(string accountNumber)
    {
        int mpinAttempt = 3;
        string? mpin;
        while (mpinAttempt > 0)
        {
            Console.WriteLine(MessageConstants.GetMpin);
            string? inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString))
            {
                mpinAttempt--;
                Console.WriteLine($"Wrong MPIN!! {mpinAttempt} attempt left.");
                continue;
            }

            if (Enum.TryParse(inputString, true, out Exit choice) && Enum.IsDefined(typeof(Exit), choice))
            {
                return null;
            }

            mpin = inputString;
            string message = this._bankServices.ViewAccount(accountNumber, mpin);
            if (message.Equals(MessageConstants.AccountNotFound))
            {
                Console.WriteLine(message);
                return null;
            }
            else if (message.Equals(MessageConstants.WrongMpin))
            {
                mpinAttempt--;
                Console.WriteLine($"{message} {mpinAttempt} attempt left.");
                continue;
            }

            return mpin;
        }

        return MessageConstants.MpinAttemptFailed;
    }

    /// <summary>
    /// Displays the details of the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    private void ViewAccount(string accountNumber)
    {
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            Console.Clear();
            return;
        }
        else if (mpin.Equals(MessageConstants.MpinAttemptFailed))
        {
            return;
        }

        Console.WriteLine(this._bankServices.ViewAccount(accountNumber, mpin));
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Deposits an amount into the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    private void Deposit(string accountNumber)
    {
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            Console.Clear();
            return;
        }
        else if (mpin.Equals(MessageConstants.MpinAttemptFailed))
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmountDeposit);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = inputDecimal.Value;
        Console.WriteLine(this._bankServices.Deposit(accountNumber, amount));
        Console.WriteLine(this._bankServices.ViewAccount(accountNumber, mpin));
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Withdraws an amount from the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    private void Withdraw(string accountNumber)
    {
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            Console.Clear();
            return;
        }
        else if (mpin.Equals(MessageConstants.MpinAttemptFailed))
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmountWithdraw);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = inputDecimal.Value;
        Console.WriteLine(this._bankServices.Withdraw(accountNumber, amount));
        Console.WriteLine(this._bankServices.ViewAccount(accountNumber, mpin));
        ValidInput.GetAnyKey();
    }
}
