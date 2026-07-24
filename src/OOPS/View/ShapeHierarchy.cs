using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Services;

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
    /// Displays main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine(MessageConstants.ShapeMenu);
        foreach (var value in Enum.GetValues(typeof(MenuContent.ShapeMenu)))
        {
            Console.WriteLine($"{(int)value}. {value}");
        }
    }

    private void Rectangle()
    {
        double length = ValidInput.GetValidDoubleInput(MessageConstants.GetRectangleLength);
        double width = ValidInput.GetValidDoubleInput(MessageConstants.GetRectangleWidth);
        string? color = ValidInput.GetValidStringInput(MessageConstants.GetColor);
        RectangleShape rectangle = new (color, width, length);

        Console.WriteLine(rectangle.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
    }

    private void Circle()
    {
        double radius = ValidInput.GetValidDoubleInput(MessageConstants.GetCircleRadius);
        string? color = ValidInput.GetValidStringInput(MessageConstants.GetColor);
        Circle circle = new (color, radius);

        Console.WriteLine(circle.PrintDetails());
        Console.WriteLine(MessageConstants.GetAnyKey);
        Console.ReadKey();
    }
}
