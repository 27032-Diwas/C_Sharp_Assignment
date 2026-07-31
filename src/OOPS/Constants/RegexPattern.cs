namespace OOPS.Constants;

/// <summary>
/// Contains all the regex patterns.
/// </summary>
public class RegexPatterns
{
    /// <summary>
    /// Regular expression pattern used to validate account holder names.
    /// The name must:
    /// - Contain at least one alphabetic character.
    /// - Be between 2 and 20 characters long.
    /// - Allow letters, numbers, spaces, apostrophes, and hyphens.
    ///  </summary>
    public const string NameRegex = @"^(?=.*[A-Za-z])[A-Za-z0-9\s'-]{2,20}$";

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
