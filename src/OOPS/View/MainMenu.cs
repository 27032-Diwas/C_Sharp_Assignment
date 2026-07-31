using OOPS.Constants;
using OOPS.EnumConstants;

namespace OOPS.View;

/// <summary>
/// Provides the main menu and navigation for the application.
/// </summary>
public class MainMenu
{
    /// <summary>
    /// Displays the main menu and processes the selected option.
    /// </summary>
    public static void GetMenuOption()
    {
        BankSystem bankSystem = new ();

        while (true)
        {
            MenuOptions.MainMenu choice = DisplayEnum.GetMenuChoice<MenuOptions.MainMenu>(MessageConstants.MainMenu);

            Console.Clear();
            switch (choice)
            {
                case MenuOptions.MainMenu.Exit:
                    Console.WriteLine(MessageConstants.ApplicationExit);
                    return;
                case MenuOptions.MainMenu.ShapeHierarchy:
                    ShapeHierarchy.GetMenuOption();
                    break;
                case MenuOptions.MainMenu.EmployeeHierarchy:
                    EmployeeHierarchy.GetMenuOption();
                    break;
                case MenuOptions.MainMenu.BankSystem:
                    bankSystem.GetMenuOption();
                    break;
            }
        }
    }
}
