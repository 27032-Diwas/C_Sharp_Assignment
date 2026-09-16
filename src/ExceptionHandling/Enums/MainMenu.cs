namespace ExceptionHandling.Enums;

/// <summary>
/// Contains main menu options.
/// </summary>
public enum MainMenu
{
    /// <summary>
    /// Represents the option to exit the application.
    /// </summary>
    Exit,

    /// <summary>
    /// Represents the option to access divide by zero exception task.
    /// </summary>
    DivideByZeroException,

    /// <summary>
    /// Represents the option to access index out of range exception task.
    /// </summary>
    IndexOutOfRange,

    /// <summary>
    /// Represents the option to access custom exception task.
    /// </summary>
    CustomException,

    /// <summary>
    /// Represents the option to access unhandled exception task.
    /// </summary>
    UnhandledException,

    /// <summary>
    /// Represents the option to access exception stack trace.
    /// </summary>
    ExceptionStackTrace,
}
