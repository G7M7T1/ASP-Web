using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidations.CustomValidators
{
    public class DateRangeValidatorAttribute: ValidationAttribute
    {
        public string OtherProperty { get; set; }

        public DateRangeValidatorAttribute(string otherProperty) 
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);

                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);

                if (otherProperty != null)
                {
                    otherProperty?.GetValue(validationContext.ObjectInstance);

                    DateTime from_date = Convert.ToDateTime(otherProperty?.GetValue(validationContext.ObjectInstance));

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherProperty, validationContext.MemberName });
                    }

                    else
                    {
                        return ValidationResult.Success;
                    }
                }

                return null;
            }
            return null;
        }
    }
}
