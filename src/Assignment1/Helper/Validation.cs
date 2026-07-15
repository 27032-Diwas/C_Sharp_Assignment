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
        /// <param name="name"> object </param>
        /// <returns> isCorrect</returns>
        public bool IsNameEmpty(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }
        /// <summary>
        /// is number empty 
        /// </summary>
        /// <param name="phoneNumber"> number </param>
        /// <returns> true or false </returns>
        public bool IsNumberEmpty(string phoneNumber)
        {
            return string.IsNullOrWhiteSpace(phoneNumber);
        }

        /// <summary>
        /// is number valid
        /// </summary>
        /// <param name="phone"> number </param>
        /// <returns> true of false </returns>
        public bool IsNumber(string phone)
        {
            return phone.Length == 10 && phone.All(char.IsDigit);
        }

        /// <summary>
        /// is email valide
        /// </summary>
        /// <param name="email"> email </param>
        /// <returns> true or false </returns>
        public bool IsEmail(string email)
        {
            return email.Contains('@') && email.Contains('.');
        }
    }
}
