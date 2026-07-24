using OOPS.View;

namespace OOPS;

/// <summary>
/// OOPS Assignment
/// </summary>
internal class Program
{
    /// <summary>
    /// Main class where program starts.
    /// </summary>
    /// <param name="args"> Argument. </param>
    private static void Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();

        mainMenu.GetMenuOption();
        Console.ReadKey();
    }
}