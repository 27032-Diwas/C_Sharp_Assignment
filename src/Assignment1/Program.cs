using Assignment1.Helper;
using Assignment1.Repository;
using Assignment1.Services;
using Assignment1.View;

namespace Assignments
{
    /// <summary>
    /// Main class where program starts
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Function
        /// </summary>
        public static void Main()
        {
            ContactRepository contactRepository = new ();
            Validation validation = new ();
            ContactManager contactManager = new ContactManager(contactRepository);
            ConsoleInputs consoleInputs = new ConsoleInputs(contactManager);

            consoleInputs.MenuInfo();
        }
    }
}