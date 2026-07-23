// <copyright file="ConsoleOperations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ContactManager.View;

using ConsoleTables;
using ContactManager.Constants;
using ContactManager.Models;
using ContactManager.Services;

/// <summary>
/// Deals with all console operations.
/// </summary>
public class ConsoleOperations
{
    private readonly ContactController contactController;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleOperations"/> class.
    /// </summary>
    /// <param name="manager"> service object. </param>
    public ConsoleOperations(ContactController manager)
    {
        this.contactController = manager;
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
            Console.WriteLine(MessageConstants.SelectOption);
            Console.WriteLine($"[1] - {MessageConstants.ViewContact}");
            Console.WriteLine($"[2] - {MessageConstants.AddContact}");
            Console.WriteLine($"[3] - {MessageConstants.SearchContact}");
            Console.WriteLine($"[4] - {MessageConstants.EditContact}");
            Console.WriteLine($"[5] - {MessageConstants.DeleteContact}");
            Console.WriteLine($"[6] - Exit");
            Console.WriteLine(" ");

            option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    Console.WriteLine($"{MessageConstants.ViewContact}\n");
                    this.ViewContact();
                    break;
                case "2":
                    Console.WriteLine($"{MessageConstants.AddContact}\n");
                    this.AddContact();
                    break;
                case "3":
                    Console.WriteLine($"{MessageConstants.SearchContact}\n");
                    this.SearchContact();
                    break;
                case "4":
                    Console.WriteLine($"{MessageConstants.EditContact}\n");
                    this.EditContact();
                    break;
                case "5":
                    Console.WriteLine($"{MessageConstants.DeleteContact}\n");
                    this.DeleteContact();
                    break;
                case "6":
                    Console.WriteLine(MessageConstants.ProcessEnded);
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine(MessageConstants.InvalidOption);
                    break;
            }
        }
        while (option != "6");
    }

    /// <summary>
    /// Display contact field with its data.
    /// </summary>
    /// <param name="contacts">
    /// Contact that needs to be displays.
    /// </param>
    private static void DisplayDetails(List<ContactInfo> contacts)
    {
        ConsoleTable contactTable = new ConsoleTable("S.No", MessageConstants.Name, MessageConstants.PhoneNumber, MessageConstants.Email, MessageConstants.Notes);
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
    private static void DisplayContactProperty()
    {
        Console.WriteLine(MessageConstants.SelectFieldToEdit);
        Console.WriteLine($"[1] - {MessageConstants.Name}");
        Console.WriteLine($"[2] - {MessageConstants.PhoneNumber}");
        Console.WriteLine($"[3] - {MessageConstants.Email}");
        Console.WriteLine($"[4] - {MessageConstants.Notes}");
        Console.WriteLine($"[5] - Exit");
    }

    /// <summary>
    /// View Contacts method. This method displays full contact details.
    /// </summary>
    private void ViewContact()
    {
        List<ContactInfo> contacts = this.contactController.ViewContact();
        if (!contacts.Any())
        {
            Console.WriteLine(MessageConstants.NoContactsExist);
            return;
        }

        DisplayDetails(contacts);
    }

    /// <summary>
    /// Get input till the value is correct.
    /// </summary>
    /// <param name="contactField"> position of property in object. </param>
    /// <returns> input value. </returns>
    private string? GetDetail(int contactField)
    {
        string? input, message;
        List<string> contactFields = new ()
        {
            MessageConstants.Name,
            MessageConstants.PhoneNumber,
            MessageConstants.Email,
            MessageConstants.Notes,
        };
        do
        {
            Console.WriteLine($"Enter contact {contactFields[contactField - 1]} or E to Exit: ");
            input = Console.ReadLine();
            if (input == "E")
            {
                Console.WriteLine(MessageConstants.ProcessCancelled);
                return "E";
            }

            message = this.contactController.CheckValidation(contactField, input);
            if (message == MessageConstants.ValidationSuccessful)
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
    private void AddContact()
    {
        // object
        ContactInfo contactInfo = new ();
        string? name, phoneNumber, email, notes;
        name = this.GetDetail(1);
        if (name == "E")
        {
            return;
        }

        phoneNumber = this.GetDetail(2);
        if (phoneNumber == "E")
        {
            return;
        }

        email = this.GetDetail(3);
        if (email == "E")
        {
            return;
        }

        notes = this.GetDetail(4);
        if (notes == "E")
        {
            return;
        }

        Console.Clear();
        Console.WriteLine(this.contactController.AddContact(name, phoneNumber, email, notes));
    }

    /// <summary>
    /// Search contact.
    /// </summary>
    /// <returns> List of contact that match user input.</returns>
    private List<ContactInfo>? SearchContact()
    {
        if (!this.contactController.ViewContact().Any())
        {
            Console.WriteLine(MessageConstants.NoContactsExist);
            return null;
        }

        Console.WriteLine($"Enter {MessageConstants.Name} or {MessageConstants.PhoneNumber} or {MessageConstants.Email}: ");
        string? searchWord = Console.ReadLine();
        if (searchWord == string.Empty)
        {
            Console.WriteLine(MessageConstants.NoValueEntered);
            return null;
        }

        List<ContactInfo> searchResult = this.contactController.SearchContact(searchWord);
        if (!searchResult.Any())
        {
            Console.Clear();
            Console.WriteLine(MessageConstants.NoMatchFound);
            return null;
        }

        DisplayDetails(searchResult);

        return searchResult;
    }

    /// <summary>
    /// Delete contact.
    /// </summary>
    private void DeleteContact()
    {
        Guid? id = this.SelectContact();
        if (id == null)
        {
            return;
        }

        Console.WriteLine(MessageConstants.ConfirmDelete);
        string? choice = Console.ReadLine();
        if (choice == "y" || choice == "Y")
        {
            this.contactController.DeleteContact(id);
            Console.WriteLine($"{MessageConstants.ContactDeletedSuccessfully}");
            return;
        }

        Console.Clear();
        Console.WriteLine(MessageConstants.ProcessCancelled);
    }

    /// <summary>
    /// Guid of the selected contact.
    /// </summary>
    /// <returns> Guid. </returns>
    private Guid? SelectContact()
    {
        List<ContactInfo>? searchResults = this.SearchContact();
        int selectedContactNumber = 1;
        switch (searchResults)
        {
            case null:
                return null;
            default:
                if (searchResults.Count == 1)
                {
                    return searchResults[0].Id;
                }

                break;
        }

        do
        {
            Console.WriteLine("Found Multiple Contacts - Choose one contact from above [ 1 - " + searchResults.Count + " ]:");
            string? choice = Console.ReadLine();
            if (choice == string.Empty)
            {
                Console.WriteLine(MessageConstants.InvalidOption);
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
    /// <returns> Contact field. </returns>
    private int GetContactProperty()
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
                Console.WriteLine(MessageConstants.InvalidOption);
                continue;
            }

            property = int.Parse(option);

            isOptionValid = true;
        }

        return property;
    }

    /// <summary>
    /// Edit contact.
    /// </summary>
    private void EditContact()
    {
        Guid? guid = this.SelectContact();
        if (guid == null)
        {
            return;
        }

        int selectedProperty = this.GetContactProperty();
        if (selectedProperty == 5)
        {
            Console.WriteLine(MessageConstants.ProcessCancelled);
            return; // Selected Exit option.
        }

        bool isDataValid = false;
        while (!isDataValid)
        {
            string? propertyValue = this.GetDetail(selectedProperty);
            Console.Clear();
            if (propertyValue == "E")
            {
                Console.WriteLine(MessageConstants.ProcessCancelled);
                return;
            }

            string message = this.contactController.EditContact(guid, selectedProperty, propertyValue);
            if (message != MessageConstants.ContactUpdatedSuccessfully)
            {
                Console.WriteLine(message);
                continue;
            }

            isDataValid = true;
            Console.WriteLine(MessageConstants.ContactUpdatedSuccessfully);
        }
    }
}