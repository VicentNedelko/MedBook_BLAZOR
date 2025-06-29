using System.ComponentModel.DataAnnotations;

namespace Business.Helpers
{
    public class GraterThen(string comparisonProperty) : ValidationAttribute
    {
        private readonly string comparisonProperty = comparisonProperty;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (double)value;

            var property = validationContext.ObjectType.GetProperty(comparisonProperty);
            if (property is not null)
            {
                var comparisonValue = (double)property.GetValue(validationContext.ObjectInstance);

                if (comparisonValue >= currentValue)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }

            throw new ArgumentException("Property with this name not found");
        }
    }
}
