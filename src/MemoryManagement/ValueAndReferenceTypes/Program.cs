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

        CreateLargeList();
        CalculateLargeQuantity();

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

    /// <summary>
    /// Create a large list of integer.
    /// </summary>
    public static void CreateLargeList()
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < 1000000; i++)
        {
            numbers.Add(i);
        }
    }

    /// <summary>
    /// Creates large local variable and calculate sum.
    /// </summary>
    public static void CalculateLargeQuantity()
    {
        int number1 = 1;
        int number2 = 2;
        int number3 = 3;
        int number4 = 4;
        int number5 = 5;
        int number6 = 6;
        int number7 = 7;
        int number8 = 8;
        int number9 = 9;
        int number10 = 10;
        int number11 = 11;
        int number12 = 12;
        int number13 = 13;
        int number14 = 14;
        int number15 = 15;
        int number16 = 16;
        int number17 = 17;
        int number18 = 18;
        int number19 = 19;
        int number20 = 20;
        int number21 = 21;
        int number22 = 22;
        int number23 = 23;
        int number24 = 24;
        int number25 = 25;
        int number26 = 26;
        int number27 = 27;
        int number28 = 28;
        int number29 = 29;
        int number30 = 30;
        int number31 = 31;
        int number32 = 32;
        int number33 = 33;
        int number34 = 34;
        int number35 = 35;
        int number36 = 36;
        int number37 = 37;
        int number38 = 38;
        int number39 = 39;
        int number40 = 40;
        int number41 = 41;
        int number42 = 42;
        int number43 = 43;
        int number44 = 44;
        int number45 = 45;
        int number46 = 46;
        int number47 = 47;
        int number48 = 48;
        int number49 = 49;
        int number50 = 50;

        int sum = number1 + number2 + number3 + number4 + number5 + number6 + number7 + number8 + number9 + number10 + number11 + number12 + number13 + number14 + number15
            + number16 + number17 + number18 + number19 + number20 + number21 + number22 + number23 + number24 + number25 + number26 + number27 + number28 + number29 + number30
            + number31 + number32 + number33 + number34 + number35 + number36 + number37 + number38 + number39 + number40 + number41 + number42 + number43 + number44 + number45
            + number46 + number47 + number48 + number49 + number50;
    }
}