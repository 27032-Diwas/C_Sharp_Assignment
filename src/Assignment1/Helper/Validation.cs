// <copyright file="Validation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ContactManager.Helper;

using System.Text.RegularExpressions;
using ContactManager.Constants;

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
    public static bool IsValidName(string? name) => name is not null && Regex.IsMatch(name, RegexPatterns.NameRegex);

    /// <summary>
    /// Check whether enter string is empty or not.
    /// </summary>
    /// <param name="contactDetail"> string to check. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidInput(string? contactDetail) => string.IsNullOrWhiteSpace(contactDetail) || contactDetail == string.Empty;

    /// <summary>
    /// Check whether number is valid or not.
    /// </summary>
    /// <param name="phoneNumber"> Phone number. </param>
    /// <returns> true of false. </returns>
    public static bool IsValidPhoneNumber(string? phoneNumber) => phoneNumber is not null
                                                                  && Regex.IsMatch(phoneNumber, RegexPatterns.PhoneNumberRegex);

    /// <summary>
    /// Check for valid email.
    /// </summary>
    /// <param name="email"> Email. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidEmail(string? email) => email == string.Empty
                                                      || (email is not null && Regex.IsMatch(email, RegexPatterns.EmailRegex, RegexOptions.IgnoreCase)
                                                      && !email.Contains(".."));

    /// <summary>
    /// Check for notes length.
    /// </summary>
    /// <param name="notes"> Notes. </param>
    /// <returns> true or false. </returns>
    public static bool IsValidNotes(string? notes) => notes == string.Empty || (notes is not null && notes.Length < 50);
}
