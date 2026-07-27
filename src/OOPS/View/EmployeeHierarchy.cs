using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Services.EmployeeHierarchy;

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

            Console.Clear();

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
    /// Displays employee menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine(MessageConstants.EmployeeMenu);
        DisplayEnum.DisplayMenu(typeof(MenuContent.EmployeeMenu));
    }

    private void Manager()
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

        decimal salary = (decimal)inputDecimal;
        Manager manager = new (name, salary);

        Console.WriteLine(manager.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    private void Developer()
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

        decimal salary = (decimal)inputDecimal;
        Developer developer = new (name, salary);

        Console.WriteLine(developer.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }
}
