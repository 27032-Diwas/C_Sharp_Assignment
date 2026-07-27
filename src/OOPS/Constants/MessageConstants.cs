namespace OOPS.Constants;

/// <summary>
/// Contains strings that are repeatedly used.
/// </summary>
public static class MessageConstants
{
    /// <summary>
    /// Prompt requesting the user to select one of the available options.
    /// </summary>
    public const string SelectOption = "Select one of the below options:";

    /// <summary>
    /// Message displayed when the application process ends.
    /// </summary>
    public const string ProcessEnded = "END PROCESS!!";

    /// <summary>
    /// Header message for main menu.
    /// </summary>
    public const string MainMenu = "MAIN MENU";

    /// <summary>
    /// Header message for shape menu.
    /// </summary>
    public const string ShapeMenu = "SHAPE MENU";

    /// <summary>
    /// Header message for employee menu.
    /// </summary>
    public const string EmployeeMenu = "EMPLOYEE MENU";

    /// <summary>
    /// Header message for bank systme menu.
    /// </summary>
    public const string BankSystemMenu = "BANK SYSTEM MENU";

    /// <summary>
    /// Message displayed when the user enters an invalid menu option.
    /// </summary>
    public const string InvalidOption = "ENTER A VALID OPTION!!";

    /// <summary>
    /// Prompt requesting the user to enter rectangle length.
    /// </summary>
    public const string GetRectangleLength = "Enter length of rectangle(20 or 20.5) or Exit to quit process: ";

    /// <summary>
    /// Message displayed when the input is not double.
    /// </summary>
    public const string InvalidDoubleInput = "ENTERED VALUE IS NOT A NUMBER!!";

    /// <summary>
    /// Prompt requesting the user to enter any key.
    /// </summary>
    public const string GetAnyKey = "PRESS ANY KEY TO CONTINUE!!";

    /// <summary>
    /// Message displayed when the input is not string.
    /// </summary>
    public const string InvalidStringInput = "ENTER A VAILD INPUT!!";

    /// <summary>
    /// Message displayed when the account is not found.
    /// </summary>
    public const string AccountNotFound = "ACCOUNT NOT FOUND!!";

    /// <summary>
    /// Message displayed when the input is an invalid account number.
    /// </summary>
    public const string InvalidAccountNumber = "ACCOUNT NUMBER SHOULD BE A 10 DIGIT NUMBER!!";

    /// <summary>
    /// Message displayed when the input is not a color.
    /// </summary>
    public const string InvalidColor = "ENTER A VALID COLOR!!";

    /// <summary>
    /// Prompt requesting the user to enter rectangle witdth.
    /// </summary>
    public const string GetRectangleWidth = "Enter width of rectangle or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter circle radius.
    /// </summary>
    public const string GetCircleRadius = "Enter radius of circle(in cm) or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter color.
    /// </summary>
    public const string GetColor = "Enter a color or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter employee name.
    /// </summary>
    public const string GetEmployeeName = "Enter name of employee or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter employee salary.
    /// </summary>
    public const string GetEmployeeSalary = "Enter salary of employee(in Rs) or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter account holder name.
    /// </summary>
    public const string GetAccountHolderName = "Enter name of account holder or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter amount value to deposit.
    /// </summary>
    public const string GetAmonutDeposit = "Enter amount to deposit(is Rs) or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter amount value to withdraw.
    /// </summary>
    public const string GetAmonutWithdraw = "Enter amount to withdraw(is Rs) or Exit to quit process: ";

    /// <summary>
    /// Prompt requesting the user to enter account number.
    /// </summary>
    public const string GetAccountNumber = "Enter account number or Exit to quit process: ";

    /// <summary>
    /// Message displayed when the deposit is successful.
    /// </summary>
    public const string DepositSuccess = "DEPOSITED SUCCESSFULLY!!";

    /// <summary>
    /// Message displayed when the withdrawal is successful.
    /// </summary>
    public const string WithdrawSuccess = "WITHDRAWAL SUCCESSFULLY!!";

    /// <summary>
    /// Message displayed when the account name contains fewer than two characters.
    /// </summary>
    public const string NameTooShort = "NAME SHOULD CONTAIN AT LEAST 2 CHARACTERS AND CONTAINS ONE ALPHABETES!!!";

    /// <summary>
    /// Message displayed when the amount value is negative.
    /// </summary>
    public const string NegativeValue = "AMOUNT SHOULD NOT BE A NEGATIVE VALUE!!!";

    /// <summary>
    /// Message displayed when a account is added successfully.
    /// </summary>
    public const string AccountAddedSuccessfully = "ACCOUNT ADDED SUCCESSFULLY!!!";

    /// <summary>
    /// Message displayed when the amount is less than minimum balance.
    /// </summary>
    public static readonly string LessThanMinimumBalance = $"SAVINGS ACCOUNT SHOULD MAINTAIN Rs.{BankConstants.SavingAccountMinimumBalance} MINIMUM BALANCE!!!";

    /// <summary>
    /// Message displayed when the balance is insufficient in savings account.
    /// </summary>
    public static readonly string SavingsAccountInsufficientBalance = $"INSUFFICIENT BALANCE. SAVINGS ACCOUNT SHOULD MAINTAIN Rs.{BankConstants.SavingAccountMinimumBalance} MINIMUM BALANCE";

    /// <summary>
    /// Message displayed when the balance is insufficient in checking account.
    /// </summary>
    public static readonly string CheckingAccountInsufficientBalance = $"INSUFFICIENT BALANCE. CHECKING ACCOUNT BALANCE SHOULD NOT GO BELOW Rs.{BankConstants.CheckingAccountMinimumThresold}";
}
