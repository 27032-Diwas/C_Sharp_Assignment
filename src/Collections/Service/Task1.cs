namespace Collections.Service;

/// <summary>
/// Contains operations such as add, view and remove books.
/// </summary>
/// <typeparam name="T"> Type of item to be in list (string for books). </typeparam>
public class Task1<T>
{
    private readonly List<T> _books = new ();

    /// <summary>
    /// Adds book to the list.
    /// </summary>
    /// <param name="book"> Name of the book. </param>
    public void AddBook(T book) => this._books.Add(book);

    /// <summary>
    /// Removes book from the list.
    /// </summary>
    /// <param name="book"> Title of the book. </param>
    /// <returns> True if book is removed successfully otherwise false. </returns>
    public bool RemoveBook(T book)
    {
        if (this.IsBookExist(book))
        {
            this._books.Remove(book);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if book exist in list or not.
    /// </summary>
    /// <param name="book"> Title of the book. </param>
    /// <returns> True if book exist; otherwise false. </returns>
    public bool IsBookExist(T book) => this._books.Contains(book);

    /// <summary>
    /// Gets all books from the list.
    /// </summary>
    /// <returns> List of books. </returns>
    public List<T> GetAllBooks() => this._books;
}
