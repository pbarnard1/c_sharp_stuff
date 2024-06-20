// Add this using statement for the ServerVersion and more
using Microsoft.EntityFrameworkCore;
// You will need access to your models for your context file
using LoginAndRegistration.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// For session
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

// Add these lines BEFORE the "var app = builder.Build();" line and AFTER the line where you define your builder!
// Create a variable to hold your connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// All your builder.services go here
// And we will add one more service - make sure the context below matches your Context file name!
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

app.UseSession(); // For session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
