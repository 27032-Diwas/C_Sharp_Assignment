namespace Collections.Service;

/// <summary>
/// Contains operations such as add, view and remove books.
/// </summary>
public class Task1
{
    private List<string> _books = new ();

    /// <summary>
    /// Adds book to the list.
    /// </summary>
    /// <param name="book"> Name of the book. </param>
    public void AddBook(string book) => this._books.Add(book);

    /// <summary>
    /// Removes book from the list.
    /// </summary>
    /// <param name="book"> Name of the book. </param>
    /// <returns> True if book is removed successfully otherwise false. </returns>
    public bool RemoveBook(string book)
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
    /// <param name="book"> Name of the book. </param>
    /// <returns> True if book exist; otherwise false. </returns>
    public bool IsBookExist(string book) => this._books.Contains(book);

    /// <summary>
    /// Gets all book from the list.
    /// </summary>
    /// <returns> List of books. </returns>
    public List<string> GetAllBooks() => this._books;
}
