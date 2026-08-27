using System.Text.RegularExpressions;
using ConsoleTables;
using LINQ.Models;

namespace LINQ.View;

/// <summary>
/// Contains all console operations.
/// </summary>
public class LinqView
{
    /// <summary>
    /// Displays product as table for task1.
    /// </summary>
    /// <param name="filteredProductSort"> List of products. </param>
    public void Display(List<(string ProductName, decimal ProductPrice)> filteredProductSort)
    {
        ConsoleTable table = new ("Product Name", "Product Price");

        foreach ((string productName, decimal productPrice) in filteredProductSort)
        {
            table.AddRow(productName, productPrice);
        }

        table.Write();
    }

    /// <summary>
    /// Displays product as table for task5 list.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void Display(List<Product> products)
    {
        ConsoleTable table = new ("Product Name", "Product Price");

        foreach (Product product in products)
        {
            table.AddRow(product.ProductName, product.ProductPrice);
        }

        table.Write();
    }

    /// <summary>
    /// Displays product as table for task5 IEnumerable.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void Display(IEnumerable<Product> products)
    {
        ConsoleTable table = new ("Product Name");

        foreach (Product product in products)
        {
            table.AddRow(product.ProductName);
        }

        table.Write();
    }

    /// <summary>
    /// Displays product as table for task2.
    /// </summary>
    /// <param name="groupedProducts"> List of products. </param>
    public void Display(List<(string Category, int Count, Product MaxPricedProduct)> groupedProducts)
    {
        ConsoleTable table = new ("Product Category", "Product Count", "Expensive Product");

        foreach ((string category, int count, Product maxPricedProduct) in groupedProducts)
        {
            table.AddRow(category, count, maxPricedProduct);
        }

        table.Write();
    }

    /// <summary>
    /// Displays product as table for task2 join.
    /// </summary>
    /// <param name="groupedProducts"> List of products. </param>
    public void Display(List<(string ProductName, decimal ProductPrice, string SupplierName)> groupedProducts)
    {
        ConsoleTable table = new ("Product Name", "Product Price", "Supplier Name");

        foreach ((string productName, decimal productPrice, string supplierName) in groupedProducts)
        {
            table.AddRow(productName, productPrice, supplierName);
        }

        table.Write();
    }

    /// <summary>
    /// Displays pairs as table for task 3.
    /// </summary>
    /// <param name="pairs"> List of pairs. </param>
    public void Display(List<(int number1, int number2)> pairs)
    {
        ConsoleTable table = new ("Number1", "Number2");

        foreach ((int number1, int number2) in pairs)
        {
            table.AddRow(number1, number2);
        }

        table.Write();
    }

    /// <summary>
    /// Displays messages passed as a parameter.
    /// </summary>
    /// <param name="message"> Message to be displays. </param>
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    public T GetMenuChoice<T>(string message)
        where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine($"{message}\n");
            DisplayOptions<T>();
            Console.WriteLine("\nSelect one of the above options: ");
            string input = string.Concat(Console.ReadLine()?.Where(c => !char.IsWhiteSpace(c)) ?? string.Empty);
            if (Enum.TryParse(input, true, out T choice) &&
                Enum.IsDefined(typeof(T), choice))
            {
                return choice;
            }

            Console.Clear();
            Console.WriteLine($"Invalid option selected.\n");
        }
    }

    /// <summary>
    /// Waits for the user to press a key and then clears the console.
    /// </summary>
    public void GetAnyKey()
    {
        Console.WriteLine($"\nPress any key to continue.");
        Console.ReadKey();
        Console.Clear();
        Console.Write("\x1b[3J");
    }

    /// <summary>
    /// Displays all values defined in the specific enum values.
    /// </summary>
    /// <typeparam name="T"> Type : enum </typeparam>
    /// <param name="excluded"> Name of Enum </param>
    private static void DisplayOptions<T>(params T[] excluded)
        where T : Enum
    {
        foreach (T optionCategory in Enum.GetValues(typeof(T)))
        {
            if (excluded.Contains(optionCategory))
            {
                continue;
            }

            string? displayName = Regex.Replace(optionCategory.ToString(), @"(?<!^)([A-Z])", " $1");
            Console.WriteLine($"[{Convert.ToInt32(optionCategory)}] {displayName}");
        }
    }
}
