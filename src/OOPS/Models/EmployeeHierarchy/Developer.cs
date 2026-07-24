namespace OOPS.Models.EmployeeHierarchy;

/// <summary>
/// Developer class inheriting employee class.
/// </summary>
public class Developer : Employee
{
    private const string _position = "Developer";

    /// <summary>
    /// Initializes a new instance of the <see cref="Developer"/> class.
    /// </summary>
    /// <param name="name"> Employee name.</param>
    /// <param name="salary"> Employee salary. </param>
    public Developer(string name, decimal salary)
        : base(name, salary)
    {
    }

    /// <summary>
    /// Calculate bonus of developer.
    /// </summary>
    /// <returns> Bonus of developer in double. </returns>
    public override double CalculateBonus()
    {
        return (double)this.Salary * 0.15;
    }

    /// <summary>
    /// Displays details such as name, salary, position and bonus.
    /// </summary>
    /// <returns> Details as a string. </returns>
    public override string PrintDetails()
    {
        return $"Name: {this.Name}, Position: {_position}, Salary: {this.Salary}, Bonus: {this.CalculateBonus():F2}";
    }
