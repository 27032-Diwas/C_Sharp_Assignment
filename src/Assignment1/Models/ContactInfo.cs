namespace ContactManager.Models;

/// <summary>
/// Contains contact's properties.
/// </summary>
public class ContactInfo
{
    /// <summary>
    /// Gets or init guid.
    /// </summary>
    /// <value> id for data. </value>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets name.
    /// </summary>
    /// <value> name for data </value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets phone number.
    /// </summary>
    /// <value> number for data. </value>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets email address.
    /// </summary>
    /// <value> email for data. </value>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets
    /// </summary>
    /// <value> notes for data. </value>
    public string? Notes { get; set; }
}
