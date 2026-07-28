using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Repository;
using OOPS.Services.BankSystem;

namespace OOPS.View;

/// <summary>
/// Contains methods related to bank system.
/// </summary>
public class BankSystem
{
    private readonly BankSystemRepo _bankSystemRepo;
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
    /// Get bank system menu choice from user.
    /// </summary>
    public void GetMenuOption()
    {
        bool isValidMenuOption = true;

        while (isValidMenuOption)
        {
            DisplayMenu();

            Console.WriteLine(MessageConstants.SelectOption);
            var isParsed = Enum.TryParse<MenuContent.BankSystemMenu>(Console.ReadLine(), true, out MenuContent.BankSystemMenu choice);
            if (!isParsed || !Enum.IsDefined(typeof(MenuContent.BankSystemMenu), choice))
            {
                Console.Clear();
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

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
    /// Displays bank system menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine(MessageConstants.BankSystemMenu);
        DisplayEnum.DisplayMenu(typeof(MenuContent.BankSystemMenu));
    }

    private void AddAccount()
    {
        string? inputString = ValidInput.GetName(MessageConstants.GetAccountHolderName);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string name = inputString;
        BankAccountContent.BankAccountTypes accountType = default;
        bool isValidMenuOption = true;

        while (isValidMenuOption)
        {
            Console.WriteLine(MessageConstants.SelectOption);
            DisplayEnum.DisplayMenu(typeof(BankAccountContent.BankAccountTypes));
            var isParsed = Enum.TryParse<BankAccountContent.BankAccountTypes>(Console.ReadLine(), true, out accountType);
            if (!isParsed || !Enum.IsDefined(typeof(BankAccountContent.BankAccountTypes), accountType))
            {
                Console.Clear();
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

            break;
        }

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

        decimal amount = (decimal)inputDecimal;

        inputDecimal = ValidInput.GetAmount(MessageConstants.GetMpin);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal mpin = (decimal)inputDecimal;
        string message = this._bankServices.AddAccount(name, amount, accountType, mpin);
        Console.WriteLine(message);
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Display options for existing account to perform opertations like view, deposit and withdraw.
    /// </summary>
    private void ExistingAccount()
    {
        decimal? inputDecimal = ValidInput.GetAccountNumber(MessageConstants.GetAccountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal accountNumber = (decimal)inputDecimal;
        inputDecimal = this.GetValidMpin(accountNumber);
        if (inputDecimal is null)
        {
            return;
        }
        else if (inputDecimal == 0)
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        decimal mpin = (decimal)inputDecimal;

        bool isValidMenuOption = true;

        while (isValidMenuOption)
        {
            DisplayEnum.DisplayMenu(typeof(MenuContent.AccountMenu));

            Console.WriteLine(MessageConstants.SelectOption);
            var isParsed = Enum.TryParse<MenuContent.AccountMenu>(Console.ReadLine(), true, out MenuContent.AccountMenu choice);
            if (!isParsed || !Enum.IsDefined(typeof(MenuContent.AccountMenu), choice))
            {
                Console.Clear();
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

            Console.Clear();
            switch (choice)
            {
                case MenuContent.AccountMenu.Back:
                    return;
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
    /// Gets valid mpin from user.
    /// </summary>
    /// <param name="accountNumber"> Account Number </param>
    /// <returns> Mpin. </returns>
    private decimal? GetValidMpin(decimal accountNumber)
    {
        int mpinAttempt = 3;
        decimal mpin = 0;
        while (mpinAttempt > 0)
        {
            decimal? inputDecimal = ValidInput.GetMpin(MessageConstants.GetMpin);
            if (inputDecimal is null)
            {
                Console.Clear();
                return null;
            }

            mpin = (decimal)inputDecimal;
            string message = this._bankServices.ViewContact(accountNumber, mpin);
            Console.WriteLine(message);
            if (message == MessageConstants.InvalidMpin)
            {
                mpin = 0;
                mpinAttempt--;
                continue;
            }

            return null;
        }

        return mpin;
    }

    private void Deposit(decimal accountNumber)
    {
        decimal? inputDecimal = this.GetValidMpin(accountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }
        else if (inputDecimal == 0)
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        decimal mpin = (decimal)inputDecimal;
        string message = this._bankServices.ViewContact(accountNumber, mpin);

        inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmonutDeposit);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = (decimal)inputDecimal;
        Console.WriteLine(this._bankServices.Deposit(accountNumber, amount));
        ValidInput.GetAnyKey();
    }

    private void Withdraw(decimal accountNumber)
    {
        decimal? inputDecimal = this.GetValidMpin(accountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }
        else if (inputDecimal == 0)
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        decimal mpin = (decimal)inputDecimal;
        string message = this._bankServices.ViewContact(accountNumber, mpin);
        Console.WriteLine(message);
        if (message == MessageConstants.AccountNotFound)
        {
            Console.Clear();
            return;
        }

        inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmonutWithdraw);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = (decimal)inputDecimal;
        Console.WriteLine(this._bankServices.Withdraw(accountNumber, amount));
        ValidInput.GetAnyKey();
    }
}
