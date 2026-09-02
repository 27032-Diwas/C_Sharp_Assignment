namespace Calculator.Constants;

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
    /// Represents the message displayed when user enters second number as zero.
    /// </summary>
    public const string DivideByZero = "Second number can't be zero";

    /// <summary>
    /// Represents the message displayed when user enters an invalid number.
    /// </summary>
    public static readonly string InvalidNumber = $"ENTER A VALID NUMBER [ {int.MinValue} to {int.MaxValue} ]";
}
