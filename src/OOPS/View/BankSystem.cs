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
            MenuContent.BankSystemMenu choice = DisplayEnum.GetMenuChoice<MenuContent.BankSystemMenu>(MessageConstants.BankSystemMenu);

            Console.Clear();
            switch (choice)
            {
                case MenuContent.BankSystemMenu.Back:
                    return;
                case MenuContent.BankSystemMenu.AddAccount:
                    this.AddAccount();
                    break;
                case MenuContent.BankSystemMenu.ExistingAccount:
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
        string? inputString = ValidInput.GetName(MessageConstants.GetAccountHolderName);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string name = inputString;

        BankAccountContent.BankAccountTypes accountType = DisplayEnum.GetMenuChoice<BankAccountContent.BankAccountTypes>(MessageConstants.BankAccountTypes);

        if (accountType == BankAccountContent.BankAccountTypes.Exit)
        {
            Console.Clear();
            return;
        }

        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmonutDeposit);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = inputDecimal.Value;

        inputString = ValidInput.GetMpin(MessageConstants.GetMpin);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string mpin = inputString;
        string message = this._bankServices.AddAccount(name, amount, accountType, mpin);
        Console.WriteLine(message);
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Displays the available operations for an existing account.
    /// </summary>
    private void ExistingAccount()
    {
        decimal? inputDecimal = ValidInput.GetAccountNumber(MessageConstants.GetAccountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal accountNumber = inputDecimal.Value;
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
            MenuContent.AccountMenu choice = DisplayEnum.GetMenuChoice<MenuContent.AccountMenu>(MessageConstants.AccountFunctionality);
            Console.Clear();
            switch (choice)
            {
                case MenuContent.AccountMenu.Back:
                    return;
                case MenuContent.AccountMenu.ViewAccount:
                    this.ViewAccount(accountNumber);
                    break;
                case MenuContent.AccountMenu.Deposit:
                    this.Deposit(accountNumber);
                    break;
                case MenuContent.AccountMenu.Withdraw:
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
    private string? GetValidMpin(decimal accountNumber)
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
                continue;
            }

            if (Enum.TryParse(inputString, true, out MenuContent.Exit choice) && Enum.IsDefined(typeof(MenuContent.Exit), choice))
            {
                return null;
            }

            mpin = inputString;
            string message = this._bankServices.ViewAccount(accountNumber, mpin);
            Console.WriteLine(message);
            if (message.Equals(MessageConstants.AccountNotFound))
            {
                return null;
            }
            else if (message.Equals(MessageConstants.WrongMpin))
            {
                mpinAttempt--;
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
    private void ViewAccount(decimal accountNumber)
    {
        string? inputDecimal = this.GetValidMpin(accountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }
        else if (inputDecimal.Equals(MessageConstants.MpinAttemptFailed))
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Deposits an amount into the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    private void Deposit(decimal accountNumber)
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

        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmonutDeposit);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = inputDecimal.Value;
        Console.WriteLine(this._bankServices.Deposit(accountNumber, amount));
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Withdraws an amount from the specified account.
    /// </summary>
    /// <param name="accountNumber"> The account number. </param>
    private void Withdraw(decimal accountNumber)
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

        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmonutWithdraw);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = inputDecimal.Value;
        Console.WriteLine(this._bankServices.Withdraw(accountNumber, amount));
        ValidInput.GetAnyKey();
    }
}
