using OOPS.Constants;
using OOPS.EnumConstants;

namespace OOPS.View;

/// <summary>
/// Contains main menu of the project.
/// </summary>
public class MainMenu
{
    /// <summary>
    /// Get menu choice from user.
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

    /// <summary>
    /// Displays main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine(MessageConstants.MainMenu);
        DisplayEnum.DisplayMenu(typeof(MenuContent.MainMenu));
    }
}
