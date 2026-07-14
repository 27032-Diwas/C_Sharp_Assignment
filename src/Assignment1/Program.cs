namespace Assignments
{
    /// <summary>
    /// Assignment Folder
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Check for empty list of contacts
        /// </summary>
        /// <param name="listOfContacts">
        /// main list
        /// </param>
        /// <returns>
        /// isEmpty or not
        /// </returns>
        public static bool EmptyList(List<string[]> listOfContacts)
        {
            if (listOfContacts.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("There is no contact in our memory.");
                PrintOptions(listOfContacts);
                return true;
            }

            return false;
        }

        /// <summary>
        /// print the main menu
        /// </summary>
        /// <param name="listOfContacts">
        /// main list
        /// </param>
        public static void PrintOptions(List<string[]> listOfContacts)
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

            var selectedOption = Console.ReadLine();

            if (selectedOption == "1")
            {
                if (!EmptyList(listOfContacts))
                {
                    Console.WriteLine("View Contacts");
                    ViewContacts(listOfContacts);
                }
            }
            else if (selectedOption == "2")
            {
                Console.WriteLine("Add Contact");
                AddContact(listOfContacts);
            }
            else if (selectedOption == "3")
            {
                if (!EmptyList(listOfContacts))
                {
                    Console.WriteLine("Search Contact");
                    SearchContact(listOfContacts);
                }
            }
            else if (selectedOption == "4")
            {
                if (!EmptyList(listOfContacts))
                {
                    Console.WriteLine("Edit Contact");
                    EditContact(listOfContacts);
                }
            }
            else if (selectedOption == "5")
            {
                if (!EmptyList(listOfContacts))
                {
                    Console.WriteLine("Delete Contact");
                    DeleteContact(listOfContacts);
                }
            }
            else if (selectedOption == "6")
            {
                Console.WriteLine("Process Ended!!!");
            }
            else
            {
                Console.WriteLine("Invalid option!! Choose correctly");
                PrintOptions(listOfContacts);
            }
        }

        /// <summary>
        /// Add contact to the list
        /// </summary>
        /// /// <param name="listOfContacts">
        /// main list
        /// </param>
        public static void AddContact(List<string[]> listOfContacts)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Email Address: ");
            var emailAddress = Console.ReadLine();
            Console.WriteLine("Description: ");
            var description = Console.ReadLine();
            int flag = 1;
            foreach (string[] contact in listOfContacts)
            {
                if (contact[1] == phoneNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Phone Number already exist!!");
                    flag = 0;
                    PrintOptions(listOfContacts);
                }
            }
            if (flag == 1)
            {
                listOfContacts.Add(new string[] { name, phoneNumber, emailAddress, description });
                Console.Clear();
                Console.WriteLine("Contact Added Successfully!!");
                PrintOptions(listOfContacts);
            }
        }

        /// <summary>
        /// View all contacts
        /// </summary>
        /// /// <param name="listOfContacts">
        /// main list
        /// </param>
        public static void ViewContacts(List<string[]> listOfContacts)
        {
            var sorted = listOfContacts.OrderBy(arr => arr[0]).ToList();
            Console.Clear();
            foreach (string[] contact in sorted)
            {
                Console.WriteLine("Name: " + contact[0] + "           Phone Number: " + contact[1]);
            }

            PrintOptions(listOfContacts);
        }

        /// <summary>
        /// Delete contacts
        /// </summary>
        /// /// <param name="listOfContacts">
        /// main list
        /// </param>
        public static void DeleteContact(List<string[]> listOfContacts)
        {
            int indexOfContect = IndexOfContact(listOfContacts);
            listOfContacts.RemoveAt(indexOfContect);
            Console.Clear();
            Console.WriteLine("Contact Deleted Successfully!!!");
            PrintOptions(listOfContacts);
        }

        /// <summary>
        /// Edit contacts
        /// </summary>
        /// /// <param name="listOfContacts">
        /// main list
        /// </param>
        public static void EditContact(List<string[]> listOfContacts)
        {
            int indexOfContect = IndexOfContact(listOfContacts);
            Console.WriteLine("Choose field to edit: ");
            Console.WriteLine("[1] - Name");
            Console.WriteLine("[2] - Phone Number");
            Console.WriteLine("[3] - Email address");
            Console.WriteLine("[4] - Description");

            var choise = Console.ReadLine();
            if (choise == "1" || choise == "2" || choise == "3" || choise == "4")
            {
                int option = int.Parse(choise);
                Console.WriteLine("Enter the detail to update: ");
                string? newDetail = Console.ReadLine();
                listOfContacts[indexOfContect][option - 1] = newDetail;
                Console.Clear();
                Console.WriteLine("Contact Edited Successfully!!!");
            }
            else
            {
                Console.WriteLine("Enter a vaild option");
            }
            PrintOptions(listOfContacts);
        }

        /// <summary>
        /// Search contacts
        /// </summary>
        /// /// <param name="listOfContacts">
        /// main list
        /// </param>
        public static void SearchContact(List<string[]> listOfContacts)
        {
            int indexOfContect = IndexOfContact(listOfContacts);
            if (indexOfContect == -1)
            {
                Console.Clear();
                Console.WriteLine("No contact found");
            }
            PrintOptions(listOfContacts);
        }

        /// <summary>
        /// to find index of contact
        /// </summary>
        /// /// <param name="listOfContacts">
        /// main list
        /// </param>
        /// <returns>
        /// returns the index of element
        /// </returns>
        public static int IndexOfContact(List<string[]> listOfContacts)
        {
            Console.Clear();
            Console.WriteLine("Search By: ");
            Console.WriteLine("[1] - Name");
            Console.WriteLine("[2] - Phone Number");

            var choice = Console.ReadLine();
            int indexOfContact = -1;

            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter the Name: ");
                var name = Console.ReadLine();
                foreach (string[] contact in listOfContacts)
                {
                    if (contact[0] == name)
                    {
                        indexOfContact = listOfContacts.IndexOf(contact);
                        Console.WriteLine("Contact Details: ");
                        Console.WriteLine("1. Name: " + listOfContacts[indexOfContact][0]);
                        Console.WriteLine("2. Phone Number: " + listOfContacts[indexOfContact][1]);
                        Console.WriteLine("3. Email Address: " + listOfContacts[indexOfContact][2]);
                        Console.WriteLine("4. Descripiton: " + listOfContacts[indexOfContact][3]);
                    }
                }
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Enter the Phone Number: ");
                var phoneNumber = Console.ReadLine();
                foreach (string[] contact in listOfContacts)
                {
                    if (contact[1] == phoneNumber)
                    {
                        indexOfContact = listOfContacts.IndexOf(contact);
                        Console.WriteLine("Contact Details: ");
                        Console.WriteLine("1. Name: " + listOfContacts[indexOfContact][0]);
                        Console.WriteLine("2. Phone Number: " + listOfContacts[indexOfContact][1]);
                        Console.WriteLine("3. Email Address: " + listOfContacts[indexOfContact][2]);
                        Console.WriteLine("4. Descripiton: " + listOfContacts[indexOfContact][3]);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter a valid option!!");
                SearchContact(listOfContacts);
            }

            return indexOfContact;
        }

        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args">
        /// argument documented
        /// </param>
        public static void Main(string[] args)
        {
            List<string[]> listOfContacts = new List<string[]>();
            PrintOptions(listOfContacts);
        }
    }
}