#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace LoginAndRegistration.Models; // Replace this with your project name!!

public class LoginUser
{
    [Required(ErrorMessage = "Please enter an email!")]
    [EmailAddress]
    public string LoginEmail { get; set; }
    [Required(ErrorMessage = "Please enter a password!")]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; }
}