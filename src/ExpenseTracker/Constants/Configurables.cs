using ExpenseTracker.Enums;

namespace ExpenseTracker.Constants;

/// <summary>
/// Contains configurables related to expense tracker.
/// </summary>
public static class Configurables
{
    /// <summary>
    /// Represents the maximum amount per transaction.
    /// </summary>
    public const decimal MaxAmountThreshold = 100000000;

    /// <summary>
    /// Represents the minimum amount per transaction.
    /// </summary>
    public const decimal MinimumAmountThreshold = 0.0001m;

    /// <summary>
    /// Represents the max menu range.
    /// </summary>
    public static readonly int MaxMenuRange = Convert.ToInt32(MainMenu.Summary);

    /// <summary>
    /// Represents the max menu range.
    /// </summary>
    public static readonly int MaxEditableFieldRange = Convert.ToInt32(TransactionFields.TransactionDescription);
}
