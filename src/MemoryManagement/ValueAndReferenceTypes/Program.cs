namespace ValueAndReferenceTypes;

/// <summary>
/// Entry point to the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        int number = 10;
        Student student = new ()
        {
            Name = "Diwas",
            Age = 21,
        };

        Console.WriteLine("Before modifying data\n");
        Console.WriteLine($"Value Type [ Integer ] = {number}");
        Console.WriteLine($"Reference type [Student Object] age = {student.Age}");

        Modify(number, student);

        Console.WriteLine("\nAfter modifying data\n");
        Console.WriteLine($"Value Type [ Integer ] = {number}");
        Console.WriteLine($"Reference type [Student Object] age = {student.Age}");

        Console.WriteLine("\nPRESS ANY KEY TO EXIT");
        Console.ReadKey();
    }

    /// <summary>
    /// Modify the data in both value and reference type.
    /// </summary>
    /// <param name="number"> Number - value type. </param>
    /// <param name="student"> Instance of student - reference type. </param>
    public static void Modify(int number, Student student)
    {
        number = 17;
        student.Age = 20;
    }
}