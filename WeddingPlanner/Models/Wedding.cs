#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace WeddingPlanner.Models; 

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    [Required(ErrorMessage = "Please enter the first person getting married!")]
    public string MarriedOne { get; set; }
    [Required(ErrorMessage = "Please enter the second person getting married!")]
    public string MarriedTwo { get; set; }
    [Required(ErrorMessage = "Please make sure you enter a wedding date.")]
    [FutureDate] // Custom validation to ensure the date is in the future
    public DateOnly? WeddingDate {get; set;} // The "?" is so the Required annotation works
    [Required(ErrorMessage = "Please enter the address for this wedding!")]
    public string Address { get; set; }
    // For linking to the creator of the event - a one-to-many relationship
    // NOTE: if the foreign key is optional, include a "?" here to make it nullable
    public int UserId { get; set; }
    // Navigation property to track which User planned this Wedding
    // It is VERY important to include the ? on the datatype or this won't work!
    public User? Planner { get; set; }
    // Navigation property - notice we're connecting to the middle table!
    public List<Guest> Guests {get; set;} = new List<Guest>();
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Generate these timestamps when adding for the first time
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}