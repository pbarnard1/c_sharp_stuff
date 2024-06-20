using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class GuestController : Controller
{
    private readonly ILogger<GuestController> _logger;
    private ProjectContext _context; // So we can work with our database accordingly
    public GuestController(ILogger<GuestController> logger, ProjectContext myContext)
    {
        _logger = logger;
        _context = myContext;
    }
    [SessionCheck]
    [HttpPost("guests/add")]
    public IActionResult InviteToWedding(int weddingId)
    {
        // Create new guest with the user and wedding linked accordingly
        Guest newGuest = new Guest();
        newGuest.UserId = (int) HttpContext.Session.GetInt32("UserId");
        newGuest.WeddingId = weddingId;
        _context.Guests.Add(newGuest);
        _context.SaveChanges();
        return RedirectToAction("AllWeddings","Wedding");
    }
    [SessionCheck]
    [HttpPost("guests/remove")]
    public IActionResult RemoveFromWedding(int weddingId)
    {
        // Grab invitation, if we can (note the ?, as this is nullable)
        Guest? itemToRemove = _context.Guests.SingleOrDefault(
            g => g.UserId == HttpContext.Session.GetInt32("UserId") && g.WeddingId == weddingId);
        if (itemToRemove == null)
        {
            return RedirectToAction("AllWeddings","Wedding");
        }
        _context.Guests.Remove(itemToRemove);
        _context.SaveChanges();
        return RedirectToAction("AllWeddings","Wedding");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
