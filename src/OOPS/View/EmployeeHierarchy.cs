using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Helper;
using OOPS.Services.EmployeeHierarchy;
using static OOPS.EnumConstants.MenuContent;

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
        while (true)
        {
            MenuContent.EmployeeMenu choice = DisplayEnum.GetMenuChoice<MenuContent.EmployeeMenu>(MessageConstants.EmployeeMenu);
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
        Manager manager = new(name, salary);

        Console.WriteLine(manager.PrintDetails());
        ValidInput.GetAnyKey();
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
        Developer developer = new(name, salary);

        Console.WriteLine(developer.PrintDetails());
        ValidInput.GetAnyKey();
    }
}
