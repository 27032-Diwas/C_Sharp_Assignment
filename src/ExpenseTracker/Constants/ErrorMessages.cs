namespace ExpenseTracker.Constants;

/// <summary>
/// Contains all error messages.
/// </summary>
public static class ErrorMessages
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
    public const string InvalidNumber = "ENTER A VALID NUMBER";

    /// <summary>
    /// Represents the message displayed when user does not enter anything in date.
    /// </summary>
    public const string EmptyDate = "DATE SHOULD NOT BE EMPTY";

    /// <summary>
    /// Represents the message displayed when no transaction found in list.
    /// </summary>
    public const string EmptyList = "NO TRANSACTIONS FOUND";

    /// <summary>
    /// Represents the message displayed when no transaction match during search.
    /// </summary>
    public const string EmptySearchList = "NO MATCH FOUND";

    /// <summary>
    /// Represents the message displayed when user enters an invalid date.
    /// </summary>
    public const string InvalidDate = "DATE SHOULD BE IN FORMAT OF DD-MM-YYYY";

    /// <summary>
    /// Represents the message displayed when user enter an invalid category.
    /// </summary>
    public const string InvalidCategory = "CATEGORY SHOULD BE LESS THAN 50 CHARACTERS AND ONLY CONTAIN ALPHABETS.";

    /// <summary>
    /// Represents the message displayed when user enter an invalid description.
    /// </summary>
    public const string InvalidDescription = "DESCRIPTION SHOULD BE LESS THAN 100 CHARACTERS AND ONLY CONTAIN ALPHABETS.";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid serial number.
    /// </summary>
    public const string InvalidSerialNumber = "SERIAL NUMBER SHOULD BE WITHIN THE RANGE";

    /// <summary>
    /// Represents the message displayed when the user enters a future date.
    /// </summary>
    public const string FutureDate = "DATE SHOULD NOT BE IN FUTURE";

    /// <summary>
    /// Represents the message displayed when user enters an invalid amount.
    /// </summary>
    public static readonly string InvalidAmount = $"AMOUNT SHOULD BE POSITIVE AND LESS THAN {Configurables.MaxAmountThreshold}";
}
