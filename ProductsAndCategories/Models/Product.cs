#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace ProductsAndCategories.Models;

public class Product
{
    [Key]
    public int ProductId {get; set;}
    [Required(ErrorMessage = "Please enter a name for this product!")]
    public string Name {get; set;}
    [Required(ErrorMessage = "Please enter a description for this product!")]
    public string Description {get; set;}
    [DataType(DataType.Currency)]
    [Required(ErrorMessage = "Please enter a price for this product!")]
    // Navigation property - notice we're connecting to the middle table!
    public List<ProductCategoryConnector> Connections {get; set;} = new List<ProductCategoryConnector>();
    public decimal? Price {get; set;} // decimal type used for money usually; note the "?" to make the Required message work
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding to the DB
}