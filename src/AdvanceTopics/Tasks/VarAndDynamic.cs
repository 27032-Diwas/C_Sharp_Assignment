namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstration of var and dynamic keywords.
/// </summary>
public class VarAndDynamic
{
    /// <summary>
    /// Demonstrate the difference between var and dynamic keyword.
    /// </summary>
    public void Demonstrate()
    {
        var variable1 = 2;
        Console.WriteLine($"Type of var at beginning is {variable1.GetType()}");

        dynamic variable2 = 3;
        Console.WriteLine($"Type of dynamic at beginning is {variable2.GetType()}");

        variable2 = "Hello";
        Console.WriteLine($"Type of dynamic after changing value is {variable2.GetType()}");
    }
}
