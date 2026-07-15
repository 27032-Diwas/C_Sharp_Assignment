using Assignment1.View;
using AssignmentBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    /// <summary>
    /// Deals with all the data
    /// </summary>
    public class ContactRepository
    {
        // object
        ConsoleInputs concoleInputs = new ConsoleInputs();

        private static List<ContactInfo> Contacts = new List<ContactInfo>();

        /// <summary>
        /// Adds the Contact to lilst
        /// </summary>
        /// <param name="contactInfo">
        /// object
        /// </param>
        public void AddContact(ContactInfo contactInfo)
        {
            Contacts.Add(contactInfo);
        }

        /// <summary>
        /// Views the contact
        /// </summary>
        public void ViewContact()
        {
            foreach (ContactInfo contact in Contacts)
            {
                concoleInputs.DisplayDetails(contact);
            }
        }

        /// <summary>
        /// Search the contact
        /// </summary>
        /// <param name="indexOfContact">
        /// Word to be searched
        /// </param>
        public void SearchContact(int indexOfContact)
        {
            concoleInputs.DisplayDetails(Contacts[indexOfContact]);
        }

        /// <summary>
        /// Delete the contact
        /// </summary>
        /// <param name="indexOfContact">
        /// word to be deleted
        /// </param>
        public void DeleteContact(int indexOfContact)
        {
            Contacts.RemoveAt(indexOfContact);
        }

        /// <summary>
        /// Search the word and return index
        /// </summary>
        /// <param name="searchWord">
        /// word to be searched
        /// </param>
        /// <returns>
        /// the index
        /// </returns>
        public int IndexOfContact(string searchWord)
        {
            foreach (ContactInfo contact in Contacts)
            {
                if (contact.Name == searchWord || contact.PhoneNumber == searchWord)
                {
                    return Contacts.IndexOf(contact);
                }
            }
            return -1;
        }

        /// <summary>
        /// Edit the contact
        /// </summary>
        /// <param name="indexOfContact"> Index </param>
        /// <param name="fieldOfContact"> Field to edit </param>
        /// <param name="newDetail"> new data </param>
        public void EditContact(int indexOfContact, int fieldOfContact, string newDetail)
        {
            switch (fieldOfContact)
            {
                case 1:
                    Contacts[indexOfContact].Name = newDetail;
                    break;
                case 2:
                    Contacts[indexOfContact].PhoneNumber = newDetail;
                    break;
                case 3:
                    Contacts[indexOfContact].Email = newDetail;
                    break;
                case 4:
                    Contacts[indexOfContact].Notes = newDetail;
                    break;
            }
        }
    }
}
