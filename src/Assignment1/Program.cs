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
            ContactManager contactManager = new ContactManager();
            Console.WriteLine("Contact Manager");
            contactManager.Menu();
        }
    }
}