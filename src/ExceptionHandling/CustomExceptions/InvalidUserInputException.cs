namespace ExceptionHandling.CustomExceptions;

/// <summary>
/// Determine whether user entered a valid age.
/// </summary>
public class InvalidUserInputException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
    /// </summary>
    /// <param name="message"> Error message. </param>
    public InvalidUserInputException(string message)
        : base(message)
    {
    }
}
