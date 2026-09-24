namespace AdvanceTopics.Tasks;

/// <summary>
/// Contains pattern matching example.
/// </summary>
public class PatternMatching
{
    /// <summary>
    /// Demonstrates pattern matching.
    /// </summary>
    public void Demonstrate()
    {
        List<Shape?> shapes = new ()
        {
            new Circle
            {
                Name = "Circle",
                Radius = 5,
            },
            new Rectangle
            {
                Name = "Rectangle",
                Width = 10,
                Height = 4,
            },
            new Triangle
            {
                Name = "Triangle",
                Base = 8,
                Height = 6,
            },
            null,
        };

        foreach (Shape? shape in shapes)
        {
            DisplayShapeDetails(shape);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Displays shape details using pattern matching.
    /// </summary>
    /// <param name="shape">Shape to display.</param>
    private static void DisplayShapeDetails(Shape? shape)
    {
        switch (shape)
        {
            case Circle circle:
                Console.WriteLine("Shape Type : Circle");
                Console.WriteLine($"Radius     : {circle.Radius}");
                Console.WriteLine($"Area       : {circle.CalculateArea():F2}");
                break;

            case Rectangle rectangle:
                Console.WriteLine("Shape Type : Rectangle");
                Console.WriteLine($"Width      : {rectangle.Width}");
                Console.WriteLine($"Height     : {rectangle.Height}");
                Console.WriteLine($"Area       : {rectangle.CalculateArea():F2}");
                break;

            case Triangle triangle:
                Console.WriteLine("Shape Type : Triangle");
                Console.WriteLine($"Base       : {triangle.Base}");
                Console.WriteLine($"Height     : {triangle.Height}");
                Console.WriteLine($"Area       : {triangle.CalculateArea():F2}");
                break;

            case null:
                Console.WriteLine("Shape is null.");
                break;

            default:
                Console.WriteLine("Unknown shape type.");
                break;
        }
    }
}

/// <summary>
/// Represents a shape.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Gets or init shape name.
    /// </summary>
    /// <value> Shape name. </value>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Calculates area of the shape.
    /// </summary>
    /// <returns>Area of the shape.</returns>
    public abstract double CalculateArea();
}

/// <summary>
/// Represents a circle.
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Gets or init radius.
    /// </summary>
    /// <value> Radius. </value>
    public double Radius { get; init; }

    /// <inheritdoc/>
    public override double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }
}

/// <summary>
/// Represents a rectangle.
/// </summary>
public class Rectangle : Shape
{
    /// <summary>
    /// Gets or init width.
    /// </summary>
    /// <value> Width of rectangle. </value>
    public double Width { get; init; }

    /// <summary>
    /// Gets or init height.
    /// </summary>
    /// <value> Height of rectangle. </value>
    public double Height { get; init; }

    /// <inheritdoc/>
    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }
}

/// <summary>
/// Represents a triangle.
/// </summary>
public class Triangle : Shape
{
    /// <summary>
    /// Gets or init base length.
    /// </summary>
    /// <value> Base of triangle. </value>
    public double Base { get; init; }

    /// <summary>
    /// Gets or init height.
    /// </summary>
    /// <value> Height of triangle. </value>
    public double Height { get; init; }

    /// <inheritdoc/>
    public override double CalculateArea()
    {
        return 0.5 * this.Base * this.Height;
    }
}