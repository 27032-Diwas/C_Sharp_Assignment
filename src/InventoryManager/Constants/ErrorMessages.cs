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
    public const string InvalidDigit = "ENTER A VALID NUMBER!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid product name.
    /// </summary>
    public const string InvalidProductName = "Invalid Product Name!! Only letters, numbers, spaces, and allowed symbols are permitted.";

    /// <summary>
    /// Represents the message displayed when the user enters an invalid option.
    /// </summary>
    public const string InvalidOption = "ENTER A VALID OPTION!!";

    /// <summary>
    /// Represents the message displayed when product list is empty.
    /// </summary>
    public const string EmptyList = "NO PRODUCT FOUND!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid serial number.
    /// </summary>
    public const string InvalidSerialNumber = "SERIAL NUMBER SHOULD BE WITHIN THE RANGE!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid product price.
    /// </summary>
    public static readonly string InvalidProductPrice = $"PRODUCT PRICE SHOULD BE GREATER THAN ZERO && LESS THAN {Configurables.MaxPriceThreshold}!!";

    /// <summary>
    /// Represents the message displayed when the user enter an invalid product quantity.
    /// </summary>
    public static readonly string InvalidProductQuantity = $"PRODUCT QUANTITY SHOULD BE GREATER THAN ZERO && LESS THAN {Configurables.MaxQuantityThreshold}!!";
}
