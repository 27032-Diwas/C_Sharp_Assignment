using OOPS.Models;

namespace OOPS.Services.ShapeHierarchy;

/// <summary>
/// Represents a circle in the shape hierarchy.
/// </summary>
public class Circle : Shape
{
    private const string _type = "Circle";

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// </summary>
    /// <param name="color"> The color of the circle. </param>
    /// <param name="radius"> The radius of the circle. </param>
    public Circle(string color, double radius)
        : base(color)
    {
        this.Radius = radius;
    }

    /// <summary>
    /// Gets or sets the radius of the circle.
    /// </summary>
    /// <value>
    /// The radius of the circle.
    /// </value>
    private double Radius { get; set; }

    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>
    /// The area of the circle.
    /// </returns>
    public override double CalculateArea() => this.Radius * this.Radius * Math.PI;

    /// <summary>
    /// Returns the shape details, including its type, area, and color.
    /// </summary>
    /// <returns>
    /// A string containing the shape details.
    /// </returns>
    public override string PrintDetails() => $"\nShape : {_type}\nArea : {this.CalculateArea():F2}\nColor : {this.Color}";
}
