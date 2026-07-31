// <copyright file="ContactRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ContactManager.Repository;

using ContactManager.Constants;
using ContactManager.Models;

/// <summary>
/// Contains all the methods that work with contact list.
/// </summary>
public class ContactRepository
{
    private readonly List<ContactInfo> contacts = new ();

    /// <summary>
    /// Views the contacts.
    /// </summary>
    /// <returns> list of contacts. </returns>
    public List<ContactInfo> ViewContact() => this.CreateDuplicate(this.contacts).OrderBy(x => x.Name).ToList();

    /// <summary>
    /// Adds the Contact to list.
    /// </summary>
    /// <param name="contactInfo">
    /// Contact to add.
    /// </param>
    public void AddContact(ContactInfo contactInfo) => this.contacts.Add(contactInfo);

    /// <summary>
    /// Search the contact.
    /// </summary>
    /// <param name="searchWord">
    /// Word to be searched.
    /// </param>
    /// <returns> List of contacts matched. </returns>
    public List<ContactInfo> SearchContact(string? searchWord)
    {
        List<ContactInfo> searchMatch = new ();
        foreach (ContactInfo contact in this.contacts)
        {
            if ((searchWord != null && contact.Name != null && contact.PhoneNumber != null && contact.Email != null)
                && (contact.Name.Contains(searchWord, StringComparison.OrdinalIgnoreCase)
                || contact.PhoneNumber.Contains(searchWord, StringComparison.OrdinalIgnoreCase)
                || contact.Email.Contains(searchWord, StringComparison.OrdinalIgnoreCase)))
            {
                searchMatch.Add(contact);
            }
        }

        return this.CreateDuplicate(searchMatch).OrderBy(x => x.Name).ToList();
    }

    /// <summary>
    /// Delete contact.
    /// </summary>
    /// <param name="id">
    /// Word to be deleted.
    /// </param>
    public void DeleteContact(Guid? id)
    {
        foreach (ContactInfo contact in this.contacts)
        {
            if (contact.Id == id)
            {
                this.contacts.Remove(contact);
                break;
            }
        }
    }

    /// <summary>
    /// Edit the contact.
    /// </summary>
    /// <param name="id"> Contact Id. </param>
    /// <param name="contactField"> Contact Property. </param>
    /// <param name="contactDetail"> Edit data. </param>
    /// <returns> Message. </returns>
    public string EditContact(Guid? id, int contactField, string? contactDetail)
    {
        if (id == null)
        {
            return MessageConstants.ContactIdRequired;
        }

        foreach (ContactInfo contact in this.contacts)
        {
            if (contact.Id == id)
            {
                switch (contactField)
                {
                    case 1:
                        contact.Name = contactDetail;
                        break;
                    case 2:
                        contact.PhoneNumber = contactDetail;
                        break;
                    case 3:
                        contact.Email = contactDetail;
                        break;
                    case 4:
                        contact.Notes = contactDetail;
                        break;
                }

                break;
            }
        }

        return MessageConstants.ContactUpdatedSuccessfully;
    }

    /// <summary>
    /// Create clone of original list.
    /// </summary>
    /// <param name="contacts"> List of contact.s. </param>
    /// <returns> Clone of contacts list. </returns>
    private List<ContactInfo> CreateDuplicate(List<ContactInfo> contacts)
    {
        List<ContactInfo> contactsCopy = new ();
        foreach (ContactInfo contact in contacts)
        {
            ContactInfo contactCopy = new ()
            {
                Id = contact.Id,
            };
            contactCopy.Name = contact.Name;
            contactCopy.PhoneNumber = contact.PhoneNumber;
            contactCopy.Email = contact.Email;
            contactCopy.Notes = contact.Notes;
            contactsCopy.Add(contactCopy);
        }

        return contactsCopy;
    }
}
