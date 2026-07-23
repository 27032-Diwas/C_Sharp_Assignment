using ContactManager.Constants;
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
        ContactInfo contact = new ()
        {
            Id = Guid.NewGuid(),
        };
        string message = this.CheckValidation(1, name);
        if (message != MessageConstants.ValidationSuccessful)
        {
            return message;
        }

        contact.Name = name;
        message = this.CheckValidation(2, phoneNumber);
        if (message != MessageConstants.ValidationSuccessful)
        {
            return message;
        }

        contact.PhoneNumber = phoneNumber;
        message = this.CheckValidation(3, email);
        if (message != MessageConstants.ValidationSuccessful)
        {
            return message;
        }

        contact.Email = email;
        message = this.CheckValidation(4, notes);
        if (message != MessageConstants.ValidationSuccessful)
        {
            return message;
        }

        contact.Notes = notes;
        this._contactRepository.AddContact(contact);
        return MessageConstants.ContactAddedSuccessfully;
    }

    /// <summary>
    /// Search contact.
    /// </summary>
    /// <param name="searchWord"> Word to be searched. </param>
    /// <returns> List of contact that matches the user input. </returns>
    public List<ContactInfo> SearchContact(string? searchWord) => this._contactRepository.SearchContact(searchWord);

    /// <summary>
    /// Edit Contact.
    /// </summary>
    /// <param name="id"> Guid. </param>
    /// <param name="contactField"> Field. </param>
    /// <param name="contactValue"> Value to update. </param>
    /// <returns> Contact. </returns>
    public string EditContact(Guid? id, int contactField, string? contactValue)
    {
        string message = this.CheckValidation(contactField, contactValue);
        if (message != MessageConstants.ValidationSuccessful)
        {
            return message;
        }

        message = this._contactRepository.EditContact(id, contactField, contactValue);
        return message;
    }

    /// <summary>
    /// Delete Contact.
    /// </summary>
    /// <param name="id"> Guid. </param>
    public void DeleteContact(Guid? id)
    {
        this._contactRepository.DeleteContact(id);
    }

    /// <summary>
    /// Check if phone number exist or not.
    /// </summary>
    /// <param name="phoneNumber"> Phone number. </param>
    /// <returns> true or false. </returns>
    public bool IsPhoneNumberExist(string? phoneNumber)
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
    /// Validation of inputs.
    /// </summary>
    /// <param name="contactfield"> Property. </param>
    /// <param name="contactValue"> Value of the property. </param>
    /// <returns> Error message </returns>
    public string CheckValidation(int contactfield, string? contactValue)
    {
        switch (contactfield)
        {
            case 1 when Validation.IsValidInput(contactValue):
                return MessageConstants.NameRequired;
            case 1 when !Validation.IsValidName(contactValue):
                return MessageConstants.NameTooShort;
            case 2 when Validation.IsValidInput(contactValue):
                return MessageConstants.PhoneNumberRequired;
            case 2 when !Validation.IsValidPhoneNumber(contactValue):
                return MessageConstants.InvalidPhoneNumber;
            case 2 when this.IsPhoneNumberExist(contactValue):
                return MessageConstants.DuplicatePhoneNumber;
            case 3 when !Validation.IsValidEmail(contactValue):
                return MessageConstants.InvalidEmailAddress;
            case 4 when !Validation.IsValidNotes(contactValue):
                return MessageConstants.NotesExceedMaximumLength;
        }

        return MessageConstants.ValidationSuccessful;
    }
}
