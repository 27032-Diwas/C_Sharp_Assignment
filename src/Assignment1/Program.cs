using Assignment1.Helper;
using Assignment1.Repository;
using Assignment1.Services;
using Assignment1.View;

namespace Assignment1
{
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
            ContactManager contactManager = new ContactManager(contactRepository);
            ConsoleInputs consoleInputs = new ConsoleInputs(contactManager);

            consoleInputs.MenuInfo();
        }
    }
}