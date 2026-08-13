using System.Transactions;

namespace ExpenseTracker.View;

/// <summary>
/// Interface for view layer containing console operations.
/// </summary>
public interface IView
{
    /// <summary>
    /// Gets a valid menu option selected by the user.
    /// </summary>
    /// <typeparam name="T"> The enumeration type. </typeparam>
    /// <param name="message"> The message displayed before the menu options. </param>
    /// <returns>
    /// The selected enumeration value.
    /// </returns>
    T GetMenuChoice<T>(string message);

    /// <summary>
    /// Displays the details in transaction.
    /// </summary>
    /// <param name="transaction"> Transaction to display. </param>
    void DisplayTransaction(Transaction transaction);

    /// <summary>
    /// Displays summary as table.
    /// </summary>
    /// <param name="summary"> Summary to be displayed. </param>
    void DisplaySummary(string summary);

    /// <summary>
    /// Display the string passed as a parameter.
    /// </summary>
    /// <param name="message"> Message that need to be displayed. </param>
    void DisplayMessage(string message);

    /// <summary>
    /// Display the string passed as a parameter in red color.
    /// </summary>
    /// <param name="errorMessage"> Error message that need to be displayed. </param>
    void DisplayErrorMessage(string errorMessage);

    /// <summary>
    /// Displays the string passed as a parameter in green color.
    /// </summary>
    /// <param name="successMessage"> Success that need to be displayed. </param>
    void DisplaySuccessMessage(string successMessage);

    /// <summary>
    /// Clears console.
    /// </summary>
    void ClearConsole();

    /// <summary>
    /// Gets description from the user.
    /// </summary>
    /// <returns> Description as a string. </returns>
    string GetDescription();

    /// <summary>
    /// Gets amount from the user.
    /// </summary>
    /// <returns> Amount as decimal value. </returns>
    decimal GetAmount();

    /// <summary>
    /// Gets date from the user.
    /// </summary>
    /// <returns> Date as datetime value. </returns>
    DateTime GetDate();
}
