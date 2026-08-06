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
            try
            {
                MainMenuEnum choice = DisplayEnum.GetMenuChoice<MainMenuEnum>(HeaderMessages.MainMenu);
                InventoryView.ClearConsole();
                switch (choice)
                {
                    case MainMenuEnum.Exit:
                        InventoryView.DisplayMessage(SuccessMessages.ProcessEnded);
                        return;
                    case MainMenuEnum.AddProduct:
                        InventoryView.DisplayMessage($"{HeaderMessages.AddProduct}\n");
                        this._inventoryController.AddProduct();
                        break;
                    case MainMenuEnum.ViewProducts:
                        InventoryView.DisplayMessage($"{HeaderMessages.ViewProducts}\n");
                        this._inventoryController.ViewAllProducts();
                        break;
                    case MainMenuEnum.SearchProduct:
                        InventoryView.DisplayMessage($"{HeaderMessages.SearchProduct}\n");
                        this._inventoryController.SearchProducts();
                        break;
                    case MainMenuEnum.UpdateProduct:
                        InventoryView.DisplayMessage($"{HeaderMessages.UpdateProduct}\n");
                        this._inventoryController.UpdateProduct();
                        break;
                    case MainMenuEnum.RemoveProduct:
                        InventoryView.DisplayMessage($"{HeaderMessages.DeleteProduct}\n");
                        this._inventoryController.RemoveProduct();
                        break;
                    default:
                        InventoryView.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }

                InventoryView.GetAnyKey();
            }
            catch (ArgumentException ex)
            {
                InventoryView.DisplayMessage($"Validation Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                InventoryView.DisplayMessage($"Operation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                InventoryView.DisplayMessage($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
