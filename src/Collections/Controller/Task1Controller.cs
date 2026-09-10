using Collections.Constants;
using Collections.Enums;
using Collections.Service;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Coordinates between view and service
/// </summary>
public class Task1Controller
{
    private readonly IView _view;
    private readonly Task1 _task1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task1Controller"/> class.
    /// </summary>
    /// <param name="view"> Instance of view. </param>
    /// <param name="task1"> Instance of task1 service. </param>
    public Task1Controller(IView view, Task1 task1)
    {
        this._view = view;
        this._task1 = task1;
    }

    /// <summary>
    /// Gets task1 menu option.
    /// </summary>
    public void Task1MenuOption()
    {
        while (true)
        {
            try
            {
                Task1Menu choice = this._view.GetMenuChoice<Task1Menu>("Task 1", $"\n{UserPrompts.SelectOption} [ 0 - 4 ]:");
                this._view.ClearConsole();
                switch (choice)
                {
                    case Task1Menu.Back:
                        return;
                    case Task1Menu.AddBook:
                        this.AddBook();
                        break;
                    case Task1Menu.RemoveBook:
                        this.RemoveBook();
                        break;
                    case Task1Menu.CheckBook:
                        this.IsBookExist();
                        break;
                    case Task1Menu.ViewAllBooks:
                        this.DisplayBooks();
                        break;
                    default:
                        this._view.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }

                this._view.GetAnyKey();
            }
            catch (OperationCanceledException)
            {
                this._view.DisplayMessage(ErrorMessages.ProcessCancelled);
                this._view.GetAnyKey();
            }
            catch (Exception ex)
            {
                this._view.DisplayMessage($"Unexpected Error: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Adds book to the list.
    /// </summary>
    private void AddBook()
    {
        string book = this._view.GetStringInput(UserPrompts.GetBook);
        this._task1.AddBook(book);
        this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulAdditionOfBook);
    }

    /// <summary>
    /// Removes book from the list.
    /// </summary>
    private void RemoveBook()
    {
        string book = this._view.GetStringInput(UserPrompts.GetBook);

        if (this._task1.RemoveBook(book))
        {
            this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfBook);
            return;
        }

        this._view.DisplayErrorMessage(ErrorMessages.BookNotFound);
    }

    /// <summary>
    /// Checks for book in list.
    /// </summary>
    private void IsBookExist()
    {
        string book = this._view.GetStringInput(UserPrompts.GetBook);

        if (this._task1.IsBookExist(book))
        {
            this._view.DisplaySuccessMessage(SuccessMessages.BookExist);
            return;
        }

        this._view.DisplayErrorMessage(ErrorMessages.BookNotFound);
    }

    /// <summary>
    /// Display all books in list.
    /// </summary>
    private void DisplayBooks()
    {
        List<string> books = this._task1.GetAllBooks();

        if (!books.Any())
        {
            Console.WriteLine(ErrorMessages.EmptyBookList);
        }

        foreach (string book in books)
        {
            this._view.DisplayMessage(book);
        }
    }
}
