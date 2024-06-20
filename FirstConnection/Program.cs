// Add this using statement for the ServerVersion and more
using Microsoft.EntityFrameworkCore;
// You will need access to your models for your context file
using FirstConnection.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Create a variable to hold your connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// And we will add one more service
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
