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
    public const string MpinRegex = @"^(?!.*^(\d)\1{3,5}$)(?!(?:0123|1234|2345|3456|4567|5678|6789|7890)$)(?!(?:9876|8765|7654|6543|5432|4321|3210)$)\d{4,6}$";
}
