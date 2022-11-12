using System.ComponentModel.DataAnnotations;
using TestApp.Data;

namespace TestApp.Validation
{
    public class UniqueEmail : ValidationAttribute
    {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DataContext _dbContext = (DataContext)validationContext.GetService(typeof(DataContext))!;

        if (_dbContext.Contacts.FirstOrDefault(contact =>
                contact.Email.ToUpper() == value.ToString().ToUpper()) is null)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Email already exist");
    }
    }
}