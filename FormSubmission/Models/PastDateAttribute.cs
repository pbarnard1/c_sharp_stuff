using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace FormSubmission.Models; 

public class PastDateAttribute : ValidationAttribute // The validation will be called NotFutureDate when called upon (no "Attribute")
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please enter a valid date!");
        }
        else if (((DateOnly) value).CompareTo(DateOnly.FromDateTime(DateTime.Now)) >= 0) // Positive means in the future, 0 is today
        {
            return new ValidationResult($"The date {value} is not in the past."); // Return error message
        }
        else
        {
            return ValidationResult.Success; // Validation is okay
        }
    }
}