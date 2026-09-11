using Collections.Controller;
using Collections.Service;
using Collections.View;

namespace Collections;

/// <summary>
/// Entry point to the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the application.
    /// </summary>
    public static void Main()
    {
        try
        {
            IView view = new CollectionView();
            Task1<string> task1 = new ();
            Task1Controller task1Controller = new (view, task1);

            Task2<char> task2 = new ();
            Task2Controller task2Controller = new (view, task2);

            Task3<string> task3 = new ();
            Task3Controller task3Controller = new (view, task3);

            Task4<string, double> task4 = new ();
            Task4Controller task4Controller = new (view, task4);

            Task6 task6 = new ();
            Task6Controller task6Controller = new (view, task6);

            MainMenuController mainMenuController = new (view, task1Controller, task2Controller, task3Controller, task4Controller, task6Controller);

            mainMenuController.GetMenuOption();
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong, Try again!!");
        }
    }
}