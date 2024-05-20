using System.ComponentModel.DataAnnotations;

namespace CSharp_FinalExam.Infrastructure.CustomValidation;

public class VietPhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var phoneNumber = value as string;
        if (phoneNumber == null)
        {
            return new ValidationResult("Số điện thoại không hợp lệ.");
        }

        if (phoneNumber.Length != 10)
        {
            return new ValidationResult("Số điện thoại phải có 10 ký tự.");
        }

        var validStarts = new[] { "090", "098", "091", "031", "035", "038" };
        if (!validStarts.Any(phoneNumber.StartsWith))
        {
            return new ValidationResult("Số điện thoại phải bắt đầu bằng một trong các chuỗi số sau: 090, 098, 091, 031, 035, 038.");
        }

        return ValidationResult.Success;
    }
}