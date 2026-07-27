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
}
