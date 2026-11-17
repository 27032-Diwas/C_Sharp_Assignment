using DisplayApp;
using GreetingsApp;
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
        Greet greet = new Greet();
        consoleWriter.WriteColored($"{greet.MorningGreet("Diwas")}\n", ConsoleColor.Green);
        consoleWriter.WriteColored($"{greet.AfternoonGreet("Diwas")}\n", ConsoleColor.Blue);
        consoleWriter.WriteColored($"{greet.EveningGreet("Diwas")}\n", ConsoleColor.Yellow);
        consoleWriter.WriteColored($"{greet.NightGreet("Diwas")}\n", ConsoleColor.DarkGray);
        terminator.Terminate();
    }
}