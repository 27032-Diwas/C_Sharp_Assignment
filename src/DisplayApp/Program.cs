using DisplayApp;
using UtilityApp;

namespace Assignments;

/// <summary>
/// Program is the entry class of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts and execute the application.
    /// </summary>
    public static void Main()
    {
        Terminator terminator = new Terminator();
        ConsoleWriter consoleWriter = new ConsoleWriter();

        consoleWriter.WriteColored("This is a success message\n", ConsoleColor.Green);
        consoleWriter.WriteColored("This is a warning message\n", ConsoleColor.Yellow);
        consoleWriter.WriteColored("This is an error message\n", ConsoleColor.Red);
        terminator.Terminate();
    }
}