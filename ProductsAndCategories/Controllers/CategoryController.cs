using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    // NEW: Add a private variable of type MyContext (or whatever you named your context file)
    private ProjectContext _context;
    // Here we can "inject" our context service into the constructor
    // The "logger" was something that was already in our code, we're just adding around it
    public CategoryController(ILogger<CategoryController> logger, ProjectContext context) // NEW: Context injected in here
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context; // NEW LINE
    }
    // Define your routes here as you see fit
    [HttpGet("categories")]
    public IActionResult CategoriesPage()
    {
        ViewBag.AllCategories = _context.Categories.ToList(); // Grab all categories
        return View("Categories");
    }
    [HttpPost("categories/create")]
    public IActionResult AddCategory(Category newCategory)
    {
        Console.WriteLine($"Name: {newCategory.Name}");
        if (!ModelState.IsValid) // Validations fail
        {
            ViewBag.AllCategories = _context.Categories.ToList(); // Grab all categories
            return View("Categories");
        }
        // Add category to database, then redirect
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("CategoriesPage");
    }
    [HttpGet("categories/{id}")]
    public IActionResult ViewCategory(int id)
    {
        // Find products by ID linked to the given category
        List<int> productIdResult = _context.ProductsCategories
            .Where(pc => pc.CategoryId == id)
            .Select(pc => pc.ProductId)
            .ToList();
        // Now find the products that are NOT linked to this category
        List<Product> missingProducts = _context.Products
            .Where(p => !productIdResult.Contains(p.ProductId))
            .ToList();
        Category? thisCategory = _context.Categories
            .Include(c => c.Connections) // Connect to middle table
            .ThenInclude(item => item.Product) // Now connect to third table
            .FirstOrDefault(c => c.CategoryId == id);
        if (thisCategory == null)
        {
            return RedirectToAction("Index");
        }
        ViewBag.MissingProducts = missingProducts;
        return View("ViewCategory",thisCategory);
    }
    [HttpPost("categories/addproduct")]
    public IActionResult AddProductToCategory(int CategoryId, int ProductId)
    {
        Console.WriteLine($"Category id = {CategoryId}");
        Console.WriteLine($"Product id = {ProductId}");
        Category? foundCategory = _context.Categories.FirstOrDefault(p => p.CategoryId == CategoryId);
        Product? foundProduct = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
        if (foundCategory == null || foundProduct == null)
        {
            return RedirectToAction("Index");
        }
        ProductCategoryConnector pc = new ProductCategoryConnector();
        pc.ProductId = ProductId;
        pc.CategoryId = CategoryId;
        _context.ProductsCategories.Add(pc);
        _context.SaveChanges();
        return RedirectToAction("ViewCategory", new {id = CategoryId});
    }
    [HttpPost("categories/removeproduct")]
    public IActionResult RemoveProductFromCategory(int CategoryId, int ProductCategoryConnectorId)
    {
        ProductCategoryConnector? foundConnector = _context.ProductsCategories.FirstOrDefault(p => p.ProductCategoryConnectorId == ProductCategoryConnectorId);
        if (foundConnector == null)
        {
            return RedirectToAction("Index");
        }
        _context.ProductsCategories.Remove(foundConnector);
        _context.SaveChanges();
        return RedirectToAction("ViewCategory", new {id = CategoryId});
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}