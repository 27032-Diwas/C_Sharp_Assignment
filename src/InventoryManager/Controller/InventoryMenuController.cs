using InventoryManager.Constants;
using InventoryManager.EnumConstants;
using InventoryManager.View;

namespace InventoryManager.Controller;

/// <summary>
/// Contains method related to menu options and calls inventory controller.
/// </summary>
public class InventoryMenuController
{
    /// <summary>
    /// Display the main menu and process the selected option.
    /// </summary>
    public static void GetMenuOption()
    {
        while (true)
        {
            MenuConstants.MainMenu choice = InventoryEnumView.GetMenuChoice<MenuConstants.MainMenu>(MessageConstants.MainMenu);

            switch (choice)
            {
                case MenuConstants.MainMenu.Exit:
                    return;
                case MenuConstants.MainMenu.AddProduct:
                    break;
                case MenuConstants.MainMenu.ViewProducts:
                    break;
                case MenuConstants.MainMenu.SearchProduct:
                    break;
                case MenuConstants.MainMenu.UpdateProduct:
                    break;
                case MenuConstants.MainMenu.RemoveProduct:
                    break;
            }
        }
    }
}
