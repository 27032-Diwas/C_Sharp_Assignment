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
        JsonRepository jsonRepository = new ();
        IRepository transactionRepository = new TransactionRepository("Transaction.json", jsonRepository);
        IService transactionService = new TransactionService(transactionRepository);
        IView transactionView = new TransactionView();
        IController transactionController = new TransactionController(transactionView, transactionService);
        MainMenuController mainMenuController = new (transactionView, transactionController);
        mainMenuController.GetMenuOption();
    }
}