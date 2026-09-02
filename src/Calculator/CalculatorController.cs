using Calculator.Constants;
using Calculator.Enums;

namespace Calculator;

/// <summary>
/// Coordinates between calculator view and math utils.
/// </summary>
public class CalculatorController
{
    private readonly CalculatorView _calculatorView;
    private readonly MathUtils _mathUtils;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorController"/> class.
    /// </summary>
    /// <param name="calculatorView"> Instance of calculator view. </param>
    /// <param name="mathUtils"> Instance of math utils. </param>
    public CalculatorController(CalculatorView calculatorView, MathUtils mathUtils)
    {
        this._calculatorView = calculatorView;
        this._mathUtils = mathUtils;
    }

    /// <summary>
    /// Displays the main menu and proceed to selected option.
    /// </summary>
    public void GetMenuOption()
    {
        while (true)
        {
            try
            {
                MainMenu choice = this._calculatorView.GetMenuChoice<MainMenu>("Main Menu", $"\n{UserPrompts.SelectOption} [ 0 - 4 ]:");
                this._calculatorView.ClearConsole();
                switch (choice)
                {
                    case MainMenu.Exit:
                        this._calculatorView.DisplaySuccessMessage(SuccessMessages.ProcessEnded);
                        return;
                    case MainMenu.Addition:
                        this._calculatorView.DisplayMessage(MainMenu.Addition.ToString());
                        this.Addition();
                        break;
                    case MainMenu.Subtraction:
                        this._calculatorView.DisplayMessage(MainMenu.Subtraction.ToString());
                        this.Subtraction();
                        break;
                    case MainMenu.Multiplication:
                        this._calculatorView.DisplayMessage(MainMenu.Multiplication.ToString());
                        this.Multiplication();
                        break;
                    case MainMenu.Division:
                        this._calculatorView.DisplayMessage(MainMenu.Division.ToString());
                        this.Division();
                        break;
                }

                this._calculatorView.GetAnyKey();
            }
            catch (OperationCanceledException)
            {
                this._calculatorView.DisplaySuccessMessage(SuccessMessages.ProcessCancelled);
            }
        }
    }

    /// <summary>
    /// Adds two integers.
    /// </summary>
    public void Addition()
    {
        int firstNumber = this._calculatorView.GetInteger("Enter first integer:");
        int secondNumber = this._calculatorView.GetInteger("Enter second integer:");

        this._calculatorView.DisplayMessage($"Sum of {firstNumber} and {secondNumber} is {this._mathUtils.Addition(firstNumber, secondNumber)}");
    }

    /// <summary>
    /// Subtracts two integers.
    /// </summary>
    public void Subtraction()
    {
        int firstNumber = this._calculatorView.GetInteger("Enter first integer:");
        int secondNumber = this._calculatorView.GetInteger("Enter second integer:");

        this._calculatorView.DisplayMessage($"Difference of {firstNumber} and {secondNumber} is {this._mathUtils.Subtraction(firstNumber, secondNumber)}");
    }

    /// <summary>
    /// Multiply two integers.
    /// </summary>
    public void Multiplication()
    {
        int firstNumber = this._calculatorView.GetInteger("Enter first integer:");
        int secondNumber = this._calculatorView.GetInteger("Enter second integer:");

        this._calculatorView.DisplayMessage($"Product of {firstNumber} and {secondNumber} is {this._mathUtils.Multiplication(firstNumber, secondNumber)}");
    }

    /// <summary>
    /// Divide two integers.
    /// </summary>
    public void Division()
    {
        int firstNumber = this._calculatorView.GetInteger("Enter first integer:");
        int secondNumber = this._calculatorView.GetInteger("Enter second integer:");

        try
        {
            this._calculatorView.DisplayMessage($"Quotient of {firstNumber} and {secondNumber} is {this._mathUtils.Division(firstNumber, secondNumber)}");
        }
        catch (DivideByZeroException)
        {
            this._calculatorView.DisplayErrorMessage(ErrorMessages.DivideByZero);
        }
    }
}
