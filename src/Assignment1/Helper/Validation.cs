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
        ContactRepository contactRepository = new ContactRepository();

        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="contactInfo"> object </param>
        /// <returns> isCorrect</returns>
        public bool DataValidation(ContactInfo contactInfo)
        {
            if (contactRepository.IndexOfContact(contactInfo.PhoneNumber) != -1)
            {
                Console.WriteLine("Mobile Number Already Exist");
                return false;
            }

            return true;
        }
    }
}
