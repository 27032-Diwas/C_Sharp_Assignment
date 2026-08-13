using InventoryManager.Controller;
using InventoryManager.Repository;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager;

/// <summary>
/// Entry point of the applications.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the application and display the main menu.
    /// </summary>
    public static void Main()
    {
        InventoryRepository inventoryRepository = new ();
        InventoryService inventoryService = new (inventoryRepository);
        InventoryView inventoryView = new ();
        InventoryController inventoryController = new (inventoryView, inventoryService);
        InventoryMenuController inventoryMenuController = new (inventoryView, inventoryController);
        inventoryMenuController.GetMenuOption();
        Console.ReadKey();
    }
}