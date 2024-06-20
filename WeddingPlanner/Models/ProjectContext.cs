#pragma warning disable CS8618 // Disable non-null warnings
using Microsoft.EntityFrameworkCore; // For DbContext and more
namespace WeddingPlanner.Models; // change your project name here!!
// The context file is responsible for translating the queries for us when working between the models and the database!
public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions options) : base(options) {} // Constructor that builds our context
    // You will have one attribute for each model here.
    // It will be of the form:
    // public DbSet<ModelName> TableNameAsPlural { get; set; } // By convention, the table name is plural
    public DbSet<User> Users { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Wedding> Weddings { get; set; }
}