using System.Text.RegularExpressions;

namespace ContactManager.Helper;

/// <summary>
/// Contains validation methods and returns true or false.
/// </summary>
public class Validation
{
    private static readonly string EmailRegex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
    private static readonly string PhoneRegex = @"^\d{10}$";

    /// <summary>
    /// Check whether name is empty or not.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <returns> true or false </returns>
    public static bool IsNameEmpty(string? name) => string.IsNullOrWhiteSpace(name) || name == string.Empty;

    /// <summary>
    /// Check whether name is more than one letter.
    /// </summary>
    /// <param name="name"> Name. </param>
    /// <returns> true or false </returns>
    public static bool IsNameValid(string? name) => name != null && name.Length > 1;

    /// <summary>
    /// Check whether number is empty or not.
    /// </summary>
    /// <param name="phoneNumber"> Phone number </param>
    /// <returns> true or false </returns>
    public static bool IsNumberEmpty(string? phoneNumber) => string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber == string.Empty;

    /// <summary>
    /// Check whether number is valid or not.
    /// </summary>
    /// <param name="phone"> Phone number. </param>
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
    /// <param name="email"> Email. </param>
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

        return Regex.IsMatch(email, EmailRegex, RegexOptions.IgnoreCase) && !email.Contains("..");
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
