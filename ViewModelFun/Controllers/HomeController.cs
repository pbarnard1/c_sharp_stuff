using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

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
        string myMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Laoreet sit amet cursus sit amet. Iaculis nunc sed augue lacus viverra vitae congue eu. Ipsum nunc aliquet bibendum enim facilisis gravida. Tempus imperdiet nulla malesuada pellentesque elit eget gravida. Sed adipiscing diam donec adipiscing tristique. Eget nullam non nisi est sit amet facilisis magna etiam. Id interdum velit laoreet id. Amet purus gravida quis blandit turpis cursus in. Tempor orci eu lobortis elementum nibh.";

        return View("Index", myMessage); // Pass in a single ViewModel attribute - in this case, a string
    }

    [HttpGet("numbers")]
    public IActionResult Numbers()
    {
        List<int> myValues = new List<int> {10, 15, 5, 22, -5, 8};
        return View("Numbers",myValues);
    }
    [HttpGet("user")]
    public IActionResult UserPage()
    {
        string name = "John Doe";
        return View("user",name);
    }
    [HttpGet("users")]
    public IActionResult Users()
    {
        List<string> allUsers = new List<string> {"Adrian","Jonathan","Melissa","Mel","Reena","Peter"};
        return View("Users",allUsers);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
