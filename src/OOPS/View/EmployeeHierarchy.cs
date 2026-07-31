using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Services.EmployeeHierarchy;
using static OOPS.EnumConstants.MenuOptions;

namespace OOPS.View;

/// <summary>
/// Provides functionality for demonstrating the employee hierarchy.
/// </summary>
public class EmployeeHierarchy
{
    /// <summary>
    /// Displays the employee menu and processes the selected option.
    /// </summary>
    public static void GetMenuOption()
    {
        while (true)
        {
            MenuOptions.EmployeeMenu choice = DisplayEnum.GetMenuChoice<MenuOptions.EmployeeMenu>(MessageConstants.EmployeeMenu);
            Console.Clear();

            switch (choice)
            {
                case MenuOptions.EmployeeMenu.Back:
                    return;
                case MenuOptions.EmployeeMenu.Manager:
                    CreateManager();
                    break;
                case MenuOptions.EmployeeMenu.Developer:
                    CreateDeveloper();
                    break;
            }
        }
    }

    /// <summary>
    /// Creates a manager and displays the manager details.
    /// </summary>
    private static void CreateManager()
    {
        string? inputString = ValidInput.GetName(MessageConstants.GetEmployeeName);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string name = inputString;
        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetEmployeeSalary);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal salary = inputDecimal.Value;
        Manager manager = new (name, salary);

        Console.WriteLine(manager.PrintDetails());
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Creates a developer and displays the developer details.
    /// </summary>
    private static void CreateDeveloper()
    {
        string? inputString = ValidInput.GetName(MessageConstants.GetEmployeeName);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string name = inputString;
        decimal? inputDecimal = ValidInput.GetAmount(MessageConstants.GetEmployeeSalary);
        if (inputDecimal is null)
        {
            Console.Clear();
            return;
        }

        decimal salary = inputDecimal.Value;
        Developer developer = new (name, salary);

        Console.WriteLine(developer.PrintDetails());
        ValidInput.GetAnyKey();
    }
}
