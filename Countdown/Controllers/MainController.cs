using Microsoft.AspNetCore.Mvc; // This brings all the MVC features we need to this file
namespace PortfolioI.Controllers; // Be sure to use your own project's namespace here!  Think of it like a book, and inside the book will be our controllers.  Format: [ProjectNamespace].Controllers
public class MainController : Controller // Create our own controller, which inherits from the Controller class (from AspNetCore.Mvc)
{
    
    [HttpGet("")] // Index route
    public ViewResult Index()
    {
        ViewBag.StartTime = DateTime.Now; // Get current time
        ViewBag.EndTime = new DateTime(2024,6,1,13,0,0); // Set future time
        return View(); // Look for index.cshtml
    }
}

