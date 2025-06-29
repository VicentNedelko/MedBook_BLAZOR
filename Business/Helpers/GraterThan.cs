using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Business.Helpers
{
    public class GraterThen(string comparisonProperty, string type) : ValidationAttribute
    {
        private readonly string comparisonProperty = comparisonProperty;
        private readonly string type = type;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var actualType = validationContext.ObjectType.GetProperty(type);
            var indType = actualType.PropertyType.GetEnumUnderlyingType();
            var typeValue = Convert.ChangeType(actualType.GetValue(validationContext.ObjectInstance), indType);
            if ((int)typeValue == 0)
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

            return ValidationResult.Success;
        }
    }
}
