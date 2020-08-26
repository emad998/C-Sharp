using System;
using System.ComponentModel.DataAnnotations;
namespace LogReg.Extensions
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(DateTime.Now > Convert.ToDateTime(value))
            {
                return new ValidationResult("Date Must be in the Future");
            }
            return ValidationResult.Success;
        }
    }
}