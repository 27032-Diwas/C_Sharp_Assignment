using Assignment1.Models;

namespace Assignment1.Repository
{
    /// <summary>
    /// Deals with all the data
    /// </summary>
    public class ContactRepository
    {
        private static readonly List<ContactInfo> Contacts = new ();

        /// <summary>
        /// Views the contact
        /// </summary>
        /// <returns> return the list of contact </returns>
        public List<ContactInfo> ViewContact()
        {
            return Contacts.OrderBy(x => x.Name).ToList();
        }

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
        /// Search the contact
        /// </summary>
        /// <param name="searchWord">
        /// Word to be searched
        /// </param>
        /// <returns> the list of contact matched</returns>
        public List<ContactInfo> SearchContact(string? searchWord)
        {
            List<ContactInfo> searchMatch = new ();
            foreach (ContactInfo contact in Contacts)
            {
                if ((searchWord != null && contact.Name != null && contact.PhoneNumber != null) && (contact.Name.ToLower().Contains(searchWord.ToLower()) || contact.PhoneNumber.ToLower().Contains(searchWord.ToLower())))
                {
                    searchMatch.Add(contact);
                }
            }

            return searchMatch;
        }

        /// <summary>
        /// Delete the contact
        /// </summary>
        /// <param name="id">
        /// word to be deleted
        /// </param>
        public void DeleteContact(Guid id)
        {
            foreach (ContactInfo contact in Contacts)
            {
                if (contact.Id == id)
                {
                    Contacts.Remove(contact);
                    break;
                }
            }
        }

        /// <summary>
        /// Edit the contact
        /// </summary>
        /// <param name="id"> Index </param>
        /// <param name="field"> Field to edit </param>
        /// <param name="fieldValue"> new data </param>
        /// <returns> Updated contact </returns>
        public ContactInfo EditContact(Guid id, int field, string? fieldValue)
        {
            ContactInfo contactInfo = new ();
            foreach (ContactInfo contact in Contacts)
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
    }
}
