using ConsoleTables;
using InventoryManager.Constants;
using InventoryManager.Models;

namespace InventoryManager.View;

/// <summary>
/// Interface for view containing input and output operations.
/// </summary>
public interface IView
{
    /// <summary>
    /// Clear console.
    /// </summary>
    public void ClearConsole();

    /// <summary>
    /// Displays the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that needs to be displayed. </param>
    public void DisplayMessage(string message);

    /// <summary>
    /// Gets input from user which is not null or empty.
    /// </summary>
    /// <param name="prompt"> Represents message displayed to user to get input. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public string? GetStringInput(string prompt);

    /// <summary>
    /// Gets input from user which is a valid number.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public decimal? GetDecimalInput(string prompt);

    /// <summary>
    /// Gest input from user which is a valid long value.
    /// </summary>
    /// <param name="prompt"> Message that needs to be displayed. </param>
    /// <returns> Null if user chooses to exit process; otherwise user input. </returns>
    public long? GetLongInput(string prompt);

    /// <summary>
    /// Displays list of products as a table.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void DisplayProducts(List<Product> products);

    /// <summary>
    /// Waits for the user to press a key and then clears the console.
    /// </summary>
    public void GetAnyKey();

    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    public T GetMenuChoice<T>(string message)
        where T : struct, Enum;
}
