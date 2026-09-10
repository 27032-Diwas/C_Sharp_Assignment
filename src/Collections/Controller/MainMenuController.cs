using Collections.Constants;
using Collections.Enums;
using Collections.View;

namespace Collections.Controller;

/// <summary>
/// Contains menu and gets user choice.
/// </summary>
public class MainMenuController
{
    private readonly IView _view;
    private readonly Task1Controller _task1Controller;
    private readonly Task2Controller _task2Controller;
    private readonly Task3Controller _task3Controller;
    private readonly Task4Controller _task4Controller;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenuController"/> class.
    /// </summary>
    /// <param name="view"> Instance of collection view. </param>
    /// <param name="task1Controller"> Instance of task 1 controller. </param>
    /// <param name="task2Controller"> Instance of task 2 controller. </param>
    /// <param name="task3Controller"> Instance of task 3 controller. </param>
    /// <param name="task4Controller"> Instance of task 4 controller. </param>
    public MainMenuController(IView view, Task1Controller task1Controller, Task2Controller task2Controller, Task3Controller task3Controller, Task4Controller task4Controller)
    {
        this._view = view;
        this._task1Controller = task1Controller;
        this._task2Controller = task2Controller;
        this._task3Controller = task3Controller;
        this._task4Controller = task4Controller;
    }

    /// <summary>
    /// Displays the main menu and proceed to selected option.
    /// </summary>
    public void GetMenuOption()
    {
        while (true)
        {
            try
            {
                MainMenu choice = this._view.GetMenuChoice<MainMenu>("Main Menu", $"\n{UserPrompts.SelectOption} [ 0 - 3 ]:");
                this._view.ClearConsole();
                switch (choice)
                {
                    case MainMenu.Exit:
                        this._view.DisplayMessage(ErrorMessages.ApplicationClosed);
                        this._view.GetAnyKey();
                        return;
                    case MainMenu.List:
                        this._view.DisplayMessage(MainMenu.List.ToString());
                        this._task1Controller.Task1MenuOption();
                        break;
                    case MainMenu.Stack:
                        this._view.DisplayMessage(MainMenu.Stack.ToString());
                        this._task2Controller.ReverseWord();
                        break;
                    case MainMenu.Queue:
                        this._view.DisplayMessage(MainMenu.Queue.ToString());
                        this._task3Controller.Task3MenuOption();
                        break;
                    case MainMenu.Dictionary:
                        this._view.DisplayMessage(MainMenu.Dictionary.ToString());
                        this._task4Controller.Task4MenuOption();
                        break;
                    default:
                        this._view.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                this._view.DisplayMessage(ErrorMessages.ProcessCancelled);
                this._view.GetAnyKey();
            }
            catch (Exception)
            {
                this._view.DisplayMessage("Something went wrong, Try again!!");
            }
        }
    }
}
