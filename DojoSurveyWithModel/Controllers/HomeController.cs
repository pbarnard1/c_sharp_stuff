using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;

namespace DojoSurveyWithModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

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
        // Console.WriteLine(newSurvey.Days);
        if (newSurvey.Days.Count == 0)
        {
            Console.WriteLine("No days selected");
        }
        foreach(string day in newSurvey.Days)
        {
            Console.WriteLine($"{day} was selected");
        }
        return RedirectToAction("Results", newSurvey);
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
