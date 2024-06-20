using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private ProjectContext _context; // So we can work with our database accordingly

    public WeddingController(ILogger<WeddingController> logger, ProjectContext myContext)
    {
        _logger = logger;
        _context = myContext;
    }
    /* Routes for weddings go here - notice each route has a session check */
    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult AllWeddings()
    {
        List<Wedding> weddingList = _context.Weddings
            .Include(w => w.Guests)
            .Include(w => w.Planner).ToList(); // Need BOTH includes here
        return View(weddingList);
    }

    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult NewWeddingPage()
    {
        return View("NewWedding");
    }

    [SessionCheck]
    [HttpPost("weddings/create")]
    public IActionResult AddWedding(Wedding newWedding)
    {
        Console.WriteLine($"First person is: {newWedding.MarriedOne}");
        Console.WriteLine($"Second person is: {newWedding.MarriedTwo}");
        Console.WriteLine($"Wedding date is: {newWedding.WeddingDate}");
        Console.WriteLine($"Address is: {newWedding.Address}");
        // Link user here (OR as a hidden input in the form)
        if (!ModelState.IsValid)
        {
            return View("NewWedding");
        }
        // Grab logged in user by ID, then link to this wedding
        // (MUST be done before adding and saving; alternately you can use a hidden input in the form itself)
        newWedding.UserId = (int) HttpContext.Session.GetInt32("UserId");
        _context.Weddings.Add(newWedding);
        _context.SaveChanges();
        return Redirect($"/weddings/{newWedding.WeddingId}"); // Note that the wedding ID will be generated AFTER saving the changes to the DB, so this is okay
    }

    [SessionCheck]
    [HttpGet("weddings/{id}")]
    public IActionResult ViewWedding(int id)
    {
        Wedding? thisWedding = _context.Weddings
            .Include(w => w.Guests).ThenInclude(guest => guest.User)
            .Include(w => w.Planner) // MUST include this line as well so we can link the one who added the wedding!!
            .FirstOrDefault(w => w.WeddingId == id); // Grab the one wedding WITH the guests included
        if (thisWedding == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the all weddings page
        {
            return RedirectToAction("AllWeddings");
        }
        return View("ViewWedding",thisWedding);
    }

    [SessionCheck]
    [HttpPost("weddings/{id}/destroy")]
    public IActionResult DeleteWedding(int id)
    {
        // Note that we use SingleOrDefault here, as an exception will be thrown if there's more than one item found;
        // using FirstOrDefault will return the first item found, even if multiple instances are found
        // In reality, we'd probably want a try-catch block here
        Wedding? thisWedding = _context.Weddings.SingleOrDefault(d => d.WeddingId == id); // Grab the one wedding with the given ID (or null)
        if (thisWedding == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("AllWeddings");
        }
        /*
        IMPORTANT NOTE: If you leave a foreign key as nullable, i.e. "int?" instead of "int", you have to delete linked items
        yourself.  But if you leave the foreign key as not nullable, i.e. "int", then the linked items will be removed for you
        (cascade on delete).
        
        */
        _context.Weddings.Remove(thisWedding); // Now remove the wedding
        _context.SaveChanges(); // Save updates to database, with the wedding now removed
        return RedirectToAction("AllWeddings");
    }
}