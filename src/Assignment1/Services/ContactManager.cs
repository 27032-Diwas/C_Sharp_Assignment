using AssignmentBasics.Helper;
using AssignmentBasics.Models;
using AssignmentBasics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasics.Services
{
    /// <summary>
    /// Has all the logic
    /// </summary>
    public class ContactManager
    {
        // objects
        private static ContactRepository contactRepository = new ContactRepository();
        ConsoleInputs consoleInputs = new ConsoleInputs();
        Validation validation = new Validation();
        /// <summary>
        /// Main menu
        /// </summary>
        public void Menu()
        {
            int option = consoleInputs.MenuInfo();

            switch (option)
            {
                case 1:
                    Console.WriteLine("View Contact");
                    ViewContact();
                    break;
                case 2:
                    Console.WriteLine("Add Contact");
                    AddContact();
                    break;
                case 3:
                    Console.WriteLine("Search Contact");
                    SearchContact();
                    break;
                case 4:
                    Console.WriteLine("Edit Contact");
                    EditContact();
                    break;
                case 5:
                    Console.WriteLine("Delete Contact");
                    DeleteContact();
                    break;
                case 6:
                    Console.WriteLine("Process Ended");
                    return;
                default:
                    Console.WriteLine("Please Enter a Valid Option");
                    this.Menu();
                    break;
            }
        }

        /// <summary>
        /// View Contact
        /// </summary>
        public void ViewContact()
        {
            contactRepository.ViewContact();
            this.Menu();
        }

        /// <summary>
        /// Add Contact
        /// </summary>
        public void AddContact()
        {
            ContactInfo contactInfo = consoleInputs.DataInput();
            bool contactValidation = validation.DataValidation(contactInfo);

            if (contactValidation)
            {
                contactInfo.Id = Guid.NewGuid();
                contactRepository.AddContact(contactInfo);
                this.Menu();
            }
        }

        /// <summary>
        /// Search Contact
        /// </summary>
        public void SearchContact()
        {
            contactRepository.SearchContact(consoleInputs.FieldDetail());
            this.Menu();
        }

        /// <summary>
        /// EditContact
        /// </summary>
        public void EditContact()
        {
            int indexOfContact = contactRepository.IndexOfContact(consoleInputs.FieldDetail());
            if (indexOfContact != -1)
            {
                int fieldOfContact = consoleInputs.DisplayFields();
                contactRepository.EditContact(indexOfContact, fieldOfContact, consoleInputs.EditDetail());
            }
            else
            {
                Console.WriteLine("No Contact Found!!");
            }

            this.Menu();
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        public void DeleteContact()
        {
            contactRepository.DeleteContact(consoleInputs.FieldDetail());
            this.Menu();
        }
    }
}
