using OOPS.Models;

namespace OOPS.Services.ShapeHierarchy;

/// <summary>
/// Rectange class inheriting shape class.
/// </summary>
public class RectangleShape : Shape
{
    private const string _shape = "Rectangle";

    /// <summary>
    /// Initializes a new instance of the <see cref="RectangleShape"/> class.
    /// </summary>
    /// <param name="color"> Color of the rectangle. </param>
    /// <param name="length"> Length of the rectangle. </param>
    /// <param name="width"> Width of the rectangel. </param>
    public RectangleShape(string color, double length, double width)
        : base(color)
    {
        this.Length = length;
        this.Width = width;
    }

    private double Length { get; set; }

    private double Width { get; set; }

    /// <summary>
    /// Calculate area of the rectangle.
    /// </summary>
    /// <returns> Area of rectangle in double. </returns>
    public override double CalculateArea()
    {
        return this.Length * this.Width;
    }

    /// <summary>
    /// Displays shape, area and color of rectangle.
    /// </summary>
    /// <returns> String of details. </returns>
    public override string PrintDetails()
    {
        return $"\nShape : {_shape}\nArea : {this.CalculateArea():F2}\nColor : {this.Color}";
    }
}
