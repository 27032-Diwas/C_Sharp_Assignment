using Assignment1.Helper;
using Assignment1.Models;
using Assignment1.Repository;

namespace Assignment1.Services
{
    /// <summary>
    /// Contains all the logical part of contact manager.
    /// </summary>
    public class ContactManager
    {
        private readonly ContactRepository _contactRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="contactRepository"> Repo link. </param>
        public ContactManager(ContactRepository contactRepository)
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
            contact.Name = name;
            contact.PhoneNumber = phoneNumber;
            contact.Email = email;
            contact.Notes = notes;
            this._contactRepository.AddContact(contact);
            return "Contact Added Successfully";
        }

        /// <summary>
        /// Search contact.
        /// </summary>
        /// <param name="searchWord"> Word to be searched. </param>
        /// <returns> List of contact that macheres the user input. </returns>
        public List<ContactInfo> SearchContact(string? searchWord)
        {
            List<ContactInfo> searchMatch = this._contactRepository.SearchContact(searchWord);
            return searchMatch;
        }

        /// <summary>
        /// Edit Contact
        /// </summary>
        /// <param name="id"> Guid </param>
        /// <param name="field"> Field </param>
        /// <param name="fieldValue"> Value to update </param>
        /// <returns> Contact </returns>
        public string EditContact(Guid? id, int field, string? fieldValue)
        {
            this._contactRepository.EditContact(id, field, fieldValue);

            return "Contact Edited Successfully";
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
        /// <param name="phoneNumber"> P
        /// hone number </param>
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
        /// <param name="field"> property </param>
        /// <param name="fieldValue"> value of the property </param>
        /// <returns> Error message </returns>
        public string? CheckValidation(int field, string? fieldValue)
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

            return null;
        }
    }
}
