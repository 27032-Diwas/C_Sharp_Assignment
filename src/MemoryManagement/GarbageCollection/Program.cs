namespace GarbageCollection;

/// <summary>
/// Entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts and run the program.
    /// </summary>
    public static void Main()
    {
        List<Student> students = CreateStudent();

        Console.WriteLine("Large number of object created successfully");

        students = null!;

        Console.WriteLine("Large number of object destroyed successfully");

        GC.Collect();

        Console.ReadKey();
    }

    /// <summary>
    /// Create large number of student.
    /// </summary>
    /// <returns> List of students. </returns>
    public static List<Student> CreateStudent()
    {
        List<Student> students = new ();

        for (int i = 0; i < 10000000; i++)
        {
            students.Add(new Student());
        }

        return students;
    }
}
