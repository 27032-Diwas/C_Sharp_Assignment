using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    /// <summary>
    /// contact info
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// Gets or sets guid
        /// </summary>
        /// <value> id for data</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value> name for data </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value> number for data </value>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value> email for data </value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <value> notes for data </value>
        public string? Notes { get; set; }
    }
}
