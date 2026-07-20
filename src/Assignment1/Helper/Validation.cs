namespace Assignment1.Helper
{
    /// <summary>
    /// Validating all data
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Is name empty
        /// </summary>
        /// <param name="name"> object </param>
        /// <returns> isCorrect</returns>
        public static bool IsNameEmpty(string? name) => string.IsNullOrWhiteSpace(name) || name == string.Empty;

        /// <summary>
        /// Is number empty
        /// </summary>
        /// <param name="phoneNumber"> number </param>
        /// <returns> true or false </returns>
        public static bool IsNumberEmpty(string? phoneNumber) => string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber == string.Empty;

        /// <summary>
        /// Is number valid
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
        /// Is email valide
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

        /// <summary>
        /// Check for notes length
        /// </summary>
        /// <param name="notes"> Notes </param>
        /// <returns> true or false</returns>
        public static bool IsNotes(string? notes)
        {
            if (notes == string.Empty)
            {
                return true;
            }
            else if (notes == null)
            {
                return false;
            }

            return notes.Length < 50;
        }
    }
}
