using AssignmentBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasics.Services
{
    /// <summary>
    /// Input Class
    /// </summary>
    public class ConsoleInputs
    {
        /// <summary>
        /// Display Main Menu
        /// </summary>
        /// <returns>
        /// Return the selected option
        /// </returns>
        public string MenuInfo()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Select one of the below options: ");
            Console.WriteLine("[1] - View contacts");
            Console.WriteLine("[2] - Add new contact");
            Console.WriteLine("[3] - Search contact");
            Console.WriteLine("[4] - Edit contact");
            Console.WriteLine("[5] - Delete contact");
            Console.WriteLine("[6] - Quit");
            Console.WriteLine(" ");

            string? option = Console.ReadLine();
            Console.Clear();
            return option;
        }

        /// <summary>
        /// Get the Details from users
        /// </summary>
        /// <returns>
        /// object
        /// </returns>
        public ContactInfo DataInput()
        {
            // object
            ContactInfo contactInfo = new ContactInfo();

            Console.WriteLine("Enter Contact Name: ");
            contactInfo.Name = Console.ReadLine();
            Console.WriteLine("Enter Contact Phone Number: ");
            contactInfo.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter contact Email: ");
            contactInfo.Email = Console.ReadLine();
            Console.WriteLine("Enter contact Notes: ");
            contactInfo.Notes = Console.ReadLine();
            return contactInfo;
        }

        /// <summary>
        /// Display Contact info
        /// </summary>
        /// <param name="contactInfo">
        /// Object
        /// </param>
        public void DisplayDetails(ContactInfo contactInfo)
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. Name: " + contactInfo.Name);
            Console.WriteLine("2. Phone Number: " + contactInfo.PhoneNumber);
            Console.WriteLine("3. Email Address: " + contactInfo.Email);
            Console.WriteLine("4. Notes: " + contactInfo.Notes);
            Console.WriteLine(" ");
        }

        /// <summary>
        /// Getting Data for Search
        /// </summary>
        /// <returns>
        /// the data to be searched
        /// </returns>
        public string FieldDetail()
        {
            Console.WriteLine("Enter Name or PhoneNumber: ");
            string? field = Console.ReadLine();

            return field;
        }

        /// <summary>
        /// Data to be edited
        /// </summary>
        /// <returns>
        /// the data
        /// </returns>
        public string EditDetail()
        {
            Console.WriteLine("Enter New Detail: ");
            string? field = Console.ReadLine();

            return field;
        }

        /// <summary>
        /// Field to be edited
        /// </summary>
        /// <returns>
        /// Field
        /// </returns>
        public int DisplayFields()
        {
            Console.WriteLine("Choose field to edit: ");
            Console.WriteLine("[1] - Name");
            Console.WriteLine("[2] - Phone Number");
            Console.WriteLine("[3] - Email address");
            Console.WriteLine("[4] - Description");

            int option = int.Parse(Console.ReadLine());

            return option;
        }
    }
}
