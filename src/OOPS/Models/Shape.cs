namespace OOPS.Models;

/// <summary>
/// Abstract shape call containing color property and calculate area, print details methods.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Shape"/> class.
    /// </summary>
    /// <param name="color"> Color of the shape. </param>
    public Shape(string color) => this.Color = color;

    /// <summary>
    /// Gets or sets the color of the shape.
    /// </summary>
    /// <value>
    /// A string representing the color of the shape.
    /// </value>
    public string Color { get; set; }

    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    /// <returns>
    /// The area of the shape.
    /// </returns>
    public abstract double CalculateArea();

    /// <summary>
    /// Returns the shape details, including its color and area.
    /// </summary>
    /// <returns>
    /// A string containing the color and area of the shape.
    /// </returns>
    public abstract string PrintDetails();
}
