using ExpenseTracker.Constants;
using ExpenseTracker.Enums;
using ExpenseTracker.View;

namespace ExpenseTracker.Controller;

/// <summary>
/// Contains menu and gets user choice.
/// </summary>
public class MainMenuController
{
    private readonly IView _transactionView;
    private readonly IController _transactionController;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenuController"/> class.
    /// </summary>
    /// <param name="transactionView"> Instance of transaction view. </param>
    /// <param name="transactionController"> Instance of transaction controller. </param>
    public MainMenuController(IView transactionView, IController transactionController)
    {
        this._transactionView = transactionView;
        this._transactionController = transactionController;
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
                MainMenu choice = this._transactionView.GetMenuChoice<MainMenu>(HeaderMessages.MainMenu);
                this._transactionView.ClearConsole();
                switch (choice)
                {
                    case MainMenu.Exit:
                        this._transactionView.DisplayMessage(SuccessMessages.ProcessEnded);
                        return;
                    case MainMenu.AddTransaction:
                        this._transactionView.DisplayMessage($"{HeaderMessages.AddTransaction}\n");
                        this._transactionController.AddTransaction();
                        break;
                    case MainMenu.ViewTransactions:
                        this._transactionView.DisplayMessage($"{HeaderMessages.ViewTransaction}\n");
                        this._transactionController.GetAllTransactions();
                        break;
                    case MainMenu.SearchTransaction:
                        this._transactionView.DisplayMessage($"{HeaderMessages.SearchTransaction}\n");
                        this._transactionController.SearchTransaction();
                        break;
                    case MainMenu.EditTransaction:
                        this._transactionView.DisplayMessage($"{HeaderMessages.EditTransaction}\n");
                        this._transactionController.EditTransaction();
                        break;
                    case MainMenu.DeleteTransaction:
                        this._transactionView.DisplayMessage($"{HeaderMessages.DeleteTransaction}\n");
                        this._transactionController.DeleteTransaction();
                        break;
                    case MainMenu.Summary:
                        this._transactionView.DisplayMessage($"{HeaderMessages.Summary}\n");
                        this._transactionController.GetSummary();
                        break;
                    default:
                        this._transactionView.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }

                this._transactionView.GetAnyKey();
            }
            catch (ArgumentException ex)
            {
                this._transactionView.DisplayMessage($"Validation Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                this._transactionView.DisplayMessage($"Operation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                this._transactionView.DisplayMessage($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
