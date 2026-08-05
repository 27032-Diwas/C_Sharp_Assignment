using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.Repository;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
/// Contains menu and gets user choice.
/// </summary>
public class InventoryMenuController
{
    private readonly InventoryController _inventoryController;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryMenuController"/> class.
    /// </summary>
    /// <param name="inventoryController"> Instance of inventory controller. </param>
    public InventoryMenuController(InventoryController inventoryController)
    {
        this._inventoryController = inventoryController;
    }

    /// <summary>
    /// Displays the main menu and proceed to selected option.
    /// </summary>
    public void GetMenuOption()
    {
        while (true)
        {
            MainMenuEnum choice = DisplayEnum.GetMenuChoice<MainMenuEnum>(HeaderMessages.MainMenu);
            InventoryView.ClearConsole();
            switch (choice)
            {
                case MainMenuEnum.Exit:
                    InventoryView.DisplayMessage(SuccessMessages.ProcessEnded);
                    return;
                case MainMenuEnum.AddProduct:
                    InventoryView.DisplayMessage(HeaderMessages.AddProduct);
                    this._inventoryController.AddProduct();
                    break;
                case MainMenuEnum.ViewProducts:
                    break;
                case MainMenuEnum.SearchProduct:
                    InventoryView.DisplayMessage(HeaderMessages.SearchProduct);
                    this._inventoryController.SearchProducts();
                    break;
                case MainMenuEnum.UpdateProduct:
                    InventoryView.DisplayMessage(HeaderMessages.UpdateProduct);
                    this._inventoryController.UpdateProduct();
                    break;
                case MainMenuEnum.RemoveProduct:
                    break;
                default:
                    InventoryView.DisplayMessage(ErrorMessages.InvalidOption);
                    break;
            }
        }
    }
}
