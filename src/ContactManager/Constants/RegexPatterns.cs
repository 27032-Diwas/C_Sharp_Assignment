// <copyright file="RegexPatterns.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ContactManager.Constants;

/// <summary>
/// Contains all the regex patterns.
/// </summary>
public class RegexPatterns
{
    /// <summary>
    /// Regular expression pattern used to validate email addresses.
    /// </summary>
    public const string EmailRegex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

    /// <summary>
    /// Regular expression pattern used to validate a phone number.
    /// The phone number must contain exactly 10 digits and start with a digit from 6 to 9.
    /// </summary>
    public const string PhoneNumberRegex = @"^[6-9]\d{9}$";

    /// <summary>
    /// Regular expression pattern used to validate contact names.
    /// The name must:
    /// - Contain at least one alphabetic character.
    /// - Be between 2 and 20 characters long.
    /// - Allow letters, numbers, spaces, apostrophes, and hyphens.
    ///  </summary>
    public const string NameRegex = @"^(?=.*[A-Za-z])[A-Za-z0-9\s'-]{2,20}$";
}
