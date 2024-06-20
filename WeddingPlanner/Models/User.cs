#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
using System.ComponentModel.DataAnnotations.Schema; // For our NotMapped annotation specifically
namespace WeddingPlanner.Models; 

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage = "Please enter a first name!")]
    [MinLength(2,ErrorMessage = "First name must be at least 2 characters long!")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Please enter a last name!")]
    [MinLength(2,ErrorMessage = "Last name must be at least 2 characters long!")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Please enter your email!")]
    [EmailAddress] // To make this an input type="email"
    [UniqueEmail] // Our custom unique email validation
    public string Email { get; set; }
    [Required(ErrorMessage = "Please enter a password!")]
    [DataType(DataType.Password)] // To hide the password!
    [MinLength(8, ErrorMessage = "Please enter a password that is at least 8 characters long!")]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Generate these timestamps when adding for the first time
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Please confirm your password!")]
    [NotMapped] // This will NOT be saved in the database
    [DataType(DataType.Password)] // To hide the password!
    [Compare("Password", ErrorMessage = "These passwords do not agree.")] // Allows us to compare this field to another field (property) in our model
    public string ConfirmedPassword { get; set; }
    // Navigation property for which weddings we CREATED (one-to-many)
    public List<Wedding> CreatedWeddings {get; set;} = new List<Wedding>();
    // Navigation property for which weddings we're attending (many-to-many) - notice we're connecting to the middle table!
    public List<Guest> AttendingEvents {get; set;} = new List<Guest>();
}