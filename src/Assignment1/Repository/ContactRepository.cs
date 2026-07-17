using Assignment1.Models;

namespace Assignment1.Repository
{
    /// <summary>
    /// Deals with all the data
    /// </summary>
    public class ContactRepository
    {
        private readonly List<ContactInfo> _contacts = new ();

        /// <summary>
        /// Views the contacts
        /// </summary>
        /// <returns> return the list of contact </returns>
        public List<ContactInfo> ViewContact()
        {
            return this.CloneCreation(this._contacts).OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Adds the Contact to list
        /// </summary>
        /// <param name="contactInfo">
        /// Object - contact to add
        /// </param>
        public void AddContact(ContactInfo contactInfo)
        {
            this._contacts.Add(contactInfo);
        }

        /// <summary>
        /// Search the contact
        /// </summary>
        /// <param name="searchWord">
        /// Word to be searched
        /// </param>
        /// <returns> List of contact matched</returns>
        public List<ContactInfo> SearchContact(string? searchWord)
        {
            List<ContactInfo> searchMatch = new ();
            foreach (ContactInfo contact in this._contacts)
            {
                if ((searchWord != null && contact.Name != null && contact.PhoneNumber != null) && (contact.Name.ToLower().Contains(searchWord.ToLower()) || contact.PhoneNumber.ToLower().Contains(searchWord.ToLower())))
                {
                    searchMatch.Add(contact);
                }
            }

            return this.CloneCreation(searchMatch).OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Delete the contact
        /// </summary>
        /// <param name="id">
        /// word to be deleted
        /// </param>
        public void DeleteContact(Guid? id)
        {
            foreach (ContactInfo contact in this._contacts)
            {
                if (contact.Id == id)
                {
                    this._contacts.Remove(contact);
                    break;
                }
            }
        }

        /// <summary>
        /// Edit the contact
        /// </summary>
        /// <param name="id"> Contact Id </param>
        /// <param name="field"> Contact Property </param>
        /// <param name="fieldValue"> Edit data </param>
        /// <returns> Updated contact </returns>
        public ContactInfo EditContact(Guid? id, int field, string? fieldValue)
        {
            ContactInfo contactInfo = new ();
            foreach (ContactInfo contact in this._contacts)
            {
                if (contact.Id == id)
                {
                    contactInfo = contact;
                    switch (field)
                    {
                        case 1:
                            contact.Name = fieldValue;
                            break;
                        case 2:
                            contact.PhoneNumber = fieldValue;
                            break;
                        case 3:
                            contact.Email = fieldValue;
                            break;
                        case 4:
                            contact.Notes = fieldValue;
                            break;
                    }
                }
            }

            return contactInfo;
        }

        /// <summary>
        /// Create clone of original list
        /// </summary>
        /// <param name="contacts"> List of contacts </param>
        /// <returns> Clone of contacts list </returns>
        public List<ContactInfo> CloneCreation(List<ContactInfo> contacts)
        {
            List<ContactInfo> contactsCopy = new ();
            foreach (ContactInfo contact in contacts)
            {
                ContactInfo contactCopy = new ();
                contactCopy.Id = contact.Id;
                contactCopy.Name = contact.Name;
                contactCopy.PhoneNumber = contact.PhoneNumber;
                contactCopy.Email = contact.Email;
                contactCopy.Notes = contact.Notes;
                contactsCopy.Add(contactCopy);
            }

            return contactsCopy;
        }
    }
}
