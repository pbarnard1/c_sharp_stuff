using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

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
    public IActionResult ProcessForm(Registration newRegistration)
    {
        // Debugging
        Console.WriteLine($"Name is: {newRegistration.Name}");
        Console.WriteLine($"Email is: {newRegistration.Email}");
        Console.WriteLine($"Date of birth is: {newRegistration.DateOfBirth}");
        Console.WriteLine($"Password is: {newRegistration.Password}");
        Console.WriteLine($"Favorite odd number is: {newRegistration.FavoriteOddNumber}");
        Console.WriteLine($"Favorite prime number is: {newRegistration.FavoritePrimeNumber}");
        if (ModelState.IsValid) // All validations are okay
        {
            return RedirectToAction("Success");
        }
        else // Validation errors, so re-render (OK as the submission is NOT successful, so no double-submitting)
        {
            return View("Index");
        }
    }
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
