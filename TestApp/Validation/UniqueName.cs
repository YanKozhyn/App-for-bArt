using System.ComponentModel.DataAnnotations;
using TestApp.Data;

namespace TestApp.Validation
{
    public class UniqueName : ValidationAttribute
    {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DataContext _dbContext = (DataContext)validationContext.GetService(typeof(DataContext));

        if (_dbContext.Accounts.FirstOrDefault(account => account.Name.ToUpper() == value.ToString().ToUpper()) is null)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Name is exits in system, pleas enter another name");
    }
    }
}