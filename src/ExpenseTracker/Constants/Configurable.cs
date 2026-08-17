namespace ExpenseTracker.Constants;

/// <summary>
/// Contains configurable related to expense tracker.
/// </summary>
public class Configurable
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
