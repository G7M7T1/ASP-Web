using System.ComponentModel.DataAnnotations;

namespace ModelValidations.CustomValidators
{
    public class MinimumBirthdayValidatorAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year <= DateTime.Now.Year - 130)
                {
                    return new ValidationResult(ErrorMessage);
                }

                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
