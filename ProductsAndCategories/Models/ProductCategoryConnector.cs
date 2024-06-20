#pragma warning disable CS8618 // Disable null warnings
using System.ComponentModel.DataAnnotations; // For our annotations
namespace ProductsAndCategories.Models;
public class ProductCategoryConnector // Effectively our middle model that connects Products and Categories
{
    [Key]
    public int ProductCategoryConnectorId {get; set;}
    // Our foreign keys
    public int ProductId {get; set;}
    public int CategoryId {get; set;}
    // Navigation properties to connect to other two tables - note that we must include the "?"
    public Product? Product {get; set;}
    public Category? Category {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Assign default value when adding to the DB
    public DateTime UpdatedAt { get; set; } = DateTime.Now; // Assign default value when adding to the DB
}