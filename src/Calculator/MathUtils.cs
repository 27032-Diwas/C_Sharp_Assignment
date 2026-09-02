namespace Calculator;

/// <summary>
/// Contains mathematical operations such as addition, subtraction, multiplication and divisions.
/// </summary>
public class MathUtils
{
    /// <summary>
    /// Adds two integers.
    /// </summary>
    /// <param name="number1"> First number. </param>
    /// <param name="number2"> Second number. </param>
    /// <returns> Sum of two integers. </returns>
    public int Addition(int number1, int number2) => number1 + number2;

    /// <summary>
    /// Subtracts two integers.
    /// </summary>
    /// <param name="number1"> First number. </param>
    /// <param name="number2"> Second number. </param>
    /// <returns> Difference of two integers. </returns>
    public int Subtraction(int number1, int number2) => number1 - number2;

    /// <summary>
    /// Multiply two integers.
    /// </summary>
    /// <param name="number1"> First number. </param>
    /// <param name="number2"> Second number. </param>
    /// <returns> Product of two integers. </returns>
    public int Multiplication(int number1, int number2) => number1 * number2;

    /// <summary>
    /// Divides two integers.
    /// </summary>
    /// <param name="number1"> First integer.</param>
    /// <param name="number2"> Second integer. </param>
    /// <returns> The quotient of two integers. </returns>
    /// <exception cref="DivideByZeroException"> Exception throwed when second number is zero. </exception>
    public decimal Division(int number1, int number2)
    {
        if (number2 == 0)
        {
            throw new DivideByZeroException();
        }

        return number1 / number2;
    }
}
