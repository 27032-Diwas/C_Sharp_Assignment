using AssignmentBasics.Models;
using AssignmentBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.View
{
    /// <summary>
    /// Input Class
    /// </summary>
    public class ConsoleInputs
    {
        private ContactManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInputs"/> class.
        /// Constructor initialization
        /// </summary>
        /// <param name="manager"> servise folder </param>
        public ConsoleInputs(ContactManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Display Main Menu
        /// </summary>
        public void MenuInfo()
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

            switch (option)
            {
                case "1":
                    Console.WriteLine("View Contact\n");
                    ViewContact();
                    this.MenuInfo();
                    break;
                case "2":
                    Console.WriteLine("Add Contact\n");
                    AddContact();
                    this.MenuInfo();
                    break;
                case "3":
                    Console.WriteLine("Search Contact\n");
                    SearchContact();
                    this.MenuInfo();
                    break;
                case "4":
                    Console.WriteLine("Edit Contact\n");
                    EditContact();
                    this.MenuInfo();
                    break;
                case "5":
                    Console.WriteLine("Delete Contact\n");
                    DeleteContact();
                    this.MenuInfo();
                    break;
                case "6":
                    Console.WriteLine("Process Ended\n");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter a Valid Option");
                    this.MenuInfo();
                    break;
            }
        }

        /// <summary>
        /// View Contact
        /// </summary>
        public void ViewContact()
        {
            List <ContactInfo> contactInfos= _manager.ViewContact();
            
            if (contactInfos.Count == 0)
            {
                Console.WriteLine("No Contact Found");
            }
            else
            {
                foreach (ContactInfo contact in contactInfos)
                {
                    this.DisplayDetails(contact);
                }
            }  
        }

        /// <summary>
        /// Add Contact view
        /// </summary>
        public void AddContact()
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

            Console.Clear();
            contactInfo = _manager.AddContact(contactInfo);
            if (contactInfo.Name == "Error Found")
            {
                DataValidation(contactInfo);
            }
            else
            {
                this.DisplayDetails(contactInfo);
                Console.WriteLine("Contact Added Successfully");
            } 
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
        /// <returns> return the list of contact </returns>
        public List<ContactInfo> SearchContact()
        {
            Console.WriteLine("Enter Name or PhoneNumber: ");
            string? searchWord = Console.ReadLine();

            List<ContactInfo> contactInfos = _manager.SearchContact(searchWord);
            if (contactInfos.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Match Found!!!");
            }
            else
            {
                foreach (ContactInfo contact in contactInfos)
                {
                    this.DisplayDetails(contact);
                }
            }

            return contactInfos;
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        public void DeleteContact()
        {
            List<ContactInfo> contactInfos = this.SearchContact();
            int contactId = 1;
            if (contactInfos.Count != 0)
            {
                if (contactInfos.Count > 1)
                {
                    Console.WriteLine("There are multiple contact , choose which contact to delte (ex: 1) :");

                    contactId = int.Parse(Console.ReadLine());
                }

                Console.Clear();
                this._manager.DeleteContact(contactInfos[contactId - 1].Id);
                Console.WriteLine("Contact Deleted Successfully");
            }
        }

        /// <summary>
        /// Options
        /// </summary>
        public void Options()
        {
            Console.WriteLine("Choose field to edit: ");
            Console.WriteLine("[1] - Name");
            Console.WriteLine("[2] - Phone Number");
            Console.WriteLine("[3] - Email address");
            Console.WriteLine("[4] - Description");
        }

        /// <summary>
        /// Validation
        /// </summary>
        /// <param name="contactInfo"> obj </param>
        public void DataValidation(ContactInfo contactInfo)
        {
            switch (contactInfo.Notes)
            {
                case "Phone Number Already Exist":
                    Console.WriteLine(contactInfo.Notes);
                    break;
                case "Name is Required":
                    Console.WriteLine(contactInfo.Notes);
                    break;
                case "Phone Number is Required":
                    Console.WriteLine(contactInfo.Notes);
                    break;
                case "Phone Number should be 10 digit number":
                    Console.WriteLine(contactInfo.Notes);
                    break;
                case "Enter a valid Email":
                    Console.WriteLine(contactInfo.Notes);
                    break;
            }
        }
        /// <summary>
        /// Data to be edited
        /// </summary>
        public void EditContact()
        {
            List<ContactInfo> contactInfos = this.SearchContact();
            int contactId = 1;
            if (contactInfos.Count != 0)
            {
                if (contactInfos.Count > 1)
                {
                    Console.WriteLine("There are multiple contact , choose which contact to delte (ex: 1) :");

                    contactId = int.Parse(Console.ReadLine());
                }

                string option = " ";
                int flag = 0;
                while (flag == 0)
                {
                    Options();
                    option = Console.ReadLine();
                    if (option != "1" && option != "2" && option != "3" && option != "4")
                    {
                        Console.WriteLine("Enter a Valid Option!!!");
                    }
                    else
                    {
                        int field = int.Parse(option);
                        Console.WriteLine("Enter New Detail: ");
                        string? fieldValue = Console.ReadLine();

                        Console.Clear();

                        ContactInfo contactInfo = this._manager.EditContact(contactInfos[contactId - 1].Id, field, fieldValue);
                        if (contactInfo.Name == "Error Found")
                        {
                            DataValidation(contactInfo);
                        }
                        else
                        {
                            flag = 1;
                            this.DisplayDetails(contactInfo);
                            Console.WriteLine("Contact Edited Successfully");
                        }
                    }
                }
            }
        }
    }
}
