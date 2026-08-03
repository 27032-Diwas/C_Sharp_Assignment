using OOPS.Constants;
using OOPS.Models;

namespace OOPS.Services.EmployeeHierarchy;

/// <summary>
/// Represents a manager in the employee hierarchy.
/// </summary>
public class Manager : Employee
{
    private const string _position = "Manager";

    /// <summary>
    /// Initializes a new instance of the <see cref="Manager"/> class.
    /// </summary>
    /// <param name="name"> The name of the employee. </param>
    /// <param name="salary"> The salary of the employee. </param>
    public Manager(string name, decimal salary)
        : base(name, salary)
    {
    }

    /// <summary>
    /// Calculates the bonus for the manager.
    /// </summary>
    /// <returns>
    /// The calculated bonus amount.
    /// </returns>
    public override double CalculateBonus() => (double)this.Salary * EmployeeConfigurable.ManagerBonus;

    /// <summary>
    /// Returns the employee details, including the name, position, salary, and bonus.
    /// </summary>
    /// <returns>
    /// A string containing the employee details.
    /// </returns>
    public override string PrintDetails() => $"\nName: {this.Name}\nPosition: {_position}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus():F2}";
}
