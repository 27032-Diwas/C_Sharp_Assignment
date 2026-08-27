using LINQ.Enums;
using LINQ.Service;
using LINQ.View;

namespace LINQ;

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
        LinqView view = new ();
        Task1 task1 = new ();
        Task2 task2 = new ();
        Task3 task3 = new ();
        Task4 task4 = new ();
        Task5 task5 = new ();

        while (true)
        {
            view.DisplayMessage("Welcome");

            MainMenu choice = view.GetMenuChoice<MainMenu>("Main Menu");

            switch (choice)
            {
                case MainMenu.Exit:
                    return;
                case MainMenu.Task1:
                    task1.GetTask1Products();
                    break;
                case MainMenu.Task2:
                    task2.GetTask2Products();
                    break;
                case MainMenu.Task3:
                    task3.GetTask3Products();
                    break;
                case MainMenu.Task4:
                    task4.GetTask4Products();
                    break;
                case MainMenu.Task5:
                    task5.Run();
                    break;
            }

            view.GetAnyKey();
        }
    }
}