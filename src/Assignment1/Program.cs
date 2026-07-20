using ContactManager.Helper;
using ContactManager.Repository;
using ContactManager.Services;
using ContactManager.View;

namespace ContactManager;

/// <summary>
/// Main class where program starts
/// </summary>
internal class Program
{
    /// <summary>
    /// Main Functions
    /// </summary>
    public static void Main()
    {
        ContactRepository contactRepository = new ();
        ContactController contactController = new ContactController(contactRepository);
        ConsoleOperations consoleOperations = new ConsoleOperations(contactController);

        consoleOperations.MenuInfo();
    }
}