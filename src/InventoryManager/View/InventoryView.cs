namespace InventoryManager.View;

/// <summary>
/// Contains all the methods related to console operations.
/// </summary>
public static class InventoryView
{
    /// <summary>
    /// Display the string passes as a parameter.
    /// </summary>
    /// <param name="message"> Message that need to be displayed. </param>
    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
