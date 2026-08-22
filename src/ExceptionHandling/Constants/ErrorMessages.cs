namespace ExceptionHandling.Constants;

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
    /// Represents the message displayed when user enters an invalid number.
    /// </summary>
    public const string InvalidNumber = "ENTER A VALID NUMBER";

    /// <summary>
    /// Represents the message displayed when user enters denominator as zero.
    /// </summary>
    public const string DivideByZero = "Denomination can't be zero.";

    /// <summary>
    /// Represents the message displayed when user enters an invalid string.
    /// </summary>
    public const string InvalidString = "ENTER A VALUE";

    /// <summary>
    /// Represents the message displayed when user enters index out of range.
    /// </summary>
    public const string InvalidIndex = "Index out of range";

    /// <summary>
    /// Represents the message displayed when user enters invalid age.
    /// </summary>
    public const string InvalidAge = "Age should be a positive value";

    /// <summary>
    /// Represents the message displayed when unhandled exception occur.
    /// </summary>
    public const string InvalidMessage = "Something went wrong, Try Again.";
}
