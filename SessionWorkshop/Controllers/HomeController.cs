using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("count",0); // (Re)set counter to 0
        return View();
    }
    [HttpGet("dashboard")]
    public IActionResult CounterPage()
    {
        if (HttpContext.Session.GetString("name") == null)
        {
            Console.WriteLine("Not logged in, so going back to index page");
            return RedirectToAction("Index");
        }
        return View("Dashboard");
    }
    [HttpPost("process")]
    public IActionResult Process(string name)
    {
        HttpContext.Session.SetString("name",name); // Save name from form in session
        return RedirectToAction("CounterPage");
    }
    [HttpPost("count")]
    public RedirectToActionResult Change(string option)
    {
        int? currentValue = HttpContext.Session.GetInt32("count");
        if (currentValue != null) // Process, then save updated value in session, if it's not null
        {
            switch(option)
            {
                case "addOne":
                    currentValue++;
                    break;
                case "subtractOne":
                    currentValue--;
                    break;
                case "double":
                    currentValue *= 2;
                    break;
                case "addRandom":
                    Random myRNG = new Random();
                    int randomVal = myRNG.Next(1,11); // Pick from one to 10
                    currentValue += randomVal;
                    break;
                default: // Invalid option
                    break;
            }
            HttpContext.Session.SetInt32("count", (int) currentValue);
        }
        return RedirectToAction("CounterPage");
    }
    [HttpPost("logout")]
    public RedirectToActionResult Logout()
    {
        HttpContext.Session.Remove("name"); // Or you can use .Clear()
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
