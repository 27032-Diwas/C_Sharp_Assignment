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
    /// Display the main menu and proceed to selected option.
    /// </summary>
    public void GetMenuOption()
    {
        while (true)
        {
            MainMenuEnum choice = DisplayEnum.GetMenuChoice<MainMenuEnum>(MessageConstants.MainMenu);
            InventoryView.ClearConsole();
            switch (choice)
            {
                case MainMenuEnum.Exit:
                    InventoryView.DisplayMessage(MessageConstants.ProcessEnded);
                    return;
                case MainMenuEnum.AddProduct:
                    InventoryView.DisplayMessage(MessageConstants.AddProduct);
                    this._inventoryController.AddProduct();
                    break;
                case MainMenuEnum.ViewProducts:
                    break;
                case MainMenuEnum.SearchProduct:
                    break;
                case MainMenuEnum.UpdateProduct:
                    break;
                case MainMenuEnum.RemoveProduct:
                    break;
                default:
                    InventoryView.DisplayMessage(MessageConstants.InvalidOption);
                    break;
            }
        }
    }
}
