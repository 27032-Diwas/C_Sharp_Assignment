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
    public void GetMenuOption()
    {
        ShapeHierarchy shapeHierarchy = new ();
        EmployeeHierarchy employeeHierarchy = new ();
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
                    shapeHierarchy.GetMenuOption();
                    break;
                case MenuContent.MainMenu.EmployeeHierarchy:
                    employeeHierarchy.GetMenuOption();
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
