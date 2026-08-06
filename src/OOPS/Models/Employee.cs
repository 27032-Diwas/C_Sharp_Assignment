namespace OOPS.Models;

/// <summary>
/// Represents an abstract employee that contains employee properties and defines
/// methods for calculating bonuses and printing employee details.
/// </summary>
public abstract class Employee
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> class.
    /// </summary>
    /// <param name="name"> The name of the employee. </param>
    /// <param name="salary"> The salary of the employee. </param>
    public Employee(string name, decimal salary)
    {
        this.Name = name;
        this.Salary = salary;
    }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> The name of the employee. </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets.
    /// </summary>
    /// <value> The salary of the employee. </value>
    public decimal Salary { get; set; }

    /// <summary>
    /// Calculates the bonus for the employee.
    /// </summary>
    /// <returns>
    /// The calculated bonus amount.
    /// </returns>
    public abstract double CalculateBonus();

    /// <summary>
    /// Returns the details of the employee.
    /// </summary>
    /// <returns>
    /// A string that represents the employee details.
    /// </returns>
    public abstract string PrintDetails();
}