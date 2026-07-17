using Assignment1.Models;
using Assignment1.Services;

namespace Assignment1.View
{
    /// <summary>
    /// Deals with all console operations.
    /// </summary>
    public class ConsoleInputs
    {
        private readonly ContactManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInputs"/> class.
        /// </summary>
        /// <param name="manager"> service object </param>
        public ConsoleInputs(ContactManager manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Displays Main Menu and redirect to selected method.
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
                    Console.WriteLine("View Contacts\n");
                    this.ViewContact();
                    this.MenuInfo();
                    break;
                case "2":
                    Console.WriteLine("Add Contact\n");
                    this.AddContact();
                    this.MenuInfo();
                    break;
                case "3":
                    Console.WriteLine("Search Contact\n");
                    this.SearchContact();
                    this.MenuInfo();
                    break;
                case "4":
                    Console.WriteLine("Edit Contact\n");
                    this.EditContact();
                    this.MenuInfo();
                    break;
                case "5":
                    Console.WriteLine("Delete Contact\n");
                    this.DeleteContact();
                    this.MenuInfo();
                    break;
                case "6":
                    Console.WriteLine("End Process\n");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter a Valid Option");
                    this.MenuInfo();
                    break;
            }
        }

        /// <summary>
        /// View Contacts method. This method displays full contact details.
        /// </summary>
        public void ViewContact()
        {
            List<ContactInfo> contacts = this._manager.ViewContact();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contact Found");
                return;
            }

            foreach (ContactInfo contact in contacts)
            {
                this.DisplayDetails(contact);
            }
        }

        /// <summary>
        /// Add Contact method.
        /// </summary>
        public void AddContact()
        {
            // object
            ContactInfo contactInfo = new ();
            string? name, phoneNumber, email, message;
            do
            {
                Console.WriteLine("Enter Contact Name: ");
                name = Console.ReadLine();
                message = this._manager.CheckValidation(1, name);
                Console.Clear();
                Console.WriteLine(message);
            }
            while (message != null);

            contactInfo.Name = name;
            do
            {
                Console.WriteLine("Enter Contact Phone Number: ");
                phoneNumber = Console.ReadLine();
                message = this._manager.CheckValidation(2, phoneNumber);
                Console.Clear();
                Console.WriteLine(message);
            }
            while (message != null);

            contactInfo.PhoneNumber = phoneNumber;
            do
            {
                Console.WriteLine("Enter Contact Email: ");
                email = Console.ReadLine();
                message = this._manager.CheckValidation(3, email);
                Console.Clear();
                Console.WriteLine(message);
            }
            while (message != null);
            contactInfo.Email = email;
            Console.WriteLine("Enter contact Notes: ");
            contactInfo.Notes = Console.ReadLine();

            Console.Clear();
            message = this._manager.AddContact(contactInfo);
            if (message != "Contact Added Successfully")
            {
                Console.WriteLine(message);
                return;
            }

            this.DisplayDetails(contactInfo);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Display contact field with its data.
        /// </summary>
        /// <param name="contactInfo">
        /// Contact that needs to be displays.
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
        /// Search contact.
        /// </summary>
        /// <returns> List of contact that match user input.</returns>
        public List<ContactInfo>? SearchContact()
        {
            Console.WriteLine("Enter Name or PhoneNumber: ");
            string? searchWord = Console.ReadLine();
            if (searchWord == string.Empty)
            {
                Console.WriteLine("No value entered!!");
                return null;
            }

            List<ContactInfo> searchResult = this._manager.SearchContact(searchWord);
            if (searchResult.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Match Found!!!");
                return null;
            }

            foreach (ContactInfo contact in searchResult)
            {
                this.DisplayDetails(contact);
            }

            return searchResult;
        }

        /// <summary>
        /// Delete contact.
        /// </summary>
        public void DeleteContact()
        {
            Guid? guid = this.SelectContact();
            if (guid == null)
            {
                return;
            }

            this._manager.DeleteContact(guid);
            Console.WriteLine("Contact Deleted Successfully");
        }

        /// <summary>
        /// Display property.
        /// </summary>
        public void DisplayProperty()
        {
            Console.WriteLine("Choose field to edit: ");
            Console.WriteLine("[1] - Name");
            Console.WriteLine("[2] - Phone Number");
            Console.WriteLine("[3] - Email address");
            Console.WriteLine("[4] - Notes");
        }

        /// <summary>
        /// To get the property that need to be edited.
        /// </summary>
        /// <returns> The Property</returns>
        public int GetProperty()
        {
            string? option;
            bool isOptionValid = false;
            int property = 0;
            while (!isOptionValid)
            {
                this.DisplayProperty();
                option = Console.ReadLine();
                if (option != "1" && option != "2" && option != "3" && option != "4")
                {
                    Console.WriteLine("Enter a Valid Option!!!");
                    continue;
                }

                property = int.Parse(option);

                isOptionValid = true;
            }

            return property;
        }

        /// <summary>
        /// Guid of the selected contact
        /// </summary>
        /// <returns> Guid </returns>
        public Guid? SelectContact()
        {
            List<ContactInfo>? searchResults = this.SearchContact();
            int contactChoice = 1;
            if (searchResults != null && searchResults.Count != 0)
            {
                if (searchResults.Count > 1)
                {
                    do
                    {
                        Console.WriteLine("Found Multiple Contacts - Choose one contact from above [ 1 - " + searchResults.Count + " ]:");
                        string? choice = Console.ReadLine();
                        if (choice == string.Empty)
                        {
                            Console.WriteLine("Enter a valid option !!");
                            continue;
                        }
                        else if (choice != null && choice.All(char.IsDigit))
                        {
                            contactChoice = int.Parse(choice);
                        }
                    }
                    while (contactChoice > searchResults.Count);
                    return searchResults[contactChoice - 1].Id;
                }

                return searchResults[0].Id;
            }

            return null;
        }

        /// <summary>
        /// Get property value
        /// </summary>
        /// <param name="property"> Property </param>
        /// <returns> Property value </returns>
        public string? GetPropertyValue(int property)
        {
            string? propertyValue, message;
            do
            {
                Console.WriteLine("Enter New Detail: ");
                propertyValue = Console.ReadLine();
                message = this._manager.CheckValidation(property, propertyValue);
                Console.Clear();
                Console.WriteLine(message);
            }
            while (message != null);

            return propertyValue;
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        public void EditContact()
        {
            Guid? guid = this.SelectContact();
            if (guid == null)
            {
                return;
            }

            int property = this.GetProperty();

            bool isDataValid = false;
            while (!isDataValid)
            {
                string? propertyValue = this.GetPropertyValue(property);

                Console.Clear();

                string message = this._manager.EditContact(guid, property, propertyValue);
                if (message != "Contact Edited Successfully")
                {
                    Console.WriteLine(message);
                    continue;
                }

                isDataValid = true;
                Console.WriteLine("Contact Edited Successfully");
            }
        }
    }
}
