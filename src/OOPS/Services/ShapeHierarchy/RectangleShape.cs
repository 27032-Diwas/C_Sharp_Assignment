using OOPS.Models;

namespace OOPS.Services.ShapeHierarchy;

/// <summary>
/// Represents a rectangle in the shape hierarchy.
/// </summary>
public class RectangleShape : Shape
{
    private const string _type = "Rectangle";

    /// <summary>
    /// Initializes a new instance of the <see cref="RectangleShape"/> class.
    /// </summary>
    /// <param name="color"> The color of the rectangle. </param>
    /// <param name="length"> The length of the rectangle. </param>
    /// <param name="width"> The width of the rectangle. </param>
    public RectangleShape(string color, double length, double width)
        : base(color)
    {
        this.Length = length;
        this.Width = width;
    }

    /// <summary>
    /// Gets or sets the length of the rectangle.
    /// </summary>
    /// <value>
    /// The length of the rectangle.
    /// </value>
    private double Length { get; set; }

    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    /// <value>
    /// The width of the rectangle.
    /// </value>
    private double Width { get; set; }

    /// <summary>
    /// Calculates the area of the rectangle.
    /// </summary>
    /// <returns>
    /// The area of the rectangle.
    /// </returns>
    public override double CalculateArea() => this.Length * this.Width;

    /// <summary>
    /// Returns the shape details, including its type, area, and color.
    /// </summary>
    /// <returns>
    /// A string containing the shape details.
    /// </returns>
    public override string PrintDetails() => $"\nShape : {_type}\nArea : {this.CalculateArea():F2}\nColor : {this.Color}";
}
