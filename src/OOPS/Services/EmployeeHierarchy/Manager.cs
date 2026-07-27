using OOPS.Models;

namespace OOPS.Services.EmployeeHierarchy;

/// <summary>
/// Manager class inheriting employee class.
/// </summary>
public class Manager : Employee
{
    private const string _position = "Manager";

    /// <summary>
    /// Initializes a new instance of the <see cref="Manager"/> class.
    /// </summary>
    /// <param name="name"> Employee name.</param>
    /// <param name="salary"> Employee salary. </param>
    public Manager(string name, decimal salary)
        : base(name, salary)
    {
    }

    /// <summary>
    /// Calculate bonus of manager.
    /// </summary>
    /// <returns> Bonus of manager in double. </returns>
    public override double CalculateBonus()
    {
        return (double)this.Salary * 0.2;
    }

    /// <summary>
    /// Displays details such as name, salary, position and bonus.
    /// </summary>
    /// <returns> Details as a string. </returns>
    public override string PrintDetails()
    {
        return $"Name: {this.Name}, Position: {_position}, Salary: {this.Salary}, Bonus: {this.CalculateBonus():F2}";
    }
}
