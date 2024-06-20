using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private ProjectContext _context; // So we can interact with our database via dependency injection
    public DishController(ILogger<DishController> logger, ProjectContext myContext)
    {
        _logger = logger;
        _context = myContext;
    }
    [HttpGet("dishes")]
    public IActionResult Dishes() // Will display all our dishes
    {
        List<Dish> allDishes = _context.Dishes.Include(d => d.Creator).ToList(); // Grab dishes - and info about who created each one
        return View("Dishes", allDishes);
    }
    [HttpGet("dishes/new")]
    public IActionResult NewDishPage()
    {
        List<Chef> allChefs = _context.Chefs.ToList(); // Grab all chefs so we can link a dish to a chef in the form
        ViewBag.AllChefs = allChefs;
        return View("NewDish");
    }
    [HttpPost("dishes/create")] // Will add a dish to the DB, or render validation errors
    public IActionResult AddDish(Dish newDish)
    {
        Console.WriteLine($"Name: {newDish.Name}");
        Console.WriteLine($"Calories: {newDish.Calories}");
        Console.WriteLine($"Tastiness: {newDish.Tastiness}");
        Console.WriteLine($"Chef's ID: {newDish.ChefId}");
        if (!ModelState.IsValid)
        {
            // IMPORTANT: Anything you pass in via ViewBag must be passed in again!!!!
            List<Chef> allChefs = _context.Chefs.ToList(); // Grab all chefs so we can link a dish to a chef in the form
            ViewBag.AllChefs = allChefs;
            return View("NewDish");
        }
        // Here, validations are okay, so save the dish, then redirect
        _context.Dishes.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Dishes");
    }
    [HttpGet("dishes/{id}/edit")]
    public IActionResult EditDishPage(int id)
    {
        Dish? thisDish = _context.Dishes.FirstOrDefault(d => d.DishId == id); // Grab the one dish with the given ID (or null)
        if (thisDish == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Dishes");
        }
        List<Chef> allChefs = _context.Chefs.ToList(); // Grab all chefs so we can link a dish to a chef in the form
        ViewBag.AllChefs = allChefs;
        return View("EditDish", thisDish);
    }
    [HttpPost("dishes/{id}/update")]
    public IActionResult UpdateDish(Dish updatedDish, int id)
    {
        Dish? originalDish = _context.Dishes.FirstOrDefault(d => d.DishId == id); // Grab the one dish with the given ID (or null)
        if (originalDish == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Dishes");
        }
        if (ModelState.IsValid) // Validations OK
        {
            // Save each attribute one at a time
            originalDish.Name = updatedDish.Name;
            originalDish.Calories = updatedDish.Calories;
            originalDish.Tastiness = updatedDish.Tastiness;
            originalDish.ChefId = updatedDish.ChefId;
            originalDish.UpdatedAt = DateTime.Now; // Save updated timestamp
            _context.SaveChanges(); // Save changes in DB (with the ID and CreatedAt timestamp remaining the same)
            return RedirectToAction("Dishes");
        }
        else // Validations fail
        {
            // IMPORTANT: Anything you pass in via ViewBag must be passed in again!!!!
            List<Chef> allChefs = _context.Chefs.ToList(); // Grab all chefs so we can link a dish to a chef in the form
            ViewBag.AllChefs = allChefs;
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
            return RedirectToAction("Dishes");
        }
        _context.Dishes.Remove(thisDish);
        _context.SaveChanges(); // Save updates to database, with the dish now removed
        return RedirectToAction("Dishes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}