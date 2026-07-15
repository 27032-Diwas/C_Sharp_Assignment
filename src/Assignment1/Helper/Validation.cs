using Assignment1.Repository;
using AssignmentBasics.Models;
using AssignmentBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBasics.Helper
{
    /// <summary>
    /// Validating all data
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="contactInfo"> object </param>
        /// <returns> isCorrect</returns>
        public bool IsNameEmpty(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }
        public bool IsNumberEmpty(string phoneNumber)
        {
            return string.IsNullOrWhiteSpace(phoneNumber);
        }
        public bool IsNumber(string phone)
        {
            return phone.Length == 10 && phone.All(char.IsDigit);
        }

        public bool IsEmail(string email)
        {
            return email.Contains('@') && email.Contains('.');
        }
    }
}
