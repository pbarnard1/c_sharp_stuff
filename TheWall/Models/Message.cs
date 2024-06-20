#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace TheWall.Models; 

public class Message
{
    [Key]
    public int MessageId { get; set; }
    [Required(ErrorMessage = "Please enter some text for your message!")]
    public string Text { get; set; }
    public int UserId { get; set; } // User who created the message

    public User? Creator { get; set; } // Navigation property
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Generate these timestamps when adding for the first time
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Navigation property, as we have one message with many comments
    public List<Comment> Comments { get; set; } = new List<Comment>();
}