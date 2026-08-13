namespace InventoryManager.Constants;

/// <summary>
/// Contains all the regex pattern required for inventory management application.
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Product name should be with in 1 - 50 letters.
    /// Can contains space and symbols.
    /// </summary>
    public const string ProductNameRegex = @"^(?=.{1,50}$)(?=.*[A-Za-z])[A-Za-z0-9\s\-_&/().+#]*$";
}
