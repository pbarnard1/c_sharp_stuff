using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace DateValidatorProject.Models;

public class RequiredNotFutureDateAttribute : ValidationAttribute // The validation will be called NotFutureDate when called upon (no "Attribute")
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please enter a valid date!");
        }
        else if (((DateOnly) value).CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0) // Positive means in the future
        {
            return new ValidationResult($"The date {value} is in the future.  It must be in the past or today."); // Return error message
        }
        else
        {
            return ValidationResult.Success; // Validation is okay
        }
    }
}