using System.Text.RegularExpressions;
using OOPS.Constants;

namespace OOPS.Helper;

/// <summary>
/// Contains validation methods and returns true or false.
/// </summary>
public class Validation
{
    /// <summary>
    /// Check whether name is more than one letter.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidName(string? name) => name is not null && Regex.IsMatch(name, RegexPatterns.NameRegex);

    /// <summary>
    /// Check whether amount is positive or not.
    /// </summary>
    /// <param name="amount"> Amonut to deposit or withdraw. </param>
    /// <returns> true or false. </returns>
    public static bool IsAmountValid(decimal amount) => amount > 0;
}
