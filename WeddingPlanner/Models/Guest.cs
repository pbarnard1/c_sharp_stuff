#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace WeddingPlanner.Models; 

public class Guest // The middle table (model) connecting Users and Weddings
{
    [Key]
    public int GuestId { get; set; }
    // Our foreign keys
    public int UserId {get; set;}
    public int WeddingId {get; set;}
    // Navigation properties to connect to other two tables - note that we must include the "?"
    public User? User {get; set;}
    public Wedding? Wedding {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now; // Generate these timestamps when adding for the first time
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}