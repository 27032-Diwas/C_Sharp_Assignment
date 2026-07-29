namespace OOPS.EnumConstants;

/// <summary>
/// Contains all menu options in this application.
/// </summary>
public static class MenuContent
{
    /// <summary>
    /// Contains main menu options.
    /// </summary>
    public enum MainMenu
    {
        /// <summary>
        /// Represents the option to exit the application.
        /// </summary>
        Exit,

        /// <summary>
        /// Represents the option to access the shape hierarchy module.
        /// </summary>
        ShapeHierarchy,

        /// <summary>
        /// Represents the option to access the employee hierarchy module.
        /// </summary>
        EmployeeHierarchy,

        /// <summary>
        /// Represents the option to access the bank system module.
        /// </summary>
        BankSystem,
    }

    /// <summary>
    /// Contains shape menu options.
    /// </summary>
    public enum ShapeMenu
    {
        /// <summary>
        /// Represents the option to return to the previous menu.
        /// </summary>
        Back,

        /// <summary>
        /// Represents the option to work with a rectangle.
        /// </summary>
        Rectangle,

        /// <summary>
        /// Represents the option to work with a circle.
        /// </summary>
        Circle,
    }

    /// <summary>
    /// Contains employee menu options.
    /// </summary>
    public enum EmployeeMenu
    {
        /// <summary>
        /// Represents the option to return to the previous menu.
        /// </summary>
        Back,

        /// <summary>
        /// Represents the option to work with a manager.
        /// </summary>
        Manager,

        /// <summary>
        /// Represents the option to work with a developer.
        /// </summary>
        Developer,
    }

    /// <summary>
    /// Contains bank system menu options.
    /// </summary>
    public enum BankSystemMenu
    {
        /// <summary>
        /// Represents the option to return to the previous menu.
        /// </summary>
        Back,

        /// <summary>
        /// Represents the option to add a new account.
        /// </summary>
        AddAccount,

        /// <summary>
        /// Represents the option to access an existing account.
        /// </summary>
        ExistingAccount,
    }

    /// <summary>
    /// Contains exit enum.
    /// </summary>
    public enum Exit
    {
        /// <summary>
        /// Represents the option to exit the application.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Contains option related to working in an account.
    /// </summary>
    public enum AccountMenu
    {
        /// <summary>
        /// Represents the option to return to the previous menu.
        /// </summary>
        Back,

        /// <summary>
        /// Represents the option to view account details.
        /// </summary>
        ViewAccount,

        /// <summary>
        /// Represents the option to deposit money into the account.
        /// </summary>
        Deposit,

        /// <summary>
        /// Represents the option to withdraw money from the account.
        /// </summary>
        Withdraw,
    }
}
