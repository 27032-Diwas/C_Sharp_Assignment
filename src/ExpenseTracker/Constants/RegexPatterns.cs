namespace ExpenseTracker.Constants;

/// <summary>
/// Contains all regex patterns.
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Allows letters, numbers, spaces, hyphens, ampersands, and underscores
    /// Max 50 character.
    /// </summary>
    public const string CategoryPattern = @"^.{1,50}$";

    /// <summary>
    /// Allows letters, numbers, spaces, hyphens, ampersands, and underscores
    /// Max 100 character.
    /// </summary>
    public const string DescriptionPattern = @"^.{1,100}$";
}
