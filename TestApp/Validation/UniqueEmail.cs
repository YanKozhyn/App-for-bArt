using System.ComponentModel.DataAnnotations;
using TestApp.Data;

namespace TestApp.Validation
{
    public class UniqueEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DataContext _context = (DataContext) validationContext.GetService(typeof(DataContext))!;

            if (_context.Contacts.FirstOrDefault(c => c.Email.ToLower() == value.ToString().ToLower()) is null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Email already exist, pleas enter another email.");
        }
    }
}