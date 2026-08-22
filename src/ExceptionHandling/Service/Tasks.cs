using ExceptionHandling.Constants;
using ExceptionHandling.CustomExceptions;
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

    /// <summary>
    /// Demonstrate index out of range exception.
    /// </summary>
    public void Task2()
    {
        try
        {
            int length = this._consoleUI.GetIntegerInput(UserPrompts.GetLength);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = this._consoleUI.GetIntegerInput(UserPrompts.GetInteger);
            }

            this._consoleUI.ClearConsole();
            int index = this._consoleUI.GetIntegerInput(UserPrompts.GetIndex);

            this._consoleUI.DisplayMessage($"{array[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            this._consoleUI.DisplayErrorMessage(ErrorMessages.InvalidIndex);
        }
        finally
        {
            this._consoleUI.DisplaySuccessMessage(SuccessMessages.Task2);
        }
    }

    /// <summary>
    /// Demonstrate custom exception.
    /// </summary>
    public void Task3()
    {
        try
        {
            int length = this._consoleUI.GetIntegerInput(UserPrompts.GetLength);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                int age = this._consoleUI.GetIntegerInput(UserPrompts.GetAge);
                if (age < 0)
                {
                    throw new InvalidUserInputException(ErrorMessages.InvalidAge);
                }
            }

            this._consoleUI.ClearConsole();
            int index = this._consoleUI.GetIntegerInput(UserPrompts.GetIndex);

            this._consoleUI.DisplayMessage($"{array[index]}");
        }
        catch (InvalidUserInputException e)
        {
            this._consoleUI.DisplayErrorMessage(e.Message);
        }
        catch (IndexOutOfRangeException)
        {
            this._consoleUI.DisplayErrorMessage(ErrorMessages.InvalidIndex);
        }
        finally
        {
            this._consoleUI.DisplaySuccessMessage(SuccessMessages.Task3);
        }
    }

    /// <summary>
    /// Demonstrate unhandled exception.
    /// </summary>
    /// <exception cref="InvalidUserInputException"> Custom exception. </exception>
    public void Task4()
    {
        AppDomain.CurrentDomain.UnhandledException += this.UnhandledException;
        try
        {
            int length = this._consoleUI.GetIntegerInput(UserPrompts.GetLength);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                int age = this._consoleUI.GetIntegerInput(UserPrompts.GetAge);
                if (age < 0)
                {
                    throw new InvalidUserInputException(ErrorMessages.InvalidAge);
                }
            }

            this._consoleUI.ClearConsole();
            int index = this._consoleUI.GetIntegerInput(UserPrompts.GetIndex);

            this._consoleUI.DisplayMessage($"{array[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            this._consoleUI.DisplayErrorMessage(ErrorMessages.InvalidIndex);
        }
        finally
        {
            this._consoleUI.DisplaySuccessMessage(SuccessMessages.Task4);
        }
    }

    /// <summary>
    /// Demonstrate exception stack.
    /// </summary>
    public void Task5()
    {
        try
        {
            int length = this._consoleUI.GetIntegerInput(UserPrompts.GetLength);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                int age = this._consoleUI.GetIntegerInput(UserPrompts.GetAge);
                if (age < 0)
                {
                    throw new InvalidUserInputException(ErrorMessages.InvalidAge);
                }
            }

            this._consoleUI.ClearConsole();
            int index = this._consoleUI.GetIntegerInput(UserPrompts.GetIndex);

            this._consoleUI.DisplayMessage($"{array[index]}");
        }
        catch (InvalidUserInputException e)
        {
            this._consoleUI.DisplayErrorMessage(e.Message);
            this._consoleUI.DisplayMessage(e.StackTrace ?? string.Empty);
        }
        catch (IndexOutOfRangeException e)
        {
            this._consoleUI.DisplayErrorMessage(ErrorMessages.InvalidIndex);
            this._consoleUI.DisplayMessage(e.StackTrace ?? string.Empty);
        }
        finally
        {
            this._consoleUI.DisplaySuccessMessage(SuccessMessages.Task5);
        }
    }

    private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        this._consoleUI.DisplayErrorMessage(ErrorMessages.InvalidMessage);
    }
}
