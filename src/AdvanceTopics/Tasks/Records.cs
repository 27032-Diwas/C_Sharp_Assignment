namespace AdvanceTopics.Tasks;

/// <summary>
/// Demonstrate record usage.
/// </summary>
public class Records
{
    private record Book(string title, string author, string isbn);

    /// <summary>
    /// Demonstrate the task.
    /// </summary>
    public void Demonstrate()
    {
        Book book1 = new (
            "The Pragmatic Programmer",
            "Andrew Hunt",
            "9780201616224");

        Book book2 = new (
            "Clean Code",
            "Robert C. Martin",
            "9780132350884");

        Book book3 = new (
            "The Pragmatic Programmer",
            "Andrew Hunt",
            "9780201616224");

        Console.WriteLine("\nBook Details\n");
        DisplayBook(book1);
        DisplayBook(book2);

        Console.WriteLine("\nValue Equality\n");
        Console.WriteLine($"book1 == book3 : {book1 == book3}");
        Console.WriteLine($"book1.Equals(book3) : {book1.Equals(book3)}");

        Console.WriteLine("\nImmutability\n");

        // The following line causes a compilation error because
        // positional record properties are init-only.
        //
        // book1.Title = "New Title";
        //
        // Error:
        // Init-only property can only be assigned during object initialization.
        Console.WriteLine("Record properties cannot be modified after creation.");

        Console.WriteLine("\nUsing 'with' Expression\n");

        Book updatedBook = book1 with
        {
            title = "The Pragmatic Programmer - 20th Anniversary Edition",
            author = "Me"
        };

        Console.WriteLine("Original Book\n");
        DisplayBook(book1);
        Console.WriteLine("Modified Book\n");
        DisplayBook(updatedBook);

        Console.WriteLine("\nDisplay Using Deconstruction\n");
        DisplayBook(book1);
        DisplayBook(updatedBook);
    }

    /// <summary>
    /// Displays book details using deconstruction.
    /// </summary>
    /// <param name="book"> Book to display. </param>
    private static void DisplayBook(Book book)
    {
        var (title, author, isbn) = book;

        Console.WriteLine($"Title: {title}, Author: {author}, ISBN: {isbn}");
    }
}