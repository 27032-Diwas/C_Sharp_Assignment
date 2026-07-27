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
    public Shape(string color)
    {
        this.Color = color;
    }

    /// <summary>
    /// Gets or sets property.
    /// </summary>
    /// <value> Color of shape. </value>
    public string Color { get; set; }

    /// <summary>
    /// Calculates area of the shape.
    /// </summary>
    /// <returns> Area of shape in double. </returns>
    public abstract double CalculateArea();

    /// <summary>
    /// Prints details - color and area.
    /// </summary>
    /// <returns> Color and area as a string. </returns>
    public abstract string PrintDetails();
}
