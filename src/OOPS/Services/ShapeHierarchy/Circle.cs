using OOPS.Models;

namespace OOPS.Services.ShapeHierarchy;

/// <summary>
/// Circle class inheriting shape class.
/// </summary>
public class Circle : Shape
{
    private const string _shape = "Circle";

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// </summary>
    /// <param name="color"> Color of the rectangle. </param>
    /// <param name="radius"> Length of the rectangle. </param>
    public Circle(string color, double radius)
        : base(color)
    {
        this.Radius = radius;
    }

    private double Radius { get; set; }

    /// <summary>
    /// Calculate area of the circle.
    /// </summary>
    /// <returns> Area of circle in double. </returns>
    public override double CalculateArea()
    {
        return this.Radius * this.Radius * Math.PI;
    }

    /// <summary>
    /// Displays shape, area and color of circle.
    /// </summary>
    /// <returns> String of details. </returns>
    public override string PrintDetails()
    {
        return $"Shape : {_shape}, Area : {this.CalculateArea():F2}, Color : {this.Color}";
    }
}
