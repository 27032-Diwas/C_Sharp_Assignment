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
            MenuContent.MainMenu choice = DisplayEnum.GetMenuChoice<MenuContent.MainMenu>(MessageConstants.MainMenu);

            Console.Clear();
            switch (choice)
            {
                case MenuContent.MainMenu.Exit:
                    Console.WriteLine(MessageConstants.ProcessEnded);
                    return;
                case MenuContent.MainMenu.ShapeHierarchy:
                    ShapeHierarchy.GetMenuOption();
                    break;
                case MenuContent.MainMenu.EmployeeHierarchy:
                    EmployeeHierarchy.GetMenuOption();
                    break;
                case MenuContent.MainMenu.BankSystem:
                    bankSystem.GetMenuOption();
                    break;
            }
        }
    }
}
