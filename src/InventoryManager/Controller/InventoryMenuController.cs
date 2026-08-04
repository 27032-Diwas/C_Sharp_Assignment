using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Repository;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
/// Contains menu and calls inventory controller based on user input.
/// </summary>
public class InventoryMenuController
{
    private readonly InventoryController _inventoryController;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryMenuController"/> class.
    /// </summary>
    /// <param name="inventoryController"> Controller that connect to service. </param>
    public InventoryMenuController(InventoryController inventoryController)
    {
        this._inventoryController = inventoryController;
    }

    /// <summary>
    /// Display the main menu and process the selected option.
    /// </summary>
    public void GetMenuOption()
    {
        while (true)
        {
            MenuConstants.MainMenu choice = DisplayEnum.GetMenuChoice<MenuConstants.MainMenu>(MessageConstants.MainMenu);
            InventoryView.ClearConsole();
            switch (choice)
            {
                case MenuConstants.MainMenu.Exit:
                    InventoryView.DisplayMessage(MessageConstants.ProcessEnded);
                    return;
                case MenuConstants.MainMenu.AddProduct:
                    InventoryView.DisplayMessage(MessageConstants.AddProduct);
                    this._inventoryController.AddProduct();
                    break;
                case MenuConstants.MainMenu.ViewProducts:
                    break;
                case MenuConstants.MainMenu.SearchProduct:
                    InventoryView.DisplayMessage(MessageConstants.SearchProduct);
                    this._inventoryController.SearchProducts();
                    break;
                case MenuConstants.MainMenu.UpdateProduct:
                    break;
                case MenuConstants.MainMenu.RemoveProduct:
                    InventoryView.DisplayMessage(MessageConstants.DeleteProduct);
                    this._inventoryController.RemoveProduct();
                    break;
            }
        }
    }
}
