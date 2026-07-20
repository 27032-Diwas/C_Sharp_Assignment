using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Repository;

namespace ContactManager.Services;

/// <summary>
/// Contains all the logical part of contact manager.
/// </summary>
public class ContactController
{
    private readonly ContactRepository _contactRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactController"/> class.
    /// </summary>
    /// <param name="contactRepository"> Repo link. </param>
    public ContactController(ContactRepository contactRepository)
    {
        this._contactRepository = contactRepository;
    }

    /// <summary>
    /// View Contacts.
    /// </summary>
    /// <returns> Return the list of contacts </returns>
    public List<ContactInfo> ViewContact()
    {
        return this._contactRepository.ViewContact();
    }

    /// <summary>
    /// Add contact
    /// </summary>
    /// <param name="name"> Name of contact</param>
    /// <param name="phoneNumber"> Phone number of contact </param>
    /// <param name="email"> Email of contact </param>
    /// <param name="notes"> Notes of contact </param>
    /// <returns> Successful message </returns>
    public string AddContact(string? name, string? phoneNumber, string? email, string? notes)
    {
        string message;
        ContactInfo contact = new ()
        {
            Id = Guid.NewGuid(),
        };
        message = this.CheckValidation(1, name);
        if (message != "Validation is successful")
        {
            return message;
        }

        contact.Name = name;
        message = this.CheckValidation(2, phoneNumber);
        if (message != "Validation is successful")
        {
            return message;
        }

        contact.PhoneNumber = phoneNumber;
        message = this.CheckValidation(3, email);
        if (message != "Validation is successful")
        {
            return message;
        }

        contact.Email = email;
        message = this.CheckValidation(4, notes);
        if (message != "Validation is successful")
        {
            return message;
        }

        contact.Notes = notes;
        this._contactRepository.AddContact(contact);
        return "Contact Added Successfully";
    }

    /// <summary>
    /// Search contact.
    /// </summary>
    /// <param name="searchWord"> Word to be searched. </param>
    /// <returns> List of contact that macheres the user input. </returns>
    public List<ContactInfo> SearchContact(string? searchWord) => this._contactRepository.SearchContact(searchWord);

    /// <summary>
    /// Edit Contact
    /// </summary>
    /// <param name="id"> Guid </param>
    /// <param name="field"> Field </param>
    /// <param name="fieldValue"> Value to update </param>
    /// <returns> Contact </returns>
    public string EditContact(Guid? id, int field, string? fieldValue)
    {
        string message = this.CheckValidation(field, fieldValue);
        if (message != "Validation is successful")
        {
            return message;
        }

        message = this._contactRepository.EditContact(id, field, fieldValue);
        return message;
    }

    /// <summary>
    /// Delete Contact.
    /// </summary>
    /// <param name="id"> Guid </param>
    public void DeleteContact(Guid? id)
    {
        this._contactRepository.DeleteContact(id);
    }

    /// <summary>
    /// Check if phone number exist or not.
    /// </summary>
    /// <param name="phoneNumber"> Phone number </param>
    /// <returns> true or false </returns>
    public bool IsNumberExist(string? phoneNumber)
    {
        List<ContactInfo> contacts = this.ViewContact();
        foreach (ContactInfo contact in contacts)
        {
            if (contact.PhoneNumber == phoneNumber)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Validation of inputs
    /// </summary>
    /// <param name="field"> Property </param>
    /// <param name="fieldValue"> Value of the property </param>
    /// <returns> Error message </returns>
    public string CheckValidation(int field, string? fieldValue)
    {
        if (field == 1 && Validation.IsNameEmpty(fieldValue))
        {
            return "Name is Required";
        }
        else if (field == 2 && Validation.IsNumberEmpty(fieldValue))
        {
            return "Phone Number is Required";
        }
        else if (field == 2 && !Validation.IsNumber(fieldValue))
        {
            return "Phone Number should be 10 digit number";
        }
        else if (field == 2 && this.IsNumberExist(fieldValue))
        {
            return "Phone Number Already Exist";
        }
        else if (field == 3 && !Validation.IsEmail(fieldValue))
        {
            return "Enter a valid Email";
        }
        else if (field == 4 && !Validation.IsNotes(fieldValue))
        {
            return "Notes should be less than 50 words";
        }

        return "Validation is successful";
    }
}
