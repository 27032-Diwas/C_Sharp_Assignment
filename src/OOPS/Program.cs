using OOPS.View;

namespace OOPS;

/// <summary>
/// Entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the application and displays the main menu.
    /// </summary>
    private static void Main()
    {
        MainMenu.GetMenuOption();
        Console.ReadKey();
    }
}