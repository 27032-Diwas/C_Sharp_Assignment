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
            Task1 task1 = new ();
            Task1Controller task1Controller = new Task1Controller(view, task1);
            MainMenuController mainMenuController = new MainMenuController(view, task1Controller);

            mainMenuController.GetMenuOption();
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong, Try again!!");
        }
    }
}