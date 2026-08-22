using ExceptionHandling.Constants;
using ExceptionHandling.Enums;
using ExceptionHandling.Service;
using ExceptionHandling.View;

namespace ExceptionHandling;

/// <summary>
/// Entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        ConsoleUI consoleUI = new ();
        Tasks tasks = new (consoleUI);

        GetMenuOption(consoleUI, tasks);
    }

    /// <summary>
    /// Displays the main menu and proceed to selected option.
    /// </summary>
    /// <param name="consoleUI"> Instance to consoleUI. </param>
    /// <param name="tasks"> Instance to tasks.
    /// </param>
    public static void GetMenuOption(ConsoleUI consoleUI, Tasks tasks)
    {
        while (true)
        {
            try
            {
                MainMenu choice = consoleUI.GetMenuChoice<MainMenu>(HeaderMessages.MainMenu, $"\n{UserPrompts.SelectOption} [ 0 - 5 ]:");
                consoleUI.ClearConsole();
                switch (choice)
                {
                    case MainMenu.Exit:
                        consoleUI.DisplayMessage(SuccessMessages.ProcessEnded);
                        consoleUI.GetAnyKey();
                        return;
                    case MainMenu.DivideByZeroException:
                        consoleUI.DisplayMessage(HeaderMessages.DivideByZeroException);
                        tasks.Task1();
                        break;
                    default:
                        consoleUI.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }

                consoleUI.GetAnyKey();
            }
            catch (OperationCanceledException)
            {
                consoleUI.DisplayMessage(SuccessMessages.ProcessCancelled);
                consoleUI.GetAnyKey();
            }
            catch (Exception ex)
            {
                consoleUI.DisplayMessage($"Unexpected Error: {ex.Message}");
            }
        }
    }
}