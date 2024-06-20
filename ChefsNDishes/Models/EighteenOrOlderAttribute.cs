using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace ChefsNDishes.Models;

public class EighteenOrOlderAttribute : ValidationAttribute // The validation will be called EighteenOrOlder when called upon (no "Attribute")
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Please enter a valid date!");
        }
        else if (((DateOnly) value).CompareTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18))) > 0) // Positive means younger than 18
        {
            return new ValidationResult($"As of today, the chef must be at least 18 years of age."); // Return error message
        }
        else
        {
            return ValidationResult.Success; // Validation is okay
        }
    }
}