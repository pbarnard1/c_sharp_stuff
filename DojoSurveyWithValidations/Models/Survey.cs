using System.ComponentModel.DataAnnotations; // For our validations using the built-in Tag Helper library
namespace DojoSurveyWithValidations.Models;

public class Survey
{

    [Required]
    [MinLength(2, ErrorMessage = "The name must be at least 2 characters long!")]
    public string Name {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    [Required(ErrorMessage = "Please enter a location!")]
    public string Location {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    
    [Required]
    public string Language {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    
    [Required(ErrorMessage = "Please enter a number.")]
    [Range(0, System.Int32.MaxValue, ErrorMessage = "Please enter a valid non-negative whole number!")]
    public int? Number {get;set;} // Need the "?" here to trigger the Required validation
    [Required]
    public string Meal {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    // For now, no validators for the date - see the DateValidatorProject for more info
    public DateOnly? Date {get;set;}
    public List<Boolean> Days {get; set;} = new List<Boolean>() {false, false, false, false, false, false, false}; // With lists, you must instantiate an empty object like this!
    [MinLength(20, ErrorMessage = "Your message must be 20 or more characters long!")] // Notice that it's OKAY if we leave this box empty
    public string? Comment {get;set;}

}