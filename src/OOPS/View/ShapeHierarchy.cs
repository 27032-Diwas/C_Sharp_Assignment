using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Services.ShapeHierarchy;

namespace OOPS.View;

/// <summary>
/// Contains methods related to shape hierarchy.
/// </summary>
public class ShapeHierarchy
{
    /// <summary>
    /// Get shape menu choice from user.
    /// </summary>
    public void GetMenuOption()
    {
        bool isValidMenuOption = true;

        while (isValidMenuOption)
        {
            DisplayMenu();

            Console.WriteLine(MessageConstants.SelectOption);
            var isParsed = Enum.TryParse<MenuContent.ShapeMenu>(Console.ReadLine(), true, out MenuContent.ShapeMenu choice);
            if (!isParsed || !Enum.IsDefined(typeof(MenuContent.ShapeMenu), choice))
            {
                Console.Clear();
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

            Console.Clear();
            switch (choice)
            {
                case MenuContent.ShapeMenu.Back:
                    return;
                case MenuContent.ShapeMenu.Rectangle:
                    this.Rectangle();
                    break;
                case MenuContent.ShapeMenu.Circle:
                    this.Circle();
                    break;
            }
        }
    }

    /// <summary>
    /// Displays shpae menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine(MessageConstants.ShapeMenu);
        DisplayEnum.DisplayMenu(typeof(MenuContent.ShapeMenu));
    }

    private void Rectangle()
    {
        double length = ValidInput.GetMeasurement(MessageConstants.GetRectangleLength);
        double width = ValidInput.GetMeasurement(MessageConstants.GetRectangleWidth);
        string? color = ValidInput.GetColor(MessageConstants.GetColor);
        RectangleShape rectangle = new (color, width, length);

        Console.WriteLine(rectangle.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }

    private void Circle()
    {
        double radius = ValidInput.GetMeasurement(MessageConstants.GetCircleRadius);
        string? color = ValidInput.GetColor(MessageConstants.GetColor);
        Circle circle = new (color, radius);

        Console.WriteLine(circle.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
        Console.Clear();
    }
}
