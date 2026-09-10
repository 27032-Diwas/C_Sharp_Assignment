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
    private readonly Task1Controller _collectionController;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenuController"/> class.
    /// </summary>
    /// <param name="view"> Instance of collection view. </param>
    /// <param name="collectionController"> Instance of collection controller. </param>
    public MainMenuController(IView view, Task1Controller collectionController)
    {
        this._view = view;
        this._collectionController = collectionController;
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
                MainMenu choice = this._view.GetMenuChoice<MainMenu>("Main Menu", $"\n{UserPrompts.SelectOption} [ 0 - 5 ]:");
                this._view.ClearConsole();
                switch (choice)
                {
                    case MainMenu.Exit:
                        this._view.DisplayMessage(ErrorMessages.ApplicationClosed);
                        this._view.GetAnyKey();
                        return;
                    case MainMenu.List:
                        this._view.DisplayMessage(MainMenu.List.ToString());
                        this._collectionController.Task1MenuOption();
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
            catch (Exception ex)
            {
                this._view.DisplayMessage($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
