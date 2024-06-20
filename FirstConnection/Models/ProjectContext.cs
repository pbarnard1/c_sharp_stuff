#pragma warning disable CS8618 // Disable non-null warnings
using Microsoft.EntityFrameworkCore; // For DbContext and more
namespace FirstConnection.Models;
// The context file is responsible for translating the queries for us when working between the models and the database!
public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions options) : base(options) {} // Constructor that builds our context
    // You will have one attribute for each model here.
    // It will be of the form:
    // public DbSet<ModelName> TableNameAsPlural { get; set; }
    public DbSet<Pet> Pets { get; set; }
}