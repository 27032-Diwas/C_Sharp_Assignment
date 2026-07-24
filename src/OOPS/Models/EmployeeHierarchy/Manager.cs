namespace OOPS.Models.EmployeeHierarchy;

public class Manager
{
    public Manager(string name, decimal salary)
    {
        this.Name = name;
        this.Salary = salary;
    }

    public string Name { get; set; }
    public decimal Salary { get; set; }

    public abstract double CalculateBonus();

    public abstract string PrintDetails();
}
