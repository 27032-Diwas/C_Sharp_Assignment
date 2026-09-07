using IDisposableDemo;

namespace IDisposableDemo;

/// <summary>
/// Entry point to the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the program.
    /// </summary>
    public static void Main()
    {
        InitialWrite();

        Console.WriteLine("File opened, used write operation and closed file using Dispose method.");

        Console.WriteLine("-------------------------------------------------------\n");

        WriteWithUsing();

        Console.WriteLine("File opened again with using statement and used write operation.");

        Console.WriteLine("-------------------------------------------------------\n");

        Read();

        Console.WriteLine("Read content in the file.");
        Console.ReadKey();
    }

    /// <summary>
    /// Writes first set of statement into the file.
    /// </summary>
    public static void InitialWrite()
    {
        FileOperation fileOperation = new ("File.txt");
        fileOperation.Write("Initial write operation.");
        fileOperation.Dispose();
        Read();
    }

    /// <summary>
    /// Writes into file with using statement.
    /// </summary>
    public static void WriteWithUsing()
    {
        try
        {
            using (FileOperation fileOperation = new ("File.txt"))
            {
                fileOperation.Write("File implementation with using statement.");
            }

            Read();
        }
        catch (IOException)
        {
            Console.WriteLine("File is not disposed properly.");
        }
    }

    /// <summary>
    /// Reads the content from the file.
    /// </summary>
    public static void Read()
    {
        try
        {
            using StreamReader streamReader = new ("File.txt");
            string content = streamReader.ReadToEnd();

            Console.WriteLine($"Content in the file : {content}");
        }
        catch (IOException)
        {
            Console.WriteLine("File is held by some other operation.");
        }
    }
}