using System.Drawing;
using System.Text.RegularExpressions;
using OOPS.Constants;

namespace OOPS.Helper;

/// <summary>
/// Contains validation methods and returns true or false.
/// </summary>
public static class Validation
{
    /// <summary>
    /// Check whether name is more than one letter.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidName(string? name) => !string.IsNullOrEmpty(name)
                                                    && Regex.IsMatch(name, RegexPatterns.NameRegex);

    /// <summary>
    /// Check whether amount is positive or not.
    /// </summary>
    /// <param name="amount"> Amonut to deposit or withdraw. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidAmount(decimal? amount) => amount >= 0;

    /// <summary>
    /// Check whether measurement is positive or not.
    /// </summary>
    /// <param name="measurement"> Measurement. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidMeasurement(double? measurement) => measurement > 0;

    /// <summary>
    /// Check whether mpin is valid.
    /// </summary>
    /// <param name="mpin"> Mpin. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidMpin(string mpin) => Regex.IsMatch(mpin, RegexPatterns.MpinRegex);

    /// <summary>
    /// Check whether account number is 10 digit or not.
    /// </summary>
    /// <param name="accountNumber"> Account number. </param>
    /// <returns> true or flase. </returns>
    public static bool IsValidAccountNumber(decimal? accountNumber) => accountNumber > 1000000000
                                                                      && accountNumber < 10000000000;

    /// <summary>
    /// Check whether color is valid or not.
    /// </summary>
    /// <param name="colorName"> Color name. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidColor(string? colorName)
    {
        if (string.IsNullOrEmpty(colorName))
        {
            return false;
        }

        Color color = Color.FromName(colorName.Trim());

        return color.IsKnownColor;
    }
}
