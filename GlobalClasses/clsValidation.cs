using System.Text.RegularExpressions;






namespace BusinessLayer
{
    public class clsValidation
    {
        public static bool ValidateEmail(string EmailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*$";

            var Regex = new Regex(pattern);

            return Regex.IsMatch(EmailAddress);
        }
    }
}
