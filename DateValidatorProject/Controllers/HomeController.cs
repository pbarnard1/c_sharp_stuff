using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidatorProject.Models;

namespace DateValidatorProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private List<string> _days = new List<string>() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

        public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult ProcessForm(Survey newSurvey)
    {
        // Debugging
        Console.WriteLine($"Name is: {newSurvey.Name}");
        Console.WriteLine($"Location is: {newSurvey.Location}");
        Console.WriteLine($"Language is: {newSurvey.Language}");
        Console.WriteLine($"Comment is: {newSurvey.Comment}");
        Console.WriteLine($"Number is: {newSurvey.Number}");
        Console.WriteLine($"Date is: {newSurvey.Date}");
        Console.WriteLine($"Meal is: {newSurvey.Meal}");
        Console.WriteLine($"Comment is {(newSurvey.Comment == null ? "not filled out" : "filled out")}");
        Console.WriteLine($"Number is {(newSurvey.Number == null ? "not filled out" : "filled out")}");
        // Console.WriteLine(newSurvey.Days);
        for(int k = 0; k < _days.Count; k++)
        {
            string msg = newSurvey.Days[k] ? $"{_days[k]} was selected" : $"{_days[k]} was not selected";
            Console.WriteLine(msg);
        }
        if (ModelState.IsValid) // All validations are okay
        {
            return RedirectToAction("Results", newSurvey);
        }
        else // Validation errors, so re-render (OK as the submission is NOT successful, so no double-submitting)
        {
            return View("Index");
        }
    }
    [HttpGet("results")]
    public IActionResult Results(Survey surveyResults)
    {
        return View("Results", surveyResults);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
