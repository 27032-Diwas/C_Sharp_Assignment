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
        IFileRepository jsonRepository = new JsonRepository();
        IRepository transactionRepository = new TransactionRepository("Transaction.json", jsonRepository);
        IService transactionService = new TransactionService(transactionRepository);
        IView transactionView = new TransactionView();
        IController transactionController = new TransactionController(transactionView, transactionService);
        MainMenuController mainMenuController = new (transactionView, transactionController);

        AppDomain.CurrentDomain.ProcessExit += (_, _) => transactionController.SaveData();
        Console.CancelKeyPress += (_, eventArgs) =>
        {
            transactionController.SaveData();
            eventArgs.Cancel = false;
            Environment.Exit(0);
        };

        mainMenuController.GetMenuOption();
    }
}