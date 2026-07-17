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
        /// Add contact.
        /// </summary>
        /// <param name="contactInfo"> Object - contact </param>
        /// <returns> Contact </returns>
        public string AddContact(ContactInfo contactInfo)
        {
            if (this.IsNumberExist(contactInfo.PhoneNumber))
            {
                return "Phone Number Already Exist";
            }

            if (Validation.IsNameEmpty(contactInfo.Name))
            {
                return "Name is Required";
            }
            else if (Validation.IsNumberEmpty(contactInfo.PhoneNumber))
            {
                return "Phone Number is Required";
            }
            else if (!Validation.IsNumber(contactInfo.PhoneNumber))
            {
                return "Phone Number should be 10 digit number";
            }
            else if (!Validation.IsEmail(contactInfo.Email))
            {
                return "Enter a valid Email";
            }

            contactInfo.Id = Guid.NewGuid();
            this._contactRepository.AddContact(contactInfo);
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
        public string EditContact(Guid id, int field, string? fieldValue)
        {
            ContactInfo contactInfo = new ();
            if (field == 2 && this.IsNumberExist(fieldValue))
            {
                return "Phone Number Already Exist";
            }

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
            else if (field == 3 && !Validation.IsEmail(fieldValue))
            {
                return "Enter a valid Email";
            }

            this._contactRepository.EditContact(id, field, fieldValue);

            return "Contact Edited Successfully";
        }

        /// <summary>
        /// Delete Contact.
        /// </summary>
        /// <param name="id"> Guid </param>
        public void DeleteContact(Guid id)
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
    }
}
