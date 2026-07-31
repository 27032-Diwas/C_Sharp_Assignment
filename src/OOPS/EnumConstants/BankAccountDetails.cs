namespace OOPS.EnumConstants;

/// <summary>
/// Contains all bank related options in this application.
/// </summary>
public class BankAccountDetails
{
    /// <summary>
    /// Contains bank account type options.
    /// </summary>
    public enum BankAccountTypes
    {
        /// <summary>
        /// Represents the option to exit the application.
        /// </summary>
        Exit,

        /// <summary>
        /// Represents the option to exit the savings account.
        /// </summary>
        SavingsAccount,

        /// <summary>
        /// Represents the option to exit the checking account.
        /// </summary>
        CheckingAccount,
    }
}
