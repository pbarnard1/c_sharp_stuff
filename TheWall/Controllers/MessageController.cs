using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers;

public class MessageController : Controller
{
    private readonly ILogger<MessageController> _logger;
    // NEW: Add a private variable of type ProjectContext (or whatever you named your context file)
    private ProjectContext _context;
    // Here we can "inject" our context service into the constructor
    // The "logger" was something that was already in our code, we're just adding around it
    public MessageController(ILogger<MessageController> logger, ProjectContext context) // NEW: Context injected in here
    {
        _logger = logger;
        // When our MessageController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context; // NEW LINE
    }
    [SessionCheck]
    [HttpGet("messages")]
    public IActionResult AllMessages()
    {
        MessagePostViewModel allModels = new MessagePostViewModel
        {
            AllMessages = GetAllMessages()
            // Don't need to add Message and Comment models here, as those will be empty and used by the forms
        };
        return View("AllMessages", allModels);
    }
    [SessionCheck]
    [HttpPost("messages/create")]
    public IActionResult CreateMessage(Message newMessage)
    {
        Console.WriteLine($"Message text: ${newMessage.Text}");
        if (!ModelState.IsValid) // Validations fail
        {
            MessagePostViewModel allModels = new MessagePostViewModel
            {
                AllMessages = GetAllMessages()
                // Don't need to add Message and Comment models here, as those will be empty and used by the forms
            };
            return View("AllMessages", allModels);
        }
        newMessage.UserId = (int) HttpContext.Session.GetInt32("UserId"); // Grab user id and link to message
        _context.Messages.Add(newMessage);
        _context.SaveChanges();
        return RedirectToAction("AllMessages");
    }
    [SessionCheck]
    [HttpPost("messages/{id}/destroy")]
    public IActionResult DeleteMessage(int id)
    {
        // Note that we use SingleOrDefault here, as an exception will be thrown if there's more than one item found;
        // using FirstOrDefault will return the first item found, even if multiple instances are found
        // In reality, we'd probably want a try-catch block here
        Message? thisMessage = _context.Messages.SingleOrDefault(d => d.MessageId == id); // Grab the one message with the given ID (or null)
        if (thisMessage == null) // In reality, we'd probably serve a 404 error instead, but here, we send back to the home page
        {
            return RedirectToAction("AllMessages");
        }
        /*
        IMPORTANT NOTE: If you leave a foreign key as nullable, i.e. "int?" instead of "int", you have to delete linked items
        yourself.  But if you leave the foreign key as not nullable, i.e. "int", then the linked items will be removed for you
        (cascade on delete).
        
        */
        _context.Messages.Remove(thisMessage); // Now remove the message
        _context.SaveChanges(); // Save updates to database, with the message now removed
        return RedirectToAction("AllMessages");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<Message> GetAllMessages()
    {
        return _context.Messages.Include(m => m.Creator)
                .Include(m => m.Comments)
                .ThenInclude(c => c.Creator)
                .OrderByDescending(m => m.CreatedAt)
                .ToList(); // Grab the messages, along with comments - plus who wrote each of them, with the messages in descending order
    }
}