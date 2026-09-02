namespace Calculator;

/// <summary>
/// Entry point of the application
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        CalculatorView calculatorView = new ();
        MathUtils mathUtils = new ();
        CalculatorController calculatorController = new (calculatorView, mathUtils);

        calculatorController.GetMenuOption();
    }
}