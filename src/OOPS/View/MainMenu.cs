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
        bool isValidMenuOption = true;

        while (isValidMenuOption)
        {
            DisplayMenu();

            Console.WriteLine(MessageConstants.SelectOption);
            var isParsed = Enum.TryParse<MenuContent.MainMenu>(Console.ReadLine(), true, out MenuContent.MainMenu choice);
            if (!isParsed || !Enum.IsDefined(typeof(MenuContent.MainMenu), choice))
            {
                Console.Clear();
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

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
                    break;
            }
        }
    }

    /// <summary>
    /// Displays main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine(MessageConstants.MainMenu);
        foreach (var value in Enum.GetValues(typeof(MenuContent.MainMenu)))
        {
            Console.WriteLine($"{(int)value}. {value}");
        }
    }
}
