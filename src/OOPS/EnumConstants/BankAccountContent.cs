namespace OOPS.EnumConstants;

/// <summary>
/// Contains all bank related options in this applications.
/// </summary>
public class BankAccountContent
{
    /// <summary>
    /// Contains bank account type options.
    /// </summary>
    public enum BankAccountTypes
    {
        /// <summary>
        /// Header displayed for exit option.
        /// </summary>
        Exit,

        /// <summary>
        /// Header displayed for savings account.
        /// </summary>
        SavingsAccount,

        /// <summary>
        /// Header displayed for checking account
        /// </summary>
        CheckingAccount,
    }
}
