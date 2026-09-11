using Collections.Constants;
using Collections.Enums;
using Collections.Service;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Coordinates between view and service.
/// </summary>
public class Task3Controller
{
    private readonly IView _view;
    private readonly Task3<string> _task3;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task3Controller"/> class.
    /// </summary>
    /// <param name="view"> Instance of view. </param>
    /// <param name="task3"> Instance of task 3 service. </param>
    public Task3Controller(IView view, Task3<string> task3)
    {
        this._view = view;
        this._task3 = task3;
    }

    /// <summary>
    /// Gets task 3 menu option.
    /// </summary>
    public void Task3MenuOption()
    {
        while (true)
        {
            try
            {
                Task3Menu choice = this._view.GetMenuChoice<Task3Menu>(MainMenu.Queue.ToString(), $"\n{UserPrompts.SelectOption} [ 0 - {Enum.GetValues<Task3Menu>().Length - 1} ]:");
                this._view.ClearConsole();
                switch (choice)
                {
                    case Task3Menu.Back:
                        return;
                    case Task3Menu.AddPerson:
                        this._view.DisplayMessage($"{UserPrompts.GetExitCommand}\n");
                        this.AddPerson();
                        break;
                    case Task3Menu.RemovePerson:
                        this.RemovePerson();
                        break;
                    case Task3Menu.ViewQueue:
                        this.DisplayQueue();
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
    /// Adds person to the list.
    /// </summary>
    private void AddPerson()
    {
        string person = this._view.GetStringInput(UserPrompts.GetPersonName);
        this._task3.AddItem(person);
        this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulAdditionOfPerson);
    }

    /// <summary>
    /// Removes person from the list.
    /// </summary>
    private void RemovePerson()
    {
        if (this._task3.RemoveItem())
        {
            this._view.DisplaySuccessMessage(SuccessMessages.SuccessfulRemovalOfPerson);
            return;
        }

        this._view.DisplayErrorMessage(ErrorMessages.EmptyQueue);
    }

    /// <summary>
    /// Display all people in queue.
    /// </summary>
    private void DisplayQueue()
    {
        Queue<string> queue = this._task3.GetQueue();

        if (!queue.Any())
        {
            this._view.DisplayErrorMessage(ErrorMessages.EmptyQueue);
            return;
        }

        int i = 1;
        foreach (string person in queue)
        {
            this._view.DisplayMessage($"{i++} : {person}");
        }
    }
}
