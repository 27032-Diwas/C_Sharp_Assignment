using InventoryManager.Controller;
using InventoryManager.Repository;
using InventoryManager.Service;

namespace InventoryManager;

/// <summary>
/// Entry point of the applications.
/// </summary>
/// 
internal class Program
{
    /// <summary>
    /// Starts the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        InventoryRepository inventoryRepository = new ();
        InventoryService inventoryService = new (inventoryRepository);
        InventoryController inventoryController = new (inventoryService);
        InventoryMenuController inventoryMenuController = new (inventoryController);
        inventoryMenuController.GetMenuOption();
        Console.ReadKey();
    }
}