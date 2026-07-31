namespace OOPS.Constants;

/// <summary>
/// Contains strings that are repeatedly used.
/// </summary>
public static class MessageConstants
{
    /// <summary>
    /// Represents the prompt requesting the user to select one of the available options.
    /// </summary>
    public const string SelectOption = "\nSelect one of the above options:";

    /// <summary>
    /// Represents the message displayed when the application process ends.
    /// </summary>
    public const string ApplicationExit = "THANK YOU FOR USING THIS APPLICATION!!";

    /// <summary>
    /// Represents the header message for the main menu.
    /// </summary>
    public const string MainMenu = "\nMAIN MENU\n";

    /// <summary>
    /// Represents the header message for the shape menu.
    /// </summary>
    public const string ShapeMenu = "\nSHAPE MENU\n";

    /// <summary>
    /// Represents the header message for the employee menu.
    /// </summary>
    public const string EmployeeMenu = "\nEMPLOYEE MENU\n";

    /// <summary>
    /// Represents the header message for the bank system menu.
    /// </summary>
    public const string BankSystemMenu = "\nBANK SYSTEM MENU\n";

    /// <summary>
    /// Represents the header message for the bank account types menu.
    /// </summary>
    public const string BankAccountTypes = "\nBANK ACCOUNT TYPES\n";

    /// <summary>
    /// Represents the header message for the account functionality menu.
    /// </summary>
    public const string AccountFunctionality = "\nACCOUNT FUNCTIONALITY\n";

    /// <summary>
    /// Represents the message displayed when the user enters an invalid menu option.
    /// </summary>
    public const string InvalidOption = "ENTER A VALID OPTION!!";

    /// <summary>
    /// Represents the message prompted to get the rectangle length from the user.
    /// </summary>
    public const string GetRectangleLength = "Enter length of rectangle or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message displayed when the entered value is not a valid number.
    /// </summary>
    public const string InvalidDoubleInput = "ENTERED VALUE IS NOT A NUMBER!!";

    /// <summary>
    /// Represents the prompt requesting the user to press any key to continue.
    /// </summary>
    public const string GetAnyKey = "\nPRESS ANY KEY TO CONTINUE!!";

    /// <summary>
    /// Represents the message displayed when the entered value is not a valid string.
    /// </summary>
    public const string InvalidStringInput = "ENTER A VAILD INPUT!!";

    /// <summary>
    /// Represents the message displayed when the account cannot be found.
    /// </summary>
    public const string AccountNotFound = "ACCOUNT NOT FOUND!!";

    /// <summary>
    /// Represents the message displayed when all MPIN verification attempts have failed.
    /// </summary>
    public const string MpinAttemptFailed = "ACCOUNT NOT FOUND!!";

    /// <summary>
    /// Represents the message displayed when the entered account number is invalid.
    /// </summary>
    public const string InvalidAccountNumber = "ENTER A VALID ACCOUNT NUMBER!!";

    /// <summary>
    /// Represents the message displayed when the entered color is invalid.
    /// </summary>
    public const string InvalidColor = "ENTER A VALID COLOR!!";

    /// <summary>
    /// Represents the message displayed when the entered MPIN is invalid.
    /// </summary>
    public const string InvalidMpin = "MPIN should be 4 digit number!!";

    /// <summary>
    /// Represents the message displayed when the entered MPIN does not match.
    /// </summary>
    public const string WrongMpin = "Wrong MPIN!!";

    /// <summary>
    /// Represents the message prompted to get the rectangle width from the user.
    /// </summary>
    public const string GetRectangleWidth = "Enter width of rectangle or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the circle radius from the user.
    /// </summary>
    public const string GetCircleRadius = "Enter radius of circle or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get a color from the user.
    /// </summary>
    public const string GetColor = "Enter a color or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the employee name from the user.
    /// </summary>
    public const string GetEmployeeName = "Enter name of employee or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the employee salary from the user.
    /// </summary>
    public const string GetEmployeeSalary = "Enter salary of employee(in Rs) or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the account holder name from the user.
    /// </summary>
    public const string GetAccountHolderName = "Enter name of account holder or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the deposit amount from the user.
    /// </summary>
    public const string GetAmonutDeposit = "Enter amount to deposit(in Rs) or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the withdrawal amount from the user.
    /// </summary>
    public const string GetAmonutWithdraw = "Enter amount to withdraw(in Rs) or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the account number from the user.
    /// </summary>
    public const string GetAccountNumber = "Enter account number or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message prompted to get the MPIN from the user.
    /// </summary>
    public const string GetMpin = "Enter MPIN or Exit/[0] to quit process: ";

    /// <summary>
    /// Represents the message displayed when a deposit operation completes successfully.
    /// </summary>
    public const string DepositSuccess = "DEPOSITED SUCCESSFULLY!!";

    /// <summary>
    /// Represents the message displayed when a withdrawal operation completes successfully.
    /// </summary>
    public const string WithdrawSuccess = "WITHDRAWAL SUCCESSFULLY!!";

    /// <summary>
    /// Represents the message displayed when the account holder name is too short.
    /// </summary>
    public const string NameTooShort = "NAME SHOULD CONTAIN AT LEAST 2 CHARACTERS AND CONTAINS ONE ALPHABETES!!!";

    /// <summary>
    /// Represents the message displayed when the entered amount is negative.
    /// </summary>
    public const string NegativeValue = "AMOUNT SHOULD NOT BE A NEGATIVE VALUE!!!";

    /// <summary>
    /// Represents the message displayed when an account is added successfully.
    /// </summary>
    public const string AccountAddedSuccessfully = "ACCOUNT ADDED SUCCESSFULLY!!!";

    /// <summary>
    /// Represents the message displayed when the account balance is less than the required minimum balance.
    /// </summary>
    public static readonly string LessThanMinimumBalance = $"SAVINGS ACCOUNT SHOULD MAINTAIN Rs.{BankConfigurables.SavingAccountMinimumBalance} MINIMUM BALANCE!!!";

    /// <summary>
    /// Represents the message displayed when a savings account has insufficient balance.
    /// </summary>
    public static readonly string SavingsAccountInsufficientBalance = $"INSUFFICIENT BALANCE. SAVINGS ACCOUNT SHOULD MAINTAIN Rs.{BankConfigurables.SavingAccountMinimumBalance} MINIMUM BALANCE";

    /// <summary>
    /// Represents the message displayed when a checking account has insufficient balance.
    /// </summary>
    public static readonly string CheckingAccountInsufficientBalance = $"INSUFFICIENT BALANCE. CHECKING ACCOUNT BALANCE SHOULD NOT GO BELOW Rs.{BankConfigurables.CheckingAccountMinimumThreshold}";
}