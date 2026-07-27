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
                case MenuContent.BankSystemMenu.ViewAccount:
                    this.ViewAccount();
                    break;
                case MenuContent.BankSystemMenu.Deposit:
                    this.Deposit();
                    break;
                case MenuContent.BankSystemMenu.Withdraw:
                    this.Withdraw();
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
        string message = this._bankServices.AddAccount(name, amount, accountType);
        Console.WriteLine(message);
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    private void ViewAccount()
    {
        decimal? inputDecimal = ValidInput.GetAccountNumber(MessageConstants.GetAccountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal accountNumber = (decimal)inputDecimal;
        Console.WriteLine(this._bankServices.ViewContact(accountNumber));
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    private void Deposit()
    {
        decimal? inputDecimal;
        inputDecimal = ValidInput.GetAccountNumber(MessageConstants.GetAccountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal accountNumber = (decimal)inputDecimal;
        string message = this._bankServices.ViewContact(accountNumber);
        if (message == MessageConstants.AccountNotFound)
        {
            Console.WriteLine(message);
            return;
        }

        inputDecimal = ValidInput.GetAmount(MessageConstants.GetAmonutDeposit);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal amount = (decimal)inputDecimal;
        Console.WriteLine(this._bankServices.Deposit(accountNumber, amount));
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    private void Withdraw()
    {
        decimal? inputDecimal;
        inputDecimal = ValidInput.GetAccountNumber(MessageConstants.GetAccountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal accountNumber = (decimal)inputDecimal;
        string message = this._bankServices.ViewContact(accountNumber);
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
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }
}
