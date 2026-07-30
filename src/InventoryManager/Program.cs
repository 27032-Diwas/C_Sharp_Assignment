using InventoryManager.Controller;

namespace InventoryManager;

/// <summary>
/// Entry point of the applications.
/// </summary>
internal class Program
{
    /// <summary>
    /// Start the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        InventoryMenuController.GetMenuOption();
        Console.ReadKey();
    }
}