#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace Crudelicious.Models; // Replace this with your project name!!

public class Dish
{
    [Key]
    public int DishId {get; set;}
    [Required]
    public string Chef {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    [Range(1,100000,ErrorMessage = "You must have at least one calorie!")]
    public int? Calories {get; set;} // Need the "?" to suppress the message "The value '' is invalid." for this int field
    [Required]
    [Range(1,5,ErrorMessage = "Please enter a value from 1 through 5 for tastiness.")]
    public int? Tastiness {get; set;}
    [Required]
    public string Description {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Dish to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Dish to the DB
}