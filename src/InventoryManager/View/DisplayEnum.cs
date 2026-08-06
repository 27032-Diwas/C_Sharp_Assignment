using System.Text.RegularExpressions;
using InventoryManager.Constants;

namespace InventoryManager.View;

/// <summary>
/// Display enum values and get input from user.
/// </summary>
public class DisplayEnum
{
    /// <summary>
    /// Displays all values defined in the specific enum values.
    /// </summary>
    /// <typeparam name="T"> Type : enum </typeparam>
    /// <param name="excluded"> Name of Enum </param>
    public static void DisplayOptions<T>(params T[] excluded)
        where T : Enum
    {
        foreach (T optionCategory in Enum.GetValues(typeof(T)))
        {
            if (excluded.Contains(optionCategory))
            {
                continue;
            }

            string? displayName = Regex.Replace(optionCategory.ToString(), @"(?<!^)([A-Z])", " $1");
            Console.WriteLine($"[{Convert.ToInt32(optionCategory)}] {displayName}");
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
            Console.WriteLine($"{message}\n");
            DisplayOptions<T>();
            Console.WriteLine($"\n{UserPrompts.SelectOption}");
            string input = string.Concat(Console.ReadLine()?.Where(c => !char.IsWhiteSpace(c)) ?? string.Empty);
            if (Enum.TryParse(input, true, out T choice) &&
                Enum.IsDefined(typeof(T), choice))
            {
                return choice;
            }

            Console.Clear();
            Console.WriteLine($"{ErrorMessages.InvalidOption}\n");
        }
    }
}
