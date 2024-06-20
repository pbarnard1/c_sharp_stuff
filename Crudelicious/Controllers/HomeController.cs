using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

namespace Crudelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ProjectContext _context; // Don't forget

    public HomeController(ILogger<HomeController> logger, ProjectContext newContext) // don't forget to inject context!
    {
        _logger = logger;
        _context = newContext; // Don't forget!
    }

    [HttpGet()]
    public IActionResult Index()
    {
        List<Dish> allDishes = _context.Dishes.ToList(); // Grab all dishes from the database
        return View("Index",allDishes); // Pass in via ViewModel
    }
    [HttpGet("dishes/new")]
    public ViewResult NewDishPage()
    {
        return View("AddDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        Console.WriteLine($"Chef: {newDish.Chef}");
        Console.WriteLine($"Name: {newDish.Name}");
        Console.WriteLine($"Calories: {newDish.Calories}");
        Console.WriteLine($"Tastiness: {newDish.Tastiness}");
        Console.WriteLine($"Description: {newDish.Description}");
        if (ModelState.IsValid)
        {
            _context.Dishes.Add(newDish); // Add this dish to the list
            _context.SaveChanges(); // Save changes to DB - with the ID and timestamps automatically generated
            return RedirectToAction("Index");
        }
        else // Validation errors
        {
            return View("AddDish");
        }
    }

    [HttpGet("dishes/{id}")]
    public IActionResult ViewDish(int id)
    {
        Dish? thisDish = _context.Dishes.FirstOrDefault(d => d.DishId == id); // Grab the one dish with the given ID (or null)
        if (thisDish == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        return View("ViewDish", thisDish);
    }
    [HttpGet("dishes/{id}/edit")]
    public IActionResult EditDishPage(int id)
    {
        Dish? thisDish = _context.Dishes.FirstOrDefault(d => d.DishId == id); // Grab the one dish with the given ID (or null)
        if (thisDish == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        return View("EditDish", thisDish);
    }
    [HttpPost("dishes/{id}/update")]
    public IActionResult UpdateDish(int id, Dish updatedDish)
    {
        Dish? originalDish = _context.Dishes.FirstOrDefault(d => d.DishId == id); // Grab the one dish with the given ID (or null)
        if (originalDish == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        if (ModelState.IsValid) // Validations OK
        {
            // Save each attribute one at a time
            originalDish.Chef = updatedDish.Chef;
            originalDish.Name = updatedDish.Name;
            originalDish.Calories = updatedDish.Calories;
            originalDish.Tastiness = updatedDish.Tastiness;
            originalDish.Description = updatedDish.Description;
            originalDish.UpdatedAt = DateTime.Now; // Save updated timestamp
            _context.SaveChanges(); // Save changes in DB (with the ID and CreatedAt timestamp remaining the same)
            return RedirectToAction("ViewDish", new {id = originalDish.DishId});
        }
        else // Validations fail
        {
            return View("EditDish",originalDish); // Pass back the ORIGINAL dish's info so that we can pass the ID along
        }
    }

    [HttpPost("dishes/{id}/destroy")]
    public IActionResult DeleteDish(int id)
    {
        // Note that we use SingleOrDefault here, as an exception will be thrown if there's more than one item found;
        // using FirstOrDefault will return the first item found, even if multiple instances are found
        // In reality, we'd probably want a try-catch block here
        Dish? thisDish = _context.Dishes.SingleOrDefault(d => d.DishId == id); // Grab the one dish with the given ID (or null)
        if (thisDish == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        _context.Dishes.Remove(thisDish);
        _context.SaveChanges(); // Save updates to database, with the dish now removed
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
