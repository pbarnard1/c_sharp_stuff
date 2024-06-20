using Microsoft.AspNetCore.Mvc; // This brings all the MVC features we need to this file
namespace RazorFun.Controllers; // Be sure to use your own project's namespace here!  Think of it like a book, and inside the book will be our controllers.  Format: [ProjectNamespace].Controllers
public class MainController : Controller // Create our own controller, which inherits from the Controller class (from AspNetCore.Mvc)
{
    
    [HttpGet("")] // Root route
    public ViewResult Index()
    {
        return View(); // Render index.cshtml inside the Main subfolder within the Views folder
    }
}

