// <copyright file="MessageConstants.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ContactManager.Constants;

/// <summary>
/// Contains strings that are repeatedly used.
/// </summary>
public static class MessageConstants
{
    /// <summary>
    /// Message displayed when the user enters an invalid menu option.
    /// </summary>
    public const string InvalidOption = "ENTER A VALID OPTION!!";

    /// <summary>
    /// Confirmation prompt displayed before deleting a contact.
    /// </summary>
    public const string ConfirmDelete = "Do you want to delete (Y/N):";

    /// <summary>
    /// Message displayed when validation is completed successfully.
    /// </summary>
    public const string ValidationSuccessful = "VALIDATION IS SUCCESSFUL!!";

    /// <summary>
    /// Message displayed when the application process ends.
    /// </summary>
    public const string ProcessEnded = "END PROCESS!!";

    /// <summary>
    /// Header displayed for the View Contact operation.
    /// </summary>
    public const string ViewContact = "VIEW CONTACT";

    /// <summary>
    /// Header displayed for the Add Contact operation.
    /// </summary>
    public const string AddContact = "ADD CONTACT";

    /// <summary>
    /// Header displayed for the Search Contact operation.
    /// </summary
    public const string SearchContact = "SEARCH CONTACT";

    /// <summary>
    /// Header displayed for the Edit Contact operation.
    /// </summary>
    public const string EditContact = "EDIT CONTACT";

    /// <summary>
    /// Header displayed for the Delete Contact operation.
    /// </summary>
    public const string DeleteContact = "DELETE CONTACT";

    /// <summary>
    /// Message displayed when an operation is cancelled by the user.
    /// </summary>
    public const string ProcessCancelled = "PROCESS CANCELLED!!";

    /// <summary>
    /// Message displayed when no contacts are available.
    /// </summary>
    public const string NoContactsExist = "NO CONTACTS EXIST!!";

    /// <summary>
    /// Message displayed when no input value is provided.
    /// </summary>
    public const string NoValueEntered = "NO VALUE ENTERED!!";

    /// <summary>
    /// Message displayed when no matching contact is found.
    /// </summary>
    public const string NoMatchFound = "NO MATCH FOUND!!";

    /// <summary>
    /// Label for the Name field.
    /// </summary>
    public const string Name = "Name";

    /// <summary>
    /// Label for the Phone Number field.
    /// </summary>
    public const string PhoneNumber = "Phone Number";

    /// <summary>
    /// Label for the Email field.
    /// </summary>
    public const string Email = "Email";

    /// <summary>
    /// Label for the Notes field.
    /// </summary>
    public const string Notes = "Notes";

    /// <summary>
    /// Prompt requesting the user to select a field to edit.
    /// </summary>
    public const string SelectFieldToEdit = "Choose a field to edit:";

    /// <summary>
    /// Prompt requesting the user to select one of the available options.
    /// </summary>
    public const string SelectOption = "Select one of the below options:";

    /// <summary>
    /// Message displayed when a contact is updated successfully.
    /// </summary>
    public const string ContactUpdatedSuccessfully = "CONTACT EDITED SUCCESSFULLY!!!";

    /// <summary>
    /// Message displayed when a contact is deleted successfully.
    /// </summary>
    public const string ContactDeletedSuccessfully = "CONTACT DELETED SUCCESSFULLY!!!";

    /// <summary>
    /// Message displayed when a contact is added successfully.
    /// </summary>
    public const string ContactAddedSuccessfully = "CONTACT ADDED SUCCESSFULLY!!!";

    /// <summary>
    /// Message displayed when the contact identifier is missing.
    /// </summary>
    public const string ContactIdRequired = "ID SHOULD NOT BE NULL!!!";

    /// <summary>
    /// Message displayed when the contact name contains fewer than two characters.
    /// </summary>
    public const string NameTooShort = "NAME SHOULD CONTAIN AT LEAST 2 CHARACTERS AND CONTAINS ONE ALPHABETES!!!";

    /// <summary>
    /// The maximum allowed length for notes.
    /// </summary>
    public const int NotesMaximumLength = 50;

    /// <summary>
    /// Message displayed when the contact name is not provided.
    /// </summary>
    public const string NameRequired = "NAME IS REQUIRED!!!";

    /// <summary>
    /// Message displayed when the phone number is not provided.
    /// </summary>
    public const string PhoneNumberRequired = "PHONE NUMBER IS REQUIRED!!!";

    /// <summary>
    /// Message displayed when the phone number is not a valid 10-digit number.
    /// </summary>
    public const string InvalidPhoneNumber = "PHONE NUMBER SHOULD BE A 10-DIGIT VALID NUMBER!!!";

    /// <summary>
    /// Message displayed when the phone number already exists.
    /// </summary>
    public const string DuplicatePhoneNumber = "PHONE NUMBER ALREADY EXISTS!!!";

    /// <summary>
    /// Message displayed when an invalid email address is entered.
    /// </summary>
    public const string InvalidEmailAddress = "ENTER A VALID EMAIL ADDRESS!!!";

    /// <summary>
    /// Message displayed when notes exceed the maximum allowed length.
    /// </summary>
    public static readonly string NotesExceedMaximumLength = $"NOTES SHOULD BE LESS THAN {NotesMaximumLength} CHARACTERS!!!";
}
