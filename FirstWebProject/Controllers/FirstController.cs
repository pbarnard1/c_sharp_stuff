using Microsoft.AspNetCore.Mvc; // This brings all the MVC features we need to this file
namespace FirstWebProject.Controllers; // Be sure to use your own project's namespace here!  Think of it like a book, and inside the book will be our controllers.  Format: [ProjectNamespace].Controllers
public class FirstController : Controller // Create our own controller, which inherits from the Controller class (from AspNetCore.Mvc)
{
    // NOTE: If you want multiple HTTP verbs, use AcceptVerbs and pass in as many HTTP request verbs as you want: [AcceptVerbs("GET","POST")]
    [HttpGet] // HttpMethodAttribute: Http request method(s) go here - if none specified, then it's a GET request by default
    [Route("")] // RouteAttribute: This is our route name - "" means "localhost:5XXX/", "parks/10" means "localhost:5XXX/parks/10", etc.  So do NOT include the leading "/"!
    public string Index()
    {
        return "Hello World from HelloController!";
    }
    [HttpGet("start")] // Faster way to define a route: [HttpMethodAttribute("routeNameGoesHere")]
    public string Start()
    {
        return "Starting now!";
    }

    [HttpGet("{color}/{number:int?}")] // Parameters in routes - including optional values
    public string ColorCount(string color, int number = 10)
    {
        return $"This is the color {color} with a value of {number}.";
    }
    [HttpGet("test")] // Parameters in routes - including optional values
    public ViewResult ViewTest()
    {
        // WARNING: Make sure you have a subfolder in the Views folder that matches the name of this Controller, 
        // without the word "Controller" included!  For example, if you have a controller named ParkController.cs, make sure
        // you have a subfolder named "Park" in your Views folder!!
        return View("Hello"); // NOTE: if you type View() with no values passed in, it will search for a file that matches the name of the method - in this case, ViewTest, so viewTest.cshtml.
    }

    [HttpGet("data")]
    public ViewResult DataTest()
    {
        // Here we use a ViewBag to hold basic (primitive) info to send to the front end
        ViewBag.Age = 40;
        ViewBag.Name = "Jane";
        return View(); // Will return DataTest.cshtml
    }
}

