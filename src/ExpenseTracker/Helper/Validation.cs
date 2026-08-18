using System.Text.RegularExpressions;
using ExpenseTracker.Constants;

namespace ExpenseTracker.Helper;

/// <summary>
/// Contains all validations related to expense tracker.
/// </summary>
public static class Validation
{
    /// <summary>
    /// Determines whether the specified amount is valid.
    /// </summary>
    /// <param name="amount"> Amount to validate. </param>
    /// <returns> True if amount is valid; otherwise false. </returns>
    public static bool IsValidAmount(decimal amount) => amount > Configurables.MinimumAmountThreshold && amount < Configurables.MaxAmountThreshold;

    /// <summary>
    /// Determines whether the specified description is valid.
    /// </summary>
    /// <param name="description"> Description to validate. </param>
    /// <returns> True if description is valid; otherwise false. </returns>
    public static bool IsValidDescription(string description) => Regex.IsMatch(description, RegexPatterns.DescriptionPattern);

    /// <summary>
    /// Determines whether the specified category is valid.
    /// </summary>
    /// <param name="category"> Category to validate. </param>
    /// <returns> True if category is valid; otherwise false. </returns>
    public static bool IsValidCategory(string category) => Regex.IsMatch(category, RegexPatterns.CategoryPattern);
}
