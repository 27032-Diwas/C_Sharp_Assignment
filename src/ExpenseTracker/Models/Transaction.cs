using ExpenseTracker.Enums;

namespace ExpenseTracker.Models;

/// <summary>
/// Contains properties and method for transaction.
/// </summary>
public class Transaction
{
    /// <summary>
    /// Gets or sets transaction id.
    /// </summary>
    /// <value> Id of the transaction. </value>
    public Guid TransactionId { get; set; }

    /// <summary>
    /// Gets or sets date.
    /// </summary>
    /// <value> Date of transaction. </value>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets amount.
    /// </summary>
    /// <value> Amount transferred in the transaction.</value>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets transaction category.
    /// </summary>
    /// <value> Transaction category. </value>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets transaction type.
    /// </summary>
    /// <value> Transaction type. </value>
    public TransactionTypes TransactionType { get; set; }

    /// <summary>
    /// Gets or sets transaction description.
    /// </summary>
    /// <value> Description of the transaction. </value>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Clones the transaction.
    /// </summary>
    /// <returns> Cloned instance of transaction. </returns>
    public Transaction Clone()
    {
        return new ()
        {
            TransactionId = this.TransactionId,
            Amount = this.Amount,
            Date = this.Date,
            Category = this.Category,
            TransactionType = this.TransactionType,
            Description = this.Description,
        };
    }
}
