namespace OOPS.EnumConstants;

/// <summary>
/// Contains all menu options in this applications.
/// </summary>
public static class MenuContent
{
    /// <summary>
    /// Contains main menu options.
    /// </summary>
    public enum MainMenu
    {
        /// <summary>
        /// Header displayed for exit option.
        /// </summary>
        Exit,

        /// <summary>
        /// Header displayed for shape hierarchy.
        /// </summary>
        ShapeHierarchy,

        /// <summary>
        /// Header displayed for employee hierarchy.
        /// </summary>
        EmployeeHierarchy,

        /// <summary>
        /// Header displayed for bank system.
        /// </summary>
        BankSystem,
    }

    /// <summary>
    /// Contains shape menu options.
    /// </summary>
    public enum ShapeMenu
    {
        /// <summary>
        /// Header displayed for back option.
        /// </summary>
        Back,

        /// <summary>
        /// Header displayed for rectangle.
        /// </summary>
        Rectangle,

        /// <summary>
        /// Header displayed for circle.
        /// </summary>
        Circle,
    }

    /// <summary>
    /// Contains employee menu options.
    /// </summary>
    public enum EmployeeMenu
    {
        /// <summary>
        /// Header displayed for back option.
        /// </summary>
        Back,

        /// <summary>
        /// Header displayed for manager.
        /// </summary>
        Manager,

        /// <summary>
        /// Header displayed for developer.
        /// </summary>
        Developer,
    }

    /// <summary>
    /// Contains bank system menu options.
    /// </summary>
    public enum BankSystemMenu
    {
        /// <summary>
        /// Header displayed for back option.
        /// </summary>
        Back,

        /// <summary>
        /// Header displayed for add account.
        /// </summary>
        AddAccount,

        /// <summary>
        /// Header displayed for existing account.
        /// </summary>
        ExistingAccount,
    }

    /// <summary>
    /// Contains exit enum.
    /// </summary>
    public enum Exit
    {
        /// <summary>
        /// Header displayed for exit.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Contains option related to working in an account.
    /// </summary>
    public enum AccountMenu
    {
        /// <summary>
        /// Header displayed for back option.
        /// </summary>
        Back,

        /// <summary>
        /// Header displayed for view account.
        /// </summary>
        ViewAccount,

        /// <summary>
        /// Header displayed for deposit.
        /// </summary>
        Deposit,

        /// <summary>
        /// Header displayed for withdraw.
        /// </summary>
        Withdraw,
    }
}
