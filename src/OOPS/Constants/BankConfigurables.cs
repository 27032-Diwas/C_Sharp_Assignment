namespace OOPS.Constants;

/// <summary>
/// Contains all the configurable related to bank system.
/// </summary>
public static class BankConfigurable
{
    /// <summary>
    /// Minimum balance for savings account.
    /// </summary>
    public const decimal SavingAccountMinimumBalance = 1000;

    /// <summary>
    /// Minimum threshold for checking account.
    /// </summary>
    public const decimal CheckingAccountMinimumThreshold = -50000;

    /// <summary>
    /// Max threshold for amount.
    /// </summary>
    public const decimal AmountMaxThreshold = 10000000;
}
