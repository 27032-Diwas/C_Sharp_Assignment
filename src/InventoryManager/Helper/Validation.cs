using System.Text.RegularExpressions;
using InventoryManager.Constants;

namespace InventoryManager.Helper;

/// <summary>
/// Contains all the validations.
/// </summary>
public static class Validation
{
    /// <summary>
    /// Determines whether the specified product name is valid.
    /// </summary>
    /// <param name="productName"> The product name to validate. </param>
    /// <returns> True if the name contains at least two characters and matches the required pattern; otherwise false. </returns>
    public static bool IsProductNameValid(string productName) => !string.IsNullOrEmpty(productName)
                                                          && Regex.IsMatch(productName, RegexPatterns.ProductNameRegex);

    /// <summary>
    /// Determines whether the specified product price is valid.
    /// </summary>
    /// <param name="productPrice"> The product price to validate. </param>
    /// <returns> True if the product price is greater than or equal to zero; otherwise false. </returns>
    public static bool IsProductPriceValid(decimal productPrice) => productPrice >= 0 && productPrice < Configurables.MaxPriceThreshold;

    /// <summary>
    /// Determine whether the specified product quantity is valid.
    /// </summary>
    /// <param name="productQuantity"> The product quantity to validate.</param>
    /// <returns> True if the product quantity is greater than or equal to zero; otherwise false. </returns>
    public static bool IsProductQuantityValid(int productQuantity) => productQuantity >= 0 && productQuantity < Configurables.MaxQuantityThreshold;
}
