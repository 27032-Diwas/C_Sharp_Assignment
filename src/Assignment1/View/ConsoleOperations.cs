using ConsoleTables;
using ContactManager.Constants;
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
    /// Display contact field with its data.
    /// </summary>
    /// <param name="contacts">
    /// Contact that needs to be displays.
    /// </param>
    public static void DisplayDetails(List<ContactInfo> contacts)
    {
        ConsoleTable contactTable = new ConsoleTable("S.No", RepeatedStrings.Name, RepeatedStrings.PhoneNumber, RepeatedStrings.Email, RepeatedStrings.Notes);
        int i = 1;
        foreach (ContactInfo contact in contacts)
        {
            contactTable.AddRow(i++, contact.Name, contact.PhoneNumber, contact.Email, contact.Notes);
        }

        contactTable.Write();
    }

    /// <summary>
    /// Display property.
    /// </summary>
    public static void DisplayContactProperty()
    {
        Console.WriteLine(RepeatedStrings.ChooseFieldToEdit);
        Console.WriteLine($"[1] - {RepeatedStrings.Name}");
        Console.WriteLine($"[2] - {RepeatedStrings.PhoneNumber}");
        Console.WriteLine($"[3] - {RepeatedStrings.Email}");
        Console.WriteLine($"[4] - {RepeatedStrings.Notes}");
        Console.WriteLine($"[5] - {RepeatedStrings.Exit}");
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
            Console.WriteLine(RepeatedStrings.SelectOneOfTheBelowOptions);
            Console.WriteLine($"[1] - {RepeatedStrings.View} {RepeatedStrings.Contact}");
            Console.WriteLine($"[2] - {RepeatedStrings.Add} {RepeatedStrings.Contact}");
            Console.WriteLine($"[3] - {RepeatedStrings.Search} {RepeatedStrings.Contact}");
            Console.WriteLine($"[4] - {RepeatedStrings.Edit} {RepeatedStrings.Contact}");
            Console.WriteLine($"[5] - {RepeatedStrings.Delete} {RepeatedStrings.Contact}");
            Console.WriteLine($"[6] - {RepeatedStrings.Exit}");
            Console.WriteLine(" ");

            option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    Console.WriteLine($"{RepeatedStrings.View} {RepeatedStrings.Contact}\n");
                    this.ViewContact();
                    break;
                case "2":
                    Console.WriteLine($"{RepeatedStrings.Add} {RepeatedStrings.Contact}\n");
                    this.AddContact();
                    break;
                case "3":
                    Console.WriteLine($"{RepeatedStrings.Search} {RepeatedStrings.Contact}\n");
                    this.SearchContact();
                    break;
                case "4":
                    Console.WriteLine($"{RepeatedStrings.Edit} {RepeatedStrings.Contact}\n");
                    this.EditContact();
                    break;
                case "5":
                    Console.WriteLine($"{RepeatedStrings.Delete} {RepeatedStrings.Contact}\n");
                    this.DeleteContact();
                    break;
                case "6":
                    Console.WriteLine(RepeatedStrings.EndProcess);
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine(RepeatedStrings.EnterAValidOption);
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
        List<ContactInfo> contacts = this._manager.ViewContactController();
        if (contacts.Count == 0)
        {
            Console.WriteLine(RepeatedStrings.NoContactExits);
            return;
        }

        DisplayDetails(contacts);
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
            RepeatedStrings.Name,
            RepeatedStrings.PhoneNumber,
            RepeatedStrings.Email,
            RepeatedStrings.Notes,
        };
        do
        {
            Console.WriteLine($"{RepeatedStrings.Enter} {RepeatedStrings.Contact} {contactFields[contactField - 1]} or E to {RepeatedStrings.Exit}: ");
            input = Console.ReadLine();
            if (input == "E")
            {
                return "E";
            }

            message = this._manager.CheckValidation(contactField, input);
            if (message == RepeatedStrings.ValidationIsSuccessful)
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
            Console.WriteLine(RepeatedStrings.ProcessCancelled);
            return;
        }

        phoneNumber = this.GetDetail(2);
        if (phoneNumber == "E")
        {
            Console.WriteLine(RepeatedStrings.ProcessCancelled);
            return;
        }

        email = this.GetDetail(3);
        if (email == "E")
        {
            Console.WriteLine(RepeatedStrings.ProcessCancelled);
            return;
        }

        notes = this.GetDetail(4);
        if (notes == "E")
        {
            Console.WriteLine(RepeatedStrings.ProcessCancelled);
            return;
        }

        Console.Clear();
        Console.WriteLine(this._manager.AddContactController(name, phoneNumber, email, notes));
    }

    /// <summary>
    /// Search contact.
    /// </summary>
    /// <returns> List of contact that match user input.</returns>
    public List<ContactInfo>? SearchContact()
    {
        if (this._manager.ViewContactController().Count == 0)
        {
            Console.WriteLine(RepeatedStrings.NoContactExits);
            return null;
        }

        Console.WriteLine($"{RepeatedStrings.Enter} {RepeatedStrings.Name} or {RepeatedStrings.PhoneNumber} or {RepeatedStrings.Email}: ");
        string? searchWord = Console.ReadLine();
        if (searchWord == string.Empty)
        {
            Console.WriteLine(RepeatedStrings.NoValueEntered);
            return null;
        }

        List<ContactInfo> searchResult = this._manager.SearchContactController(searchWord);
        if (searchResult.Count == 0)
        {
            Console.Clear();
            Console.WriteLine(RepeatedStrings.NoMatchFound);
            return null;
        }

        DisplayDetails(searchResult);

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

        Console.WriteLine(RepeatedStrings.DoYouWantToDelete);
        string? choice = Console.ReadLine();
        if (choice == "y" || choice == "Y")
        {
            this._manager.DeleteContactController(id);
            Console.WriteLine($"{RepeatedStrings.Contact} {RepeatedStrings.Deleted} {RepeatedStrings.Successfully}");
            return;
        }

        Console.Clear();
        Console.WriteLine(RepeatedStrings.ProcessCancelled);
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
                Console.WriteLine(RepeatedStrings.EnterAValidOption);
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
            DisplayContactProperty();
            option = Console.ReadLine();
            if (option == "5")
            {
                return 5;
            }

            if (option != "1" && option != "2" && option != "3" && option != "4")
            {
                Console.WriteLine(RepeatedStrings.EnterAValidOption);
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

        int selectedProperty = this.GetContactProperty();
        if (selectedProperty == 5)
        {
            return; // Selected Exit option
        }

        bool isDataValid = false;
        while (!isDataValid)
        {
            string? propertyValue = this.GetDetail(selectedProperty);
            Console.Clear();
            if (propertyValue == "E")
            {
                Console.WriteLine(RepeatedStrings.ProcessCancelled); // Cancelled during edit
                return;
            }

            string message = this._manager.EditContactController(guid, selectedProperty, propertyValue);
            if (message != $"{RepeatedStrings.Contact} {RepeatedStrings.Edited} {RepeatedStrings.Successfully}")
            {
                Console.WriteLine(message);
                continue;
            }

            isDataValid = true;
            Console.WriteLine($"{RepeatedStrings.Contact} {RepeatedStrings.Edited} {RepeatedStrings.Successfully}");
        }
    }
}