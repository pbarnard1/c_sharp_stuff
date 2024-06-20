using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;
    private ProjectContext _context; // So we can interact with our database via dependency injection
    public ChefController(ILogger<ChefController> logger, ProjectContext myContext)
    {
        _logger = logger;
        _context = myContext;
    }
    [HttpGet("")]
    public IActionResult Index() // Will display all our chefs
    {
        List<Chef> allChefs = _context.Chefs.Include(c => c.AllDishes).ToList(); // Grab all chefs - including the dishes (so we can count them)
        return View("Index", allChefs);
    }
    [HttpGet("chefs/new")]
    public IActionResult NewChefPage()
    {
        return View("NewChef");
    }
    [HttpPost("chefs/create")] // Will add a chef to the DB, or render validation errors
    public IActionResult AddChef(Chef newChef)
    {
        Console.WriteLine($"First name: {newChef.FirstName}");
        Console.WriteLine($"Last name: {newChef.LastName}");
        Console.WriteLine($"Date of birth: {newChef.DateOfBirth}");
        if (!ModelState.IsValid) // Validation errors found
        {
            return View("NewChef");
        }
        // If we make it here, all validations are good
        // Now save to the database
        _context.Chefs.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet("chefs/{id}")]
    public IActionResult ViewChef(int id)
    {
        // Grab the one chef with the given ID (or null) - with the dishes included
        Chef? thisChef = _context.Chefs.Include(c => c.AllDishes).FirstOrDefault(c => c.ChefId == id);
        if (thisChef == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        return View("ViewChef", thisChef);
    }
    [HttpGet("chefs/{id}/edit")]
    public IActionResult EditChefPage(int id)
    {
        Chef? thisChef = _context.Chefs.FirstOrDefault(d => d.ChefId == id); // Grab the one chef with the given ID (or null)
        if (thisChef == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        return View("EditChef", thisChef);
    }
    [HttpPost("chefs/{id}/update")]
    public IActionResult UpdateChef(Chef updatedChef, int id)
    {
        Chef? originalChef = _context.Chefs.FirstOrDefault(d => d.ChefId == id); // Grab the one dish with the given ID (or null)
        if (originalChef == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        if (ModelState.IsValid) // Validations OK
        {
            // Save each attribute one at a time
            originalChef.FirstName = updatedChef.FirstName;
            originalChef.LastName = updatedChef.LastName;
            originalChef.DateOfBirth = updatedChef.DateOfBirth;
            originalChef.UpdatedAt = DateTime.Now; // Save updated timestamp
            _context.SaveChanges(); // Save changes in DB (with the ID and CreatedAt timestamp remaining the same)
            return RedirectToAction("Index");
        }
        else // Validations fail
        {
            return View("EditChef",originalChef); // Pass back the ORIGINAL chef's info so that we can pass the ID along
        }
    }
    [HttpPost("chefs/{id}/destroy")]
    public IActionResult DeleteChef(int id)
    {
        // Note that we use SingleOrDefault here, as an exception will be thrown if there's more than one item found;
        // using FirstOrDefault will return the first item found, even if multiple instances are found
        // In reality, we'd probably want a try-catch block here
        Chef? thisChef = _context.Chefs.SingleOrDefault(d => d.ChefId == id); // Grab the one chef with the given ID (or null)
        if (thisChef == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("Index");
        }
        /*
        IMPORTANT NOTE: If you leave a foreign key as nullable, i.e. "int?" instead of "int", you have to delete linked items
        yourself.  But if you leave the foreign key as not nullable, i.e. "int", then the linked items will be removed for you
        (cascade on delete).
        
        For this, I've left the foreign key as nullable, and thus I have to remove the dishes first BEFORE removing the chef.
        */
        List<Dish> allDishesByChef = _context.Dishes.Where(d => d.ChefId == id).ToList();
        foreach(Dish d in allDishesByChef) // Remove the dishes first
        {
            _context.Dishes.Remove(d);
        }
        _context.Chefs.Remove(thisChef); // Now remove the chef
        _context.SaveChanges(); // Save updates to database, with the chef now removed
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}