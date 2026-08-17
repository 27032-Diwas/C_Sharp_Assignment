using ExpenseTracker.Controller;
using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace ExpenseTracker;

/// <summary>
/// Entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        TransactionRepository transactionRepository = new ();
        TransactionService transactionService = new (transactionRepository);
        TransactionView transactionView = new ();
        TransactionController transactionController = new (transactionView, transactionService);
        MainMenuController mainMenuController = new (transactionView, transactionController);
        mainMenuController.GetMenuOption();
    }
}