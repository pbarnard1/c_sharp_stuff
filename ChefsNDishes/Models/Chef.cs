#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace ChefsNDishes.Models; // Replace this with your project name!!

public class Chef
{
    [Key]
    public int ChefId {get; set;}
    [Required(ErrorMessage = "Please enter a first name!")]
    public string FirstName {get; set;}
    [Required(ErrorMessage = "Please enter a last name!")]
    public string LastName {get; set;}
    [Required(ErrorMessage = "Please enter the chef's birth date!")]
    [EighteenOrOlder] // Custom validator attribute
    public DateOnly? DateOfBirth {get; set;} // Need the "?" for the required annotation to work
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Chef to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Chef to the DB
    // Navigation property for the EF framework to keep track of stuff we're linking together, for convenience
    // This will NOT be saved to the database, by default
    public List<Dish> AllDishes {get; set;} = new List<Dish>(); // Note we must create an instance of this object!!
}