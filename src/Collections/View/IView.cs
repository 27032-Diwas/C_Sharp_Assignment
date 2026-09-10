namespace Collections.View;

/// <summary>
/// Interface for view layer.
/// </summary>
public interface IView
{

    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <param name="prompt"> The message displayed to get option from user. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    public T GetMenuChoice<T>(string message, string prompt)
        where T : struct, Enum;

    /// <summary>
    /// Display the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that need to be displayed. </param>
    public void DisplayMessage(string message);

    /// <summary>
    /// Display the string passed as a parameter in red color.
    /// </summary>
    /// <param name="errorMessage"> Error message that need to be displayed. </param>
    public void DisplayErrorMessage(string errorMessage);

    /// <summary>
    /// Displays the string passed as a parameter in green color.
    /// </summary>
    /// <param name="successMessage"> Success that need to be displayed. </param>
    public void DisplaySuccessMessage(string successMessage);

    /// <summary>
    /// Clears console.
    /// </summary>
    public void ClearConsole();

    /// <summary>
    /// Waits for the user to press a key and then clears the console.
    /// </summary>
    public void GetAnyKey();

    /// <summary>
    /// Gets string input from user.
    /// </summary>
    /// <param name="prompt"> Message displayed to user to get input. </param>
    /// <returns> String input. </returns>
    public string GetStringInput(string prompt);
}
