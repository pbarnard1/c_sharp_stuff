var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // Dependency injection used to add services to our controllers
var app = builder.Build();

// Added so we can use MVC completely - must be AFTER the build method is called
app.UseStaticFiles(); // Will search for the "wwwroot" folder for styling
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapGet("/", () => "Hello World!");

app.Run(); // Run the app at last