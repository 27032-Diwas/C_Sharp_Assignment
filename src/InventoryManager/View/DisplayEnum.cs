using InventoryManager.Constants;

namespace InventoryManager.View;

/// <summary>
/// Display enum values and get input from user.
/// </summary>
public class DisplayEnum
{
    /// <summary>
    /// Displays all values defined in the specified enumeration.
    /// </summary>
    /// <param name="menuType"> The enumeration type to display. </param>
    public static void DisplayMenu(Type menuType)
    {
        foreach (var value in Enum.GetValues(menuType))
        {
            Console.WriteLine($"{Convert.ToInt32(value)}. {value}");
        }
    }

    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    public static T GetMenuChoice<T>(string message)
        where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine(message);
            DisplayMenu(typeof(T));

            Console.WriteLine(UserPrompts.SelectOption);
            if (Enum.TryParse(Console.ReadLine(), true, out T choice) &&
                Enum.IsDefined(typeof(T), choice))
            {
                return choice;
            }

            Console.Clear();
            Console.WriteLine(ErrorMessages.InvalidOption);
        }
    }
}
