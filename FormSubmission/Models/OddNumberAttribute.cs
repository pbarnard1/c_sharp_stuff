using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace FormSubmission.Models; 

public class OddNumberAttribute : ValidationAttribute // The validation will be called NotFutureDate when called upon (no "Attribute")
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please enter a valid integer!");
        }
        if (!(value is int))
        {
            return new ValidationResult("This is not an integer.");
        }
        int actualValue = (int) value;
        if (actualValue % 2 == 0) // Even value
        {
            return new ValidationResult($"The value {actualValue} is even.  It must be odd."); // Return error message
        }
        return ValidationResult.Success; // Validation is okay if we make it here
    }
}