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

    private void AddAccount()
    {
        string? inputString = ValidInput.GetName(MessageConstants.GetAccountHolderName);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string name = inputString;

        BankAccountContent.BankAccountTypes accountType = DisplayEnum.GetMenuChoice<BankAccountContent.BankAccountTypes>(MessageConstants.BankAccountTpyes);

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
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            return;
        }
        else if (mpin.Equals(BankConstants.DefaultMpin))
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
    /// Gets valid mpin from user.
    /// </summary>
    /// <param name="accountNumber"> Account Number </param>
    /// <returns> Mpin. </returns>
    private string? GetValidMpin(decimal accountNumber)
    {
        int mpinAttempt = 3;
        string mpin = BankConstants.DefaultMpin;
        while (mpinAttempt > 0)
        {
            string? inputString = ValidInput.GetValidStringInput(MessageConstants.GetMpin);
            if (inputString is null)
            {
                Console.Clear();
                return null;
            }

            mpin = inputString;
            string message = this._bankServices.ViewContact(accountNumber, mpin);
            Console.WriteLine(message);
            if (message.Equals(MessageConstants.AccountNotFound))
            {
                return null;
            }
            else if (message.Equals(MessageConstants.WrongMpin))
            {
                mpin = BankConstants.DefaultMpin;
                mpinAttempt--;
                continue;
            }

            return mpin;
        }

        return mpin;
    }

    private void ViewAccount(decimal accountNumber)
    {
        string? inputDecimal = this.GetValidMpin(accountNumber);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }
        else if (inputDecimal.Equals(BankConstants.DefaultMpin))
        {
            Console.WriteLine("Three attempt failed");
            return;
        }

        ValidInput.GetAnyKey();
        return;
    }

    private void Deposit(decimal accountNumber)
    {
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            Console.Clear();
            return;
        }
        else if (mpin.Equals(BankConstants.DefaultMpin))
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

        decimal amount = (decimal)inputDecimal;
        Console.WriteLine(this._bankServices.Deposit(accountNumber, amount));
        ValidInput.GetAnyKey();
    }

    private void Withdraw(decimal accountNumber)
    {
        string? mpin = this.GetValidMpin(accountNumber);
        if (mpin is null)
        {
            Console.Clear();
            return;
        }
        else if (mpin.Equals(BankConstants.DefaultMpin))
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

        decimal amount = (decimal)inputDecimal;
        Console.WriteLine(this._bankServices.Withdraw(accountNumber, amount));
        ValidInput.GetAnyKey();
    }
}
