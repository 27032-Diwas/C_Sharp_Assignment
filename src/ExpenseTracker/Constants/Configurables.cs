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
}
