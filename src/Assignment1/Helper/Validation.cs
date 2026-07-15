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
        public bool IsNumberExist(ContactInfo contactInfo)
        {
            //List<ContactInfo> contacts = _manager.ViewContact();
            //foreach (ContactInfo contact in contacts)
            //{
            //    if (contact.PhoneNumber == contactInfo.PhoneNumber)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }
    }
}
