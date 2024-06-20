using Microsoft.AspNetCore.Mvc; // This brings all the MVC features we need to this file
namespace PortfolioI.Controllers; // Be sure to use your own project's namespace here!  Think of it like a book, and inside the book will be our controllers.  Format: [ProjectNamespace].Controllers
public class MainController : Controller // Create our own controller, which inherits from the Controller class (from AspNetCore.Mvc)
{
    
    [HttpGet("")] // Index route
    public ViewResult Index()
    {
        return View(); // Look for index.cshtml
    }
    [HttpGet("projects")] // Projects route
    public ViewResult Projects()
    {
        return View(); // Look for projects.cshtml
    }

    [HttpGet("contact")] // Contact route
    public ViewResult Contact()
    {
        return View(); // Look for contact.cshtml
    }
}

