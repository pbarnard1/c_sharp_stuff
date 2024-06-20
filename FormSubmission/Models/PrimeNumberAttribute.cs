using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace FormSubmission.Models; 

public class PrimeNumberAttribute : ValidationAttribute // The validation will be called NotFutureDate when called upon (no "Attribute")
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
        if (!validatePrime(actualValue)) // Validate for prime number
        {
            return new ValidationResult($"The value {actualValue} is not a prime number.  It must be prime."); // Return error message
        }
        return ValidationResult.Success; // Validation is okay if we make it here
    }

    private Boolean validatePrime(int val)
    {
        if (val == 2)
        {
            return true;
        }
        if (val % 2 == 0) // If divisible by 2 and NOT 2 itself, it's not prime
        {
            return false;
        }
        double maxDoubleToCheck = Math.Sqrt((double) val); // Grab square root
        int maxValToCheck = (int) maxDoubleToCheck; // Convert to in
        // Loop to check to see if the value is divisible by k
        for (int k = 2; k <= maxValToCheck; k++)
        {
            if (val % k == 0)
            {
                return false;
            }
        }
        return true;
    }
}