using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers;

public class CommentController : Controller
{
    private readonly ILogger<CommentController> _logger;
    // NEW: Add a private variable of type ProjectContext (or whatever you named your context file)
    private ProjectContext _context;
    // Here we can "inject" our context service into the constructor
    // The "logger" was something that was already in our code, we're just adding around it
    public CommentController(ILogger<CommentController> logger, ProjectContext context) // NEW: Context injected in here
    {
        _logger = logger;
        // When our CommentController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context; // NEW LINE
    }
    [SessionCheck]
    [HttpPost("comments/create")]
    public IActionResult CreateComment(Comment newComment)
    {

        Console.WriteLine($"Comment text: ${newComment.Text}");
        if (!ModelState.IsValid) // Validations fail
        {
            MessagePostViewModel allModels = new MessagePostViewModel
            {
                AllMessages = _context.Messages.Include(m => m.Creator)
                    .Include(m => m.Comments)
                    .ThenInclude(c => c.Creator).ToList() // Grab the messages, along with comments - plus who wrote each of them
                // Don't need to add Message and Comment models here, as those will be empty and used by the forms
            };
            return View("AllMessages", allModels);
        }
        newComment.UserId = (int) HttpContext.Session.GetInt32("UserId"); // Grab user id and link to message
        _context.Comments.Add(newComment);
        _context.SaveChanges();
        return RedirectToAction("AllMessages","Message");
    }
    [SessionCheck]
    [HttpPost("comments/{id}/destroy")]
    public IActionResult DeleteComment(int id)
    {

        // Note that we use SingleOrDefault here, as an exception will be thrown if there's more than one item found;
        // using FirstOrDefault will return the first item found, even if multiple instances are found
        // In reality, we'd probably want a try-catch block here
        Comment? thisComment = _context.Comments.SingleOrDefault(d => d.CommentId == id); // Grab the one comment with the given ID (or null)
        if (thisComment == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("AllMessages","Message");
        }
        /*
        IMPORTANT NOTE: If you leave a foreign key as nullable, i.e. "int?" instead of "int", you have to delete linked items
        yourself.  But if you leave the foreign key as not nullable, i.e. "int", then the linked items will be removed for you
        (cascade on delete).
        
        */
        _context.Comments.Remove(thisComment); // Now remove the comment
        _context.SaveChanges(); // Save updates to database, with the comment now removed
        return RedirectToAction("AllMessages","Message");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}