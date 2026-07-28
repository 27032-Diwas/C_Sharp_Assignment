using OOPS.Constants;
using OOPS.EnumConstants;

namespace OOPS.View;

/// <summary>
/// Contains methods related to enum.
/// </summary>
public static class DisplayEnum
{
    /// <summary>
    /// Displays the values in the enum.
    /// </summary>
    /// <param name="menuType"> Enum list. </param>
    public static void DisplayMenu(Type menuType)
    {
        foreach (var value in Enum.GetValues(menuType))
        {
            Console.WriteLine($"{Convert.ToInt32(value)}. {value}");
        }
    }

    /// <summary>
    /// Get user choice from the menu.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="message"> Message to says what menu this is. </param>
    /// <returns>Selected enum value.</returns>
    public static T GetMenuChoice<T>(string message)
        where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine(message);
            DisplayMenu(typeof(T));

            Console.WriteLine(MessageConstants.SelectOption);
            if (Enum.TryParse(Console.ReadLine(), true, out T choice) &&
                Enum.IsDefined(typeof(T), choice))
            {
                return choice;
            }

            Console.Clear();
            Console.WriteLine(MessageConstants.InvalidOption);
        }
    }
}
