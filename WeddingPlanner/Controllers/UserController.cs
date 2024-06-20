using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity; // For hashing our passwords

namespace WeddingPlanner.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private ProjectContext _context; // So we can work with our database accordingly
    public UserController(ILogger<UserController> logger, ProjectContext myContext)
    {
        _logger = logger;
        _context = myContext;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        Console.WriteLine($"First name: {newUser.FirstName}");
        Console.WriteLine($"Last name: {newUser.LastName}");
        Console.WriteLine($"Email: {newUser.Email}");
        Console.WriteLine($"Password: {newUser.Password}");
        Console.WriteLine($"Confirmed password: {newUser.ConfirmedPassword}");
        if (!ModelState.IsValid) // Validations fail
        {
            return View("Index");
        }
        /* If we make it here, validations succeed */

        // Now hash the password!
        PasswordHasher<User> hasher = new PasswordHasher<User>();
        newUser.Password = hasher.HashPassword(newUser, newUser.Password);
        // Save the user in the database
        _context.Add(newUser);
        Console.WriteLine($"New user id before saving: {newUser.UserId}"); // This uses the default value of 0
        _context.SaveChanges();
        // Save user in session - make sure at least the ID is included!
        Console.WriteLine($"New user id after saving: {newUser.UserId}"); // Now we get the ID (and other items generated, like the timestamps)
        HttpContext.Session.SetInt32("UserId",newUser.UserId);
        HttpContext.Session.SetString("FirstName",newUser.FirstName);
        HttpContext.Session.SetString("LastName",newUser.LastName);
        return RedirectToAction("AllWeddings","Wedding"); // Send to dashboard - notice we're going to a different controller here!
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); // Clear session
        return RedirectToAction("Index");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser possibleUser)
    {
        if (ModelState.IsValid) // Built-in validations succeed, but there are more we have to add ourselves...
        {
            // Try to find a user with this email (notice the "User?", as this will be null if we don't find anyone)
            User? userInDB = _context.Users.FirstOrDefault(u => u.Email.Equals(possibleUser.LoginEmail));
            if (userInDB == null) // No email found
            {
                ModelState.AddModelError("LoginEmail","Invalid login credentials."); // Add new error
                return View("Index");
            }
            // User found, so check the password
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(possibleUser,userInDB.Password,possibleUser.LoginPassword);
            if (result == 0) // 0 = failure, 1 = success, 2 = success but need to rehash and update
            {
                ModelState.AddModelError("LoginEmail","Invalid login credentials."); // Add new error
                return View("Index");
            }
            else
            {
                // All credentials pass, so save the ID and other info in session, then redirect accordingly
                HttpContext.Session.SetInt32("UserId",userInDB.UserId);
                HttpContext.Session.SetString("FirstName",userInDB.FirstName);
                HttpContext.Session.SetString("LastName",userInDB.LastName);
                return RedirectToAction("AllWeddings","Wedding");
            }
            
        }
        else // Built-in validations fail
        {
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
