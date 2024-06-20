#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace FirstConnection.Models;

public class Pet
{
    [Key]
    public int PetId { get; set; } // Naming convention: ModelNameId
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }
    public bool HasFur { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Pet to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding a Pet to the DB
}