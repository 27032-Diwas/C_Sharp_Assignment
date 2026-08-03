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
            MainMenuEnum choice = DisplayEnum.GetMenuChoice<MainMenuEnum>(MessageConstants.MainMenu);

            Console.Clear();
            switch (choice)
            {
                case MainMenuEnum.Exit:
                    Console.WriteLine(MessageConstants.ApplicationExit);
                    return;
                case MainMenuEnum.ShapeHierarchy:
                    ShapeHierarchy.GetMenuOption();
                    break;
                case MainMenuEnum.EmployeeHierarchy:
                    EmployeeHierarchy.GetMenuOption();
                    break;
                case MainMenuEnum.BankSystem:
                    bankSystem.GetMenuOption();
                    break;
            }
        }
    }
}
