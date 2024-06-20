#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace TheWall.Models; 

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    [Required(ErrorMessage = "Please enter some text for your comment!")]
    public string Text { get; set; }
    public int UserId { get; set; } // User who created the comment

    public User? Creator { get; set; } // Navigation property
    public int MessageId { get; set; } // Parent message
    public Message? Message { get; set; } // Navigation property
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Generate these timestamps when adding for the first time
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}