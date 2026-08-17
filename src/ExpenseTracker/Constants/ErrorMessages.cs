namespace ExpenseTracker.Constants;

/// <summary>
/// Contains all error messages.
/// </summary>
public class ErrorMessages
{
    /// <summary>
    /// Represents the message displayed when user enters an invalid option.
    /// </summary>
    public const string InvalidOption = "ENTER A VALID OPTION";

    /// <summary>
    /// Represents the message displayed when user enters an invalid string.
    /// </summary>
    public const string InvalidString = "ENTER A VALUE";

    /// <summary>
    /// Represents the message displayed when user enters an invalid number.
    /// </summary>
    public const string InvalidDigit = "ENTER A VALID NUMBER";

    /// <summary>
    /// Represents the message displayed when no transaction found in list.
    /// </summary>
    public const string EmptyList = "NO TRANSACTIONS FOUND";

    /// <summary>
    /// Represents the message displayed when no transaction match during search.
    /// </summary>
    public const string EmptySearchList = "NO MATCH FOUND";

    /// <summary>
    /// Represents the message displayed when user enters an invalid amount.
    /// </summary>
    public const string InvalidAmount = "AMOUNT SHOULD BE POSITIVE AND LESS THAN 100000000";

    /// <summary>
    /// Represents the message displayed when user enters an invalid date.
    /// </summary>
    public const string InvalidDate = "ENTER A VALID DATE";

    /// <summary>
    /// Represents the message displayed when user enter an invalid category.
    /// </summary>
    public const string InvalidCategory = "CATEGORY SHOULD BE LESS THAN 50 CHARACTERS.";

    /// <summary>
    /// Represents the message displayed when user enter an invalid description.
    /// </summary>
    public const string InvalidDescription = "DESCRIPTION SHOULD BE LESS THAN 100 CHARACTERS.";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid serial number.
    /// </summary>
    public const string InvalidSerialNumber = "SERIAL NUMBER SHOULD BE WITHIN THE RANGE";
}
