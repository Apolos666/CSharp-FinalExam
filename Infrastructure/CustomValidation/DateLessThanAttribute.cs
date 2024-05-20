using System.ComponentModel.DataAnnotations;

namespace CSharp_FinalExam.Infrastructure.CustomValidation;

public class DateLessThanAttribute : ValidationAttribute
{
    private readonly string _comparisionProperty;

    public DateLessThanAttribute(string comparisionProperty)
    {
        _comparisionProperty = comparisionProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var currentValue = (DateTime)value;

        var comparisonValue = (DateTime)validationContext.ObjectType.GetProperty(_comparisionProperty).GetValue(validationContext.ObjectInstance);

        if (currentValue >= comparisonValue)
        {
            return new ValidationResult(ErrorMessage = "Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
        }

        return ValidationResult.Success;
    }
}