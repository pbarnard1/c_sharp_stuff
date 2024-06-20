#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace ChefsNDishes.Models; // Replace this with your project name!!

public class Dish
{
    [Key]
    public int DishId {get; set;}
    [Required(ErrorMessage = "Please enter a name for the dish!")]
    public string Name {get; set;}
    [Required(ErrorMessage = "Please enter a numeric value for the calories!")]
    [Range(1,System.Int32.MaxValue,ErrorMessage = "The number of calories must be positive.")]
    public int? Calories {get; set;} // Note the "int?" for the Required error message to show up
    [Required(ErrorMessage = "Please select a tastiness value!")]
    [Range(1,5,ErrorMessage = "The tastiness value must be a value from 1 through 5.")]
    public int? Tastiness {get; set;}
    // This WILL save to the database (our foreign key) - note that it's nullable (not needed here; just for demo purposes)
    public int? ChefId {get; set;}
    // Navigation property for the EF framework to keep track of stuff we're linking together, for convenience
    // This will NOT be saved to the database, by default
    // NOTE: don't forget the "?" below, as it's possible for it to be null!
    public Chef? Creator {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Chef to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Chef to the DB
}