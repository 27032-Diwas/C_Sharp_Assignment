using System.Drawing;
using System.Text.RegularExpressions;
using OOPS.Constants;

namespace OOPS.Helper;

/// <summary>
/// Provides methods for validating user input.
/// </summary>
public static class Validation
{
    /// <summary>
    /// Determines whether the specified name is valid.
    /// </summary>
    /// <param name="name"> The name to validate. </param>
    /// <returns>
    /// True if the name contains at least two characters and matches the required pattern; otherwise false.
    /// </returns>
    public static bool IsValidName(string? name) => !string.IsNullOrEmpty(name)
                                                    && Regex.IsMatch(name, RegexPatterns.NameRegex);

    /// <summary>
    /// Determines whether the specified amount is valid.
    /// </summary>
    /// <param name="amount"> The amount to validate. </param>
    /// <returns>
    /// True if the amount is greater than or equal to zero; otherwise false.
    /// </returns>
    public static bool IsValidAmount(decimal? amount) => amount >= 0;

    /// <summary>
    /// Determines whether the specified dimension value is valid.
    /// </summary>
    /// <param name="dimension"> The dimension to validate. </param>
    /// <returns>
    /// True if the dimension is greater than zero; otherwise false.
    /// </returns>
    public static bool IsValidDimension(double? dimension) => dimension > 0;

    /// <summary>
    /// Determines whether the specified MPIN is valid.
    /// </summary>
    /// <param name="mpin"> The MPIN to validate. </param>
    /// <returns>
    /// True if the MPIN matches the required pattern; otherwise false.
    /// </returns>
    public static bool IsValidMpin(string? mpin) => !string.IsNullOrEmpty(mpin)
                                                    && Regex.IsMatch(mpin, RegexPatterns.MpinRegex);

    /// <summary>
    /// Determines whether the specified account number is valid.
    /// </summary>
    /// <param name="accountNumber"> The account number to validate. </param>
    /// <returns>
    /// True if the account number contains exactly ten digits; otherwise false.
    /// </returns>
    public static bool IsValidAccountNumber(decimal? accountNumber) => accountNumber > 1000000000
                                                                      && accountNumber < 10000000000;

    /// <summary>
    /// Determines whether the specified color name is valid.
    /// </summary>
    /// <param name="colorName"> The color name to validate. </param>
    /// <returns>
    /// True if the color name represents a known color; otherwise false.
    /// </returns>
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
