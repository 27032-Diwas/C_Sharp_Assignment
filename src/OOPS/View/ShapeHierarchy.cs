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
                    Rectangle();
                    break;
                case MenuContent.ShapeMenu.Circle:
                    Circle();
                    break;
            }
        }
    }

    private static void Rectangle()
    {
        double? inputDouble;
        inputDouble = ValidInput.GetMeasurement(MessageConstants.GetRectangleLength);
        if (inputDouble is null)
        {
            Console.Clear();
            return;
        }

        double length = (double)inputDouble;
        inputDouble = ValidInput.GetMeasurement(MessageConstants.GetRectangleWidth);
        if (inputDouble is null)
        {
            Console.Clear();
            return;
        }

        double width = (double)inputDouble;
        string? inputString = ValidInput.GetColor(MessageConstants.GetColor);
        if (inputString is null)
        {
            Console.Clear();
            return;
        }

        string color = inputString;
        RectangleShape rectangle = new (color, width, length);

        Console.WriteLine(rectangle.PrintDetails());
        ValidInput.GetAnyKey();
    }

    private static void Circle()
    {
        double? inputDouble;
        inputDouble = ValidInput.GetMeasurement(MessageConstants.GetCircleRadius);
        if (inputDouble is null)
        {
            Console.Clear();
            return;
        }

        double radius = (double)inputDouble;
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
