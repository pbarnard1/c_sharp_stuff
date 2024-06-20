// This using statement is for the ServerVersion and more
using Microsoft.EntityFrameworkCore;
// You will need access to your models for your context file
using TheWall.Models; // Change your Project Name here!

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Create a variable to hold your connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// All your builder.services go here
// And we will add one more service - make sure the context below matches your Context file name!
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// AddHttpContextAccessor gives our views direct access to session
// Add these two lines before calling the builder.Build() method
// They fit nicely right after AddControllerWithViews() 
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// add this line before calling the app.MapControllerRoute() method
// It fits nicely with other Use statements like app.UseStaticFiles();
app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
