using System.Text.RegularExpressions;

namespace ContactManager.Helper;

/// <summary>
/// Contains validation methods and returns true or flase
/// </summary>
public class Validation
{
    private static readonly Regex EmailRegex = new (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly string PhoneRegex = @"^\d{10}$";

    /// <summary>
    /// Check wheather name is empty or not.
    /// </summary>
    /// <param name="name"> object </param>
    /// <returns> true or false </returns>
    public static bool IsNameEmpty(string? name) => string.IsNullOrWhiteSpace(name) || name == string.Empty;

    /// <summary>
    /// Check wheather number is empty or not.
    /// </summary>
    /// <param name="phoneNumber"> number </param>
    /// <returns> true or false </returns>
    public static bool IsNumberEmpty(string? phoneNumber) => string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber == string.Empty;

    /// <summary>
    /// Check wheather number is valid or not.
    /// </summary>
    /// <param name="phone"> number </param>
    /// <returns> true of false </returns>
    public static bool IsNumber(string? phone)
    {
        if (phone == null)
        {
            return false;
        }

        return Regex.IsMatch(phone, PhoneRegex);
    }

    /// <summary>
    /// Check for valid email.
    /// </summary>
    /// <param name="email"> email </param>
    /// <returns> true or false </returns>
    public static bool IsEmail(string? email)
    {
        if (email == string.Empty)
        {
            return true;
        }
        else if (email == null)
        {
            return false;
        }

        return EmailRegex.IsMatch(email);
    }

    /// <summary>
    /// Check for notes length.
    /// </summary>
    /// <param name="notes"> Notes </param>
    /// <returns> true or false</returns>
    public static bool IsNotes(string? notes)
    {
        if (notes == string.Empty)
        {
            return true;
        }
        else if (notes == null)
        {
            return false;
        }

        return notes.Length < 50;
    }
}
