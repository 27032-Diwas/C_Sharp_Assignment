using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Services;

namespace OOPS.View;

/// <summary>
/// Contains methods related to employee hierarchy.
/// </summary>
public class EmployeeHierarchy
{
    /// <summary>
    /// Get employee menu choice from user.
    /// </summary>
    public void GetMenuOption()
    {
        bool isValidMenuOption = true;

        while (isValidMenuOption)
        {
            DisplayMenu();

            Console.WriteLine(MessageConstants.SelectOption);
            var isParsed = Enum.TryParse<MenuContent.EmployeeMenu>(Console.ReadLine(), true, out MenuContent.EmployeeMenu choice);
            if (!isParsed || !Enum.IsDefined(typeof(MenuContent.EmployeeMenu), choice))
            {
                Console.Clear();
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

            switch (choice)
            {
                case MenuContent.EmployeeMenu.Back:
                    return;
                case MenuContent.EmployeeMenu.Manager:
                    this.Manager();
                    break;
                case MenuContent.EmployeeMenu.Developer:
                    this.Developer();
                    break;
            }
        }
    }

    /// <summary>
    /// Displays main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.ReadKey();
        Console.WriteLine(MessageConstants.EmployeeMenu);
        foreach (var value in Enum.GetValues(typeof(MenuContent.EmployeeMenu)))
        {
            Console.WriteLine($"{(int)value}. {value}");
        }
    }

    private void Manager()
    {
        string? name = ValidInput.GetValidStringInput(MessageConstants.GetEmployeeName);
        decimal salary = ValidInput.GetValidDecimalInput(MessageConstants.GetEmployeeSalary);
        Manager manager = new (name, salary);

        Console.WriteLine(manager.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
    }

    private void Developer()
    {
        string? name = ValidInput.GetValidStringInput(MessageConstants.GetEmployeeName);
        decimal salary = ValidInput.GetValidDecimalInput(MessageConstants.GetEmployeeSalary);
        Developer developer = new (name, salary);

        Console.WriteLine(developer.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
    }
}
