using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TechChallenge.Domain.Attributes
{
    public partial class BrazilPhoneNumberAttribute : ValidationAttribute
    {
        [GeneratedRegex(@"^\(?\d{2}\)?[\s-]?9?\d{4}[\s-]?\d{4}$")]
        public static partial Regex RegexBrazilPhoneNumber();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var telefone = value.ToString();
            var regex = RegexBrazilPhoneNumber();

            if (telefone is not null && regex.IsMatch(telefone))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("O número de telefone informado não é válido.");
        }
    }
}