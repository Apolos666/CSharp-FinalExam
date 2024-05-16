using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CSharp_FinalExam.Infrastructure.CustomValidation;

public class DateVietFormatAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dateValue = value as DateTime?;
        if (dateValue == null)
        {
            return new ValidationResult("Ngày sinh không hợp lệ.");
        }

        var dateString = dateValue.Value.ToString("dd/MM/yyyy");
        if (!DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, DateTimeStyles.None, out _))
        {
            return new ValidationResult("Ngày sinh phải theo định dạng dd/MM/yyyy.");
        }

        return ValidationResult.Success;
    }
}