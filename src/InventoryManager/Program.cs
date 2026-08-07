using InventoryManager.Controller;
using InventoryManager.Repository;
using InventoryManager.Service;

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
        InMemoryRepository repository = new ();
        InventoryRepository inventoryRepository = new (repository, repository);
        InventoryService inventoryService = new (inventoryRepository);
        InventoryController inventoryController = new (inventoryService);
        InventoryMenuController inventoryMenuController = new (inventoryController);
        inventoryMenuController.GetMenuOption();
        Console.ReadKey();
    }
}