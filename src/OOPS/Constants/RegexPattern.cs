namespace OOPS.Constants;

/// <summary>
/// Contains all the regex patterns.
/// </summary>
public class RegexPatterns
{
    /// <summary>
    /// Regular expression pattern used to validate names. Allows letters, spaces, periods, apostrophes, and hyphens.
    ///  </summary>
    public const string NameRegex = @"^(?=.{2,100}$)[A-Za-z]+(?:[ .'\-][A-Za-z]+)*$";

    /// <summary>
    /// Regular expression pattern used to validate mpin.
    /// The mpin must:
    /// - Be between 4 to 6 digits.
    /// - Allow only digits.
    /// </summary>
    public const string MpinRegex = @"^\d{4}$";

    /// <summary>
    /// Regular expression pattern used to validate account number.
    /// The account number must:
    /// - Be 10 digits.
    /// - Allow only digits.
    /// </summary>
    public const string AccountNumberRegex = @"^ACC\d{6}$";
}
