using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace WeddingPlanner.Models;

public class FutureDateAttribute : ValidationAttribute // The validation will be called EighteenOrOlder when called upon (no "Attribute")
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please enter a valid wedding date!");
        }
        else if (((DateOnly) value).CompareTo(DateOnly.FromDateTime(DateTime.Now)) <= 0) // -1 = value is before now, 0 = value is now, 1 = value is in future
        {
            return new ValidationResult($"The wedding date must be after today."); // Return error message
        }
        else
        {
            return ValidationResult.Success; // Validation is okay
        }
    }
}