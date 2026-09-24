using Collections.Constants;
using Collections.Enums;
using Collections.Service;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Coordinates between view and service.
/// </summary>
public class Task1Controller
{
    private readonly IView _view;
    private readonly Task1<string> _task1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task1Controller"/> class.
    /// </summary>
    /// <param name="view"> Instance of view. </param>
    /// <param name="task1"> Instance of task 1 service. </param>
    public Task1Controller(IView view, Task1<string> task1)
    {
        this._view = view;
        this._task1 = task1;
    }

    /// <summary>
    /// Gets task 1 menu option.
    /// </summary>
    public void Task1MenuOption()
    {
        while (true)
        {
            try
            {
                Task1Menu choice = this._view.GetMenuChoice<Task1Menu>(MainMenu.List.ToString(), $"\n{UserPrompts.SelectOption} [ 0 - {Enum.GetValues<Task1Menu>().Length - 1} ]:");
                this._view.ClearConsole();
                switch (choice)
                {
                    case Task1Menu.Back:
                        return;
                    case Task1Menu.AddBook:
                        this._view.DisplayMessage($"{UserPrompts.GetExitCommand}\n");
                        this.AddBook();
                        break;
                    case Task1Menu.RemoveBook:
                        this._view.DisplayMessage($"{UserPrompts.GetExitCommand}\n");
                        this.RemoveBook();
                        break;
                    case Task1Menu.CheckBook:
                        this._view.DisplayMessage($"{UserPrompts.GetExitCommand}\n");
                        this.CheckBookExist();
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
                this._view.DisplaySuccessMessage(ErrorMessages.ProcessCancelled);
                this._view.GetAnyKey();
            }
            catch (Exception)
            {
                this._view.DisplayErrorMessage(ErrorMessages.ExceptionMessage);
            }
        }
    }

    /// <summary>
    /// Adds book to the list.
    /// </summary>
    private void AddBook()
    {
        string book = this._view.GetStringInput(UserPrompts.GetBook);
        this._task1.AddItem(book);
        this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulAdditionOfBook);
    }

    /// <summary>
    /// Removes book from the list.
    /// </summary>
    private void RemoveBook()
    {
        string book = this._view.GetStringInput(UserPrompts.GetBook);

        if (!this._task1.RemoveItem(book))
        {
            this._view.DisplayErrorMessage(ErrorMessages.BookNotFound);
            return;
        }

        this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfBook);
    }

    /// <summary>
    /// Checks for book in list.
    /// </summary>
    private void CheckBookExist()
    {
        string book = this._view.GetStringInput(UserPrompts.GetBook);

        if (this._task1.IsItemExist(book))
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
        IReadOnlyList<string> books = this._task1.GetAllItems();

        if (!books.Any())
        {
            this._view.DisplayErrorMessage(ErrorMessages.EmptyBookList);
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            string book = books[i];
            this._view.DisplayMessage($"{i + 1} : {book}");
        }
    }
}
