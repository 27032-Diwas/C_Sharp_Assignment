using Assignment1.Repository;
using Assignment1.View;
using AssignmentBasics.Helper;
using AssignmentBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasics.Services
{
    /// <summary>
    /// Has all the logic
    /// </summary>
    public class ContactManager
    {
        private readonly ContactRepository _contactRepository;
        private readonly Validation _validation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// Constructor
        /// </summary>
        /// <param name="contactRepository"> repo link </param>
        /// <param name="validation"> Validation link </param>
        public ContactManager(ContactRepository contactRepository, Validation validation)
        {
            this._contactRepository = contactRepository;
            this._validation = validation;
        }

        /// <summary>
        /// View Contact
        /// </summary>
        /// <returns> Return the list of contact </returns>
        public List<ContactInfo> ViewContact()
        {
            return _contactRepository.ViewContact();
        }

        /// <summary>
        /// Add contact
        /// </summary>
        /// <param name="contactInfo"> object </param>
        /// <returns> the object </returns>
        public ContactInfo AddContact(ContactInfo contactInfo)
        {
            List<ContactInfo> contacts = ViewContact();
            foreach (ContactInfo contact in contacts)
            {
                if (contact.PhoneNumber == contactInfo.PhoneNumber)
                {
                    contactInfo.Name = "Error Found";
                    contactInfo.Notes = "Phone Number Already Exist";
                    return contactInfo;
                }
            }

            if (_validation.IsNameEmpty(contactInfo.Name))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Name is Required";
                return contactInfo;
            }
            else if (_validation.IsNumberEmpty(contactInfo.PhoneNumber))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number is Required";
                return contactInfo;
            }
            else if (!_validation.IsNumber(contactInfo.PhoneNumber))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number should be 10 digit number";
                return contactInfo;
            }
            else if (!_validation.IsEmail(contactInfo.Email))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Enter a valid Email";
                return contactInfo;
            }

            contactInfo.Id = Guid.NewGuid();
            _contactRepository.AddContact(contactInfo);
            return contactInfo;
        }

        /// <summary>
        /// return the list of contact match
        /// </summary>
        /// <param name="searchWord"> word to be searched </param>
        /// <returns> list of contact </returns>
        public List<ContactInfo> SearchContact(string searchWord)
        {
            List<ContactInfo> searchMatch = _contactRepository.SearchContact(searchWord);
            return searchMatch;
        }

        /// <summary>
        /// Edit Contact
        /// </summary>
        /// <param name="id"> guid </param>
        /// <param name="field"> field </param>
        /// <param name="fieldValue"> value to update </param>
        /// <returns> contact </returns>
        public ContactInfo EditContact(Guid id, int field, string fieldValue)
        {
            ContactInfo contactInfo = new ContactInfo();
            if (field == 1 && _validation.IsNameEmpty(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Name is Required";
                return contactInfo;
            }
            else if (field == 2 && _validation.IsNumberEmpty(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number is Required";
                return contactInfo;
            }
            else if (field == 2 && !_validation.IsNumber(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number should be 10 digit number";
                return contactInfo;
            }
            else if (field == 3 && !_validation.IsEmail(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Enter a valid Email";
                return contactInfo;
            }

            return _contactRepository.EditContact(id, field, fieldValue);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id"> guid </param>
        public void DeleteContact(Guid id)
        {
            _contactRepository.DeleteContact(id);
        }  
    }
}
