using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasics.Models
{
    /// <summary>
    /// contact info
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// guid
        /// </summary>
        /// <value> id for data</value>
        public Guid Id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        /// <value> name for data </value>
        public string? Name { get; set; }
        /// <summary>
        /// phone number
        /// </summary>
        /// <value> number for data </value>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// email
        /// </summary>
        /// <value> email for data </value>
        public string? Email { get; set; }
        /// <summary>
        /// notes
        /// </summary>
        /// <value> notes for data </value>
        public string? Notes { get; set; }
    }
}
