using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace gerdisc.Models.Validations
{
    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var email = value as string;
            if (email == null) return false;

            // Your custom validation logic goes here
            // For example, you can use a regular expression to validate the email format
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
    }
}