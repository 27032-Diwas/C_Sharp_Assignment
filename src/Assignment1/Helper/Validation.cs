namespace Assignment1.Helper
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
        public static bool IsNameEmpty(string? name)
        {
            return string.IsNullOrWhiteSpace(name) || name == "Error Found";
        }

        /// <summary>
        /// is number empty
        /// </summary>
        /// <param name="phoneNumber"> number </param>
        /// <returns> true or false </returns>
        public static bool IsNumberEmpty(string? phoneNumber)
        {
            return string.IsNullOrWhiteSpace(phoneNumber);
        }

        /// <summary>
        /// is number valid
        /// </summary>
        /// <param name="phone"> number </param>
        /// <returns> true of false </returns>
        public static bool IsNumber(string? phone)
        {
            if (phone == null)
            {
                return false;
            }

            return phone.Length == 10 && phone.All(char.IsDigit);
        }

        /// <summary>
        /// is email valide
        /// </summary>
        /// <param name="email"> email </param>
        /// <returns> true or false </returns>
        public static bool IsEmail(string? email)
        {
            if (email == string.Empty)
            {
                return true;
            }
            else if (email == null)
            {
                return false;
            }

            return email.Contains('@') && email.Contains('.');
        }
    }
}
