using Assignment1.Repository;
using Assignment1.View;
using AssignmentBasics.Helper;
using AssignmentBasics.Services;

namespace Assignments
{
    /// <summary>
    /// Assignment Folder
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args">
        /// hit
        /// </param>
        public static void Main(string[] args)
        {
            ContactRepository contactRepository = new ContactRepository();
            Validation validation = new Validation();
            ContactManager contactManager = new ContactManager(contactRepository, validation);
            ConsoleInputs consoleInputs = new ConsoleInputs(contactManager);

            consoleInputs.MenuInfo();
        }
    }
}