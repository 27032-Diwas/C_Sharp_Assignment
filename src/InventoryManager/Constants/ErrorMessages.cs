namespace InventoryManager.Constants;

/// <summary>
/// Contains all error messages.
/// </summary>
public class ErrorMessages
{
    /// <summary>
    /// Represents the message displayed when the user does not enter anything.
    /// </summary>
    public const string InvalidString = "ENTER A VALUE!!";

    /// <summary>
    /// Represents the message displayed when the user enter an non numeric value.
    /// </summary>
    public const string InvalidDigit = "ENTER A NUMBER!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid product name.
    /// </summary>
    public const string InvalidProductName = "ENTER A VALID NAME!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid product price.
    /// </summary>
    public const string InvalidProductPrice = "PRODUCT PRICE SHOULD BE GREATER THAN ZERO!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid product quantity.
    /// </summary>
    public const string InvalidProductQuantity = "PRODUCT QUANTITY CAN NOT BE NEGATIVE!!";

    /// <summary>
    /// Represents the message displayed when the user enters an invalid option.
    /// </summary>
    public const string InvalidOption = "ENTER A VALID OPTION!!";

    /// <summary>
    /// Represent the message displayed when product list is empty.
    /// </summary>
    public const string EmptyList = "NO PRODUCT FOUND!!\n";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid serial number.
    /// </summary>
    public const string InvalidSerialNumber = "SERIAL NUMBER SHOULD BE WITHIN THE RANGE!!";
}
