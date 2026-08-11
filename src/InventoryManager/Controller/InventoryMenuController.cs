using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
/// Contains menu and gets user choice.
/// </summary>
public class InventoryMenuController
{
    private readonly IController _inventoryController;
    private readonly IView _inventoryView;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryMenuController"/> class.
    /// </summary>
    /// <param name="inventoryController"> Instance of inventory controller. </param>
    /// <param name="inventoryView"> Instance of inventory view. </param>
    public InventoryMenuController(IView inventoryView, IController inventoryController)
    {
        this._inventoryView = inventoryView;
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
                MainMenuEnum choice = this._inventoryView.GetMenuChoice<MainMenuEnum>(HeaderMessages.MainMenu);
                this._inventoryView.ClearConsole();
                switch (choice)
                {
                    case MainMenuEnum.Exit:
                        this._inventoryView.DisplayMessage(SuccessMessages.ProcessEnded);
                        return;
                    case MainMenuEnum.AddProduct:
                        this._inventoryView.DisplayMessage($"{HeaderMessages.AddProduct}\n");
                        this._inventoryController.AddProduct();
                        break;
                    case MainMenuEnum.ViewProducts:
                        this._inventoryView.DisplayMessage($"{HeaderMessages.ViewProducts}\n");
                        this._inventoryController.ViewAllProducts();
                        break;
                    case MainMenuEnum.SearchProduct:
                        this._inventoryView.DisplayMessage($"{HeaderMessages.SearchProduct}\n");
                        this._inventoryController.SearchProducts();
                        break;
                    case MainMenuEnum.UpdateProduct:
                        this._inventoryView.DisplayMessage($"{HeaderMessages.UpdateProduct}\n");
                        this._inventoryController.UpdateProduct();
                        break;
                    case MainMenuEnum.RemoveProduct:
                        this._inventoryView.DisplayMessage($"{HeaderMessages.DeleteProduct}\n");
                        this._inventoryController.RemoveProduct();
                        break;
                    default:
                        this._inventoryView.DisplayMessage($"{ErrorMessages.InvalidOption}\n");
                        break;
                }

                this._inventoryView.GetAnyKey();
            }
            catch (ArgumentException ex)
            {
                this._inventoryView.DisplayMessage($"Validation Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                this._inventoryView.DisplayMessage($"Operation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                this._inventoryView.DisplayMessage($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
