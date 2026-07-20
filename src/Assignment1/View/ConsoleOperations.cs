using ContactManager.Models;
using ContactManager.Services;

namespace ContactManager.View;

/// <summary>
/// Deals with all console operations.
/// </summary>
public class ConsoleOperations
{
    private readonly ContactController _manager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
    /// </summary>
    /// <param name="manager"> service object </param>
    public ConsoleOperations(ContactController manager)
    {
        this._manager = manager;
    }

    /// <summary>
    /// Displays Main Menu and redirect to selected method.
    /// </summary>
    public void MenuInfo()
    {
        string? option;
        do
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

            option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    Console.WriteLine("View Contacts\n");
                    this.ViewContact();
                    break;
                case "2":
                    Console.WriteLine("Add Contact\n");
                    this.AddContact();
                    break;
                case "3":
                    Console.WriteLine("Search Contact\n");
                    this.SearchContact();
                    break;
                case "4":
                    Console.WriteLine("Edit Contact\n");
                    this.EditContact();
                    break;
                case "5":
                    Console.WriteLine("Delete Contact\n");
                    this.DeleteContact();
                    break;
                case "6":
                    Console.WriteLine("End Process\n");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter a Valid Option");
                    break;
            }
        }
        while (option != "6");
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
    /// Get input till the value is correct
    /// </summary>
    /// <param name="contactField"> position of property in object </param>
    /// <returns> input value </returns>
    public string? GetDetail(int contactField)
    {
        string? input, message;
        List<string> contactFields = new ()
        {
            "Name",
            "Phone Number",
            "Email",
            "Notes",
        };
        do
        {
            Console.WriteLine($"Enter contact {contactFields[contactField - 1]} or E to Exit: ");
            input = Console.ReadLine();
            if (input == "E")
            {
                return "E";
            }

            message = this._manager.CheckValidation(contactField, input);
            Console.Clear();
            if (message == "Validation is successful")
            {
                break;
            }

            Console.WriteLine(message);
        }
        while (message != null);
        return input;
    }

    /// <summary>
    /// Add Contact method.
    /// </summary>
    public void AddContact()
    {
        // object
        ContactInfo contactInfo = new ();
        string? name, phoneNumber, email, notes;
        name = this.GetDetail(1);
        if (name == "E")
        {
            Console.WriteLine("Process Canceled");
            return;
        }

        phoneNumber = this.GetDetail(2);
        if (phoneNumber == "E")
        {
            Console.WriteLine("Process Canceled");
            return;
        }

        email = this.GetDetail(3);
        if (email == "E")
        {
            Console.WriteLine("Process Canceled");
            return;
        }

        notes = this.GetDetail(4);
        if (notes == "E")
        {
            Console.WriteLine("Process Canceled");
            return;
        }

        Console.Clear();
        Console.WriteLine(this._manager.AddContact(name, phoneNumber, email, notes));
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
        Console.WriteLine("Enter Name or PhoneNumber or Email: ");
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
        Guid? id = this.SelectContact();
        if (id == null)
        {
            return;
        }

        this._manager.DeleteContact(id);
        Console.WriteLine("Contact Deleted Successfully");
    }

    /// <summary>
    /// Display property.
    /// </summary>
    public void DisplayContactProperty()
    {
        Console.WriteLine("Choose field to edit: ");
        Console.WriteLine("[1] - Name");
        Console.WriteLine("[2] - Phone Number");
        Console.WriteLine("[3] - Email address");
        Console.WriteLine("[4] - Notes");
        Console.WriteLine("[5] - Exit");
    }

    /// <summary>
    /// Guid of the selected contact
    /// </summary>
    /// <returns> Guid </returns>
    public Guid? SelectContact()
    {
        List<ContactInfo>? searchResults = this.SearchContact();
        int selectedContactNumber = 1;
        if (searchResults == null)
        {
            return null;
        }
        else if (searchResults.Count == 1)
        {
            return searchResults[0].Id;
        }

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
                selectedContactNumber = int.Parse(choice);
            }
        }
        while (selectedContactNumber > searchResults.Count);

        return searchResults[selectedContactNumber - 1].Id;
    }

    /// <summary>
    /// To get the property that need to be edited.
    /// </summary>
    /// <returns> The Property</returns>
    public int GetContactProperty()
    {
        string? option;
        bool isOptionValid = false;
        int property = 0;
        while (!isOptionValid)
        {
            this.DisplayContactProperty();
            option = Console.ReadLine();
            if (option == "5")
            {
                return 5;
            }

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
    /// Edit contact
    /// </summary>
    public void EditContact()
    {
        Guid? guid = this.SelectContact();
        if (guid == null)
        {
            return;
        }

        int property = this.GetContactProperty();
        if (property == 5)
        {
            return;
        }

        bool isDataValid = false;
        while (!isDataValid)
        {
            string? propertyValue = this.GetDetail(property);
            Console.Clear();
            if (propertyValue == "E")
            {
                Console.WriteLine("Process Canceled");
                return;
            }

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