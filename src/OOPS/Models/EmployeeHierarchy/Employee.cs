namespace OOPS.Models.EmployeeHierarchy;

/// <summary>
/// Abstract shape call containing employee property and calculate bonus, print details methods.
/// </summary>
public abstract class Employee
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> class.
    /// </summary>
    /// <param name="name"> Name of the employee. </param>
    /// <param name="salary"> Employee salary. </param>
    public Employee(string name, decimal salary)
    {
        this.Name = name;
        this.Salary = salary;
    }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Name of employee.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> Employee salary. </value>
    public decimal Salary { get; set; }

    /// <summary>
    /// Calculates bonus of employee.
    /// </summary>
    /// <returns> Bonus in double. </returns>
    public abstract double CalculateBonus();

    /// <summary>
    /// Displays the details of the employee.
    /// </summary>
    /// <returns> Details as a string. </returns>
    public abstract string PrintDetails();
}
