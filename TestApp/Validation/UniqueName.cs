using System.ComponentModel.DataAnnotations;
using TestApp.Data;

namespace TestApp.Validation
{
    public class UniqueName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

                DataContext _context = (DataContext)validationContext.GetService(typeof(DataContext));

                if (_context.Accounts.FirstOrDefault(acc => acc.Name.ToLower() == value.ToString().ToLower()) is null)
                {   
                    return ValidationResult.Success;
                }  
                return new ValidationResult(ErrorMessage ?? "Name is exits in system, pleas enter another name");         


            
        }
    }
}