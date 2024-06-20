using System.ComponentModel.DataAnnotations;
using System.Text; // For our annotations
namespace FormSubmission.Models;

public class Registration
{

    [Required]
    [MinLength(2, ErrorMessage = "The name must be at least 2 characters long!")]
    public string Name {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    [EmailAddress]
    public string Email {get;set;} = null!;
    
    [PastDate] // Custom validation
    public DateOnly? DateOfBirth {get;set;}

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long!")]
    public string Password {get;set;} = null!;
    [Required]
    [OddNumber] // Custom validation
    public int? FavoriteOddNumber {get; set;}

    [Required(ErrorMessage = "Please enter a prime number!")]
    [Range(2,System.Int32.MaxValue,ErrorMessage = "Make sure the value is at least 2.")]
    [PrimeNumber] // Custom validation
    public int? FavoritePrimeNumber {get; set;}
}