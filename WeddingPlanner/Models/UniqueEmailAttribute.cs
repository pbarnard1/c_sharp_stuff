using System.ComponentModel.DataAnnotations; // So we can grab the ValidationAttribute class we'll inherit from for our custom validator
namespace WeddingPlanner.Models; // Make sure your project name is correct!!

public class UniqueEmailAttribute : ValidationAttribute // The validation will be called UniqueEmail when called upon (no "Attribute")
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) // Nothing entered
        {
            return new ValidationResult("Please enter an email!");
        }
        // MIGHT add regex here to determine if the email is in the proper format
        // This will connect us to our database since we are not in our Controller folder
        ProjectContext _context = (ProjectContext) validationContext.GetService(typeof(ProjectContext));
        if (_context.Users.Any(u => u.Email.Equals(value.ToString())))
        {
            return new ValidationResult($"The email {value} is already registered.  Please use another one."); // Return error message
        }
        else
        {
            return ValidationResult.Success; // Validation is okay
        }
    }
}