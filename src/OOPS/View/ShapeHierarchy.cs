using OOPS.Constants;
using OOPS.EnumConstants;
using OOPS.Services.ShapeHierarchy;

namespace OOPS.View;

/// <summary>
/// Provides functionality for demonstrating the shape hierarchy.
/// </summary>
public class ShapeHierarchy
{
    /// <summary>
    /// Displays the shape menu and processes the selected option.
    /// </summary>
    public static void GetMenuOption()
    {
        while (true)
        {
            MenuContent.ShapeMenu choice = DisplayEnum.GetMenuChoice<MenuContent.ShapeMenu>(MessageConstants.ShapeMenu);

            Console.Clear();
            switch (choice)
            {
                case MenuContent.ShapeMenu.Back:
                    return;
                case MenuContent.ShapeMenu.Rectangle:
                    CreateRectangle();
                    break;
                case MenuContent.ShapeMenu.Circle:
                    CreateCircle();
                    break;
            }
        }
    }

    /// <summary>
    /// Creates a rectangle and displays its details.
    /// </summary>
    private static void CreateRectangle()
    {
        double? inputDouble;
        inputDouble = ValidInput.GetDimension(MessageConstants.GetRectangleLength);
        if (inputDouble is null)
        {
            Console.Clear();
            return;
        }

        double length = inputDouble.Value;
        inputDouble = ValidInput.GetDimension(MessageConstants.GetRectangleWidth);
        if (inputDouble is null)
        {
            Console.Clear();
            return;
        }

        double width = inputDouble.Value;
        string? inputString = ValidInput.GetColor(MessageConstants.GetColor);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string color = inputString;
        RectangleShape rectangle = new (color, length, width);

        Console.WriteLine(rectangle.PrintDetails());
        ValidInput.GetAnyKey();
    }

    /// <summary>
    /// Creates a circle and displays its details.
    /// </summary>
    private static void CreateCircle()
    {
        double? inputDouble;
        inputDouble = ValidInput.GetDimension(MessageConstants.GetCircleRadius);
        if (inputDouble is null)
        {
            Console.Clear();
            return;
        }

        double radius = inputDouble.Value;
        string? inputString = ValidInput.GetColor(MessageConstants.GetColor);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string color = inputString;
        Circle circle = new (color, radius);

        Console.WriteLine(circle.PrintDetails());
        ValidInput.GetAnyKey();
    }
}
