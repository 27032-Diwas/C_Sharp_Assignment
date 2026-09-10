using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Exceptions;

/// <summary>
/// Custom exception for database failure.
/// </summary>
public class DataBaseException : Exception
{
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="DataBaseException"/> class.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="innerException">Inner exception.</param>
    public DataBaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
