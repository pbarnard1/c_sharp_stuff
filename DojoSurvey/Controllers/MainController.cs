using System.ComponentModel;
using Microsoft.AspNetCore.Mvc; // This brings all the MVC features we need to this file
namespace DojoSurvey.Controllers; // Be sure to use your own project's namespace here!  Think of it like a book, and inside the book will be our controllers.  Format: [ProjectNamespace].Controllers
public class MainController : Controller // Create our own controller, which inherits from the Controller class (from AspNetCore.Mvc)
{
    
    [HttpGet("")] // Index route
    public ViewResult Index()
    {
        return View(); // Look for index.cshtml
    }
    [HttpPost("process")] // Route to process the form
    public RedirectToActionResult HandleForm(string name, string location, string language, 
        DateOnly date, string[] days, string comment = "No comment", int number = 0, String meal = "No preference") // Notice the RedirectToActionResult and the default values
    {
        // Console.WriteLine(date.CompareTo(DateTime.Now));
        Console.WriteLine($"Name is: {name}");
        Console.WriteLine($"Location is: {location}");
        Console.WriteLine($"Language is: {language}");
        Console.WriteLine($"Comment is: {comment}");
        Console.WriteLine($"Number is: {number}");
        Console.WriteLine($"Date is: {date}");
        Console.WriteLine($"Meal is: {meal}");
        if (days.Length == 0)
        {
            Console.WriteLine("No days selected");
        }
        foreach(string day in days)
        {
            Console.WriteLine($"{day} was selected");
        }
        return RedirectToAction("Results", new {name = name, location = location, language = language,
            date = date, days = days, comment = comment, number = number, meal = meal}); // Sent to route attached to Results action (method)
    }
    // Alternate approach: use Redirect instead, and then return as a string with parameters attached

    [HttpGet("results")] // Results route
    public ViewResult Results(string name, string location, string language, 
        DateOnly date, string[] days, string comment, int number, String meal)
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Date = date;
        ViewBag.Days = days;
        ViewBag.Comment = comment;
        ViewBag.Number = number;
        ViewBag.Meal = meal;
        return View(); // Look for results.cshtml
    }

}

