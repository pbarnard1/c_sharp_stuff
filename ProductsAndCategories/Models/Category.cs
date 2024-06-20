#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace ProductsAndCategories.Models;

public class Category
{
    [Key]
    public int CategoryId {get; set;}
    [Required(ErrorMessage = "Please enter a name for this category!")]
    public string Name {get; set;}
    // Navigation property - notice we're connecting to the middle table!
    public List<ProductCategoryConnector> Connections {get; set;} = new List<ProductCategoryConnector>();
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding to the DB
}