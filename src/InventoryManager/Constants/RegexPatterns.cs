namespace InventoryManager.Constants;

/// <summary>
/// Contains all the regex pattern need for inventory management application.
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Product name should start with a letter or number.
    /// Middle portion can be letter, number and symbols.
    /// Product name should end with a letter or number.
    /// </summary>
    public const string ProductNameRegex = @"^(?=.*[A-Za-z])[A-Za-z0-9\s'-]{2,20}$";
}
