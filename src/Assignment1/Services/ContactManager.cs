using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Helper;
using Assignment1.Models;
using Assignment1.Repository;
using Assignment1.View;

namespace Assignment1.Services
{
    /// <summary>
    /// Has all the logic
    /// </summary>
    public class ContactManager
    {
        private readonly ContactRepository _contactRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManager"/> class.
        /// </summary>
        /// <param name="contactRepository"> repo link </param>
        public ContactManager(ContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        /// <summary>
        /// View Contacts
        /// </summary>
        /// <returns> Return the list of contact </returns>
        public List<ContactInfo> ViewContact()
        {
            return this._contactRepository.ViewContact();
        }

        /// <summary>
        /// Add contact
        /// </summary>
        /// <param name="contactInfo"> object </param>
        /// <returns> the object </returns>
        public ContactInfo AddContact(ContactInfo contactInfo)
        {
            if (this.IsNumberExist(contactInfo.PhoneNumber))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number Already Exist";
                return contactInfo;
            }

            if (Validation.IsNameEmpty(contactInfo.Name))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Proper Name is Required";
                return contactInfo;
            }
            else if (Validation.IsNumberEmpty(contactInfo.PhoneNumber))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number is Required";
                return contactInfo;
            }
            else if (!Validation.IsNumber(contactInfo.PhoneNumber))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number should be 10 digit number";
                return contactInfo;
            }
            else if (!Validation.IsEmail(contactInfo.Email))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Enter a valid Email";
                return contactInfo;
            }

            contactInfo.Id = Guid.NewGuid();
            this._contactRepository.AddContact(contactInfo);
            return contactInfo;
        }

        /// <summary>
        /// return the list of contact match
        /// </summary>
        /// <param name="searchWord"> word to be searched </param>
        /// <returns> list of contact </returns>
        public List<ContactInfo> SearchContact(string? searchWord)
        {
            List<ContactInfo> searchMatch = this._contactRepository.SearchContact(searchWord);
            return searchMatch;
        }

        /// <summary>
        /// Edit Contact
        /// </summary>
        /// <param name="id"> guid </param>
        /// <param name="field"> field </param>
        /// <param name="fieldValue"> value to update </param>
        /// <returns> contact </returns>
        public ContactInfo EditContact(Guid id, int field, string? fieldValue)
        {
            ContactInfo contactInfo = new ();
            if (field == 2 && this.IsNumberExist(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number Already Exist";
                return contactInfo;
            }

            if (field == 1 && Validation.IsNameEmpty(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Name is Required";
                return contactInfo;
            }
            else if (field == 2 && Validation.IsNumberEmpty(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number is Required";
                return contactInfo;
            }
            else if (field == 2 && !Validation.IsNumber(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Phone Number should be 10 digit number";
                return contactInfo;
            }
            else if (field == 3 && !Validation.IsEmail(fieldValue))
            {
                contactInfo.Name = "Error Found";
                contactInfo.Notes = "Enter a valid Email";
                return contactInfo;
            }

            return this._contactRepository.EditContact(id, field, fieldValue);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id"> guid </param>
        public void DeleteContact(Guid id)
        {
            this._contactRepository.DeleteContact(id);
        }

        /// <summary>
        /// Check if phone number exist or not
        /// </summary>
        /// <param name="phoneNumber"> phone number </param>
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
