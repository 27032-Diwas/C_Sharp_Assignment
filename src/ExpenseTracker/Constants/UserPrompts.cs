namespace ExpenseTracker.Constants;

/// <summary>
/// Contains all message prompts.
/// </summary>
public static class UserPrompts
{
    /// <summary>
    /// Represents the prompt requesting the user to select one of the available options.
    /// </summary>
    public const string SelectOption = "Select one of the above options";

    /// <summary>
    /// Represents the message prompted to get user input to exit current process.
    /// </summary>
    public const string ExitProcess = "or Exit to quit process:";

    /// <summary>
    /// Represents the prompt requesting the user to select one of the available options.
    /// </summary>
    public const string GetYesOrNo = "Do you want to choose above transaction [Y/N]";

    /// <summary>
    /// Represents the prompt requesting the user to enter yes or no to delete all transaction.
    /// </summary>
    public const string GetConformation = "Do you want to delete all transactions [Y/N]";

    /// <summary>
    /// Represents the prompt requesting the user to press any key to continue.
    /// </summary>
    public const string GetAnyKey = "PRESS ANY KEY TO CONTINUE!!";

    /// <summary>
    /// Represents the prompt requesting the user to enter transaction date.
    /// </summary>
    public const string GetDate = "Enter transaction date [DD-MM-YYYY]";

    /// <summary>
    /// Represents the prompt requesting the user to enter transaction category.
    /// </summary>
    public const string GetCategory = "Enter transaction category";

    /// <summary>
    /// Represents the prompt requesting the user to enter transaction description.
    /// </summary>
    public const string GetDescription = "Enter transaction description";

    /// <summary>
    /// Represents the message prompted to get word to search.
    /// </summary>
    public const string GetSearchWord = "Enter word to search transaction";

    /// <summary>
    /// Represents the prompt requesting the user to enter the serial number.
    /// </summary>
    public const string SelectSerialNumber = "Enter a serial number";

    /// <summary>
    /// Represents the prompt requesting the user to enter transaction amount.
    /// </summary>
    public static readonly string GetAmount = $"Enter transaction amount [ {Configurables.MinimumAmountThreshold} - {Configurables.MaxAmountThreshold} ]";
}
