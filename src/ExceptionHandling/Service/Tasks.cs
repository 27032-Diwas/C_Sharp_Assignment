using ExceptionHandling.Constants;
using ExceptionHandling.View;

namespace ExceptionHandling.Service;

/// <summary>
/// Contains demonstration for different types of exception.
/// </summary>
public class Tasks
{
    private readonly ConsoleUI _consoleUI;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tasks"/> class.
    /// </summary>
    /// <param name="consoleUI"> Instance of consoleUI. </param>
    public Tasks(ConsoleUI consoleUI)
    {
        this._consoleUI = consoleUI;
    }

    /// <summary>
    /// Demonstrate divide by zero exception.
    /// </summary>
    public void Task1()
    {
        try
        {
            int number1 = this._consoleUI.GetIntegerInput(UserPrompts.GetInteger);
            int number2 = this._consoleUI.GetIntegerInput(UserPrompts.GetInteger);

            this._consoleUI.DisplayMessage($"{number1} / {number2} = {number1 / number2}");
        }
        catch (DivideByZeroException)
        {
            this._consoleUI.DisplayErrorMessage(ErrorMessages.DivideByZero);
        }
        finally
        {
            this._consoleUI.DisplaySuccessMessage(SuccessMessages.Task1);
        }
    }
}
