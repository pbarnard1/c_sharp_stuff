using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    // NEW: Add a private variable of type MyContext (or whatever you named your context file)
    private ProjectContext _context;
    // Here we can "inject" our context service into the constructor
    // The "logger" was something that was already in our code, we're just adding around it
    public ProductController(ILogger<ProductController> logger, ProjectContext context) // NEW: Context injected in here
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context; // NEW LINE
    }
    // Define your routes here as you see fit
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.AllProducts = _context.Products.ToList(); // Grab all products
        return View();
    }
    [HttpPost("products/create")]
    public IActionResult AddProduct(Product newProduct)
    {
        Console.WriteLine($"Name: {newProduct.Name}");
        Console.WriteLine($"Description: {newProduct.Description}");
        Console.WriteLine($"Price: {newProduct.Price}");
        if (!ModelState.IsValid) // Validations fail
        {
            // IMPORTANT: All ViewBag items must be sent again!
            ViewBag.AllProducts = _context.Products.ToList(); // Grab all products
            return View("Index");
        }
        // Add product to database, then redirect
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet("products/{id}")]
    public IActionResult ViewProduct(int id)
    {
        // Find categories by ID linked to the given product
        List<int> categoryIdResult = _context.ProductsCategories
            .Where(pc => pc.ProductId == id)
            .Select(pc => pc.CategoryId)
            .ToList();
        // Now find the categories that are NOT linked to this product
        List<Category> missingCategories = _context.Categories
            .Where(c => !categoryIdResult.Contains(c.CategoryId))
            .ToList();
        // Test code to see which categories are NOT linked
        // foreach(Category c in missingCategories)
        // {
        //     Console.WriteLine(c.Name);
        // }
        Product? thisProduct = _context.Products
            .Include(p => p.Connections) // Connect to middle table
            .ThenInclude(item => item.Category) // Now connect to third table
            .FirstOrDefault(p => p.ProductId == id);
        if (thisProduct == null)
        {
            return RedirectToAction("Index");
        }
        // Test code to see which categories are linked
        // foreach(ProductCategoryConnector k in thisProduct.Connections)
        // {
        //     if (k.Category != null)
        //     {
        //         Console.WriteLine(k.Category.Name);
        //     }
        // }
        
        ViewBag.MissingCategories = missingCategories;
        return View("ViewProduct",thisProduct);
    }
    [HttpPost("products/addcategory")]
    public IActionResult AddCategoryToProduct(int ProductId, int CategoryId)
    {
        Console.WriteLine($"Product id = {ProductId}");
        Console.WriteLine($"Category id = {CategoryId}");
        Product? foundProduct = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
        Category? foundCategory = _context.Categories.FirstOrDefault(p => p.CategoryId == CategoryId);
        if (foundProduct == null || foundCategory == null)
        {
            return RedirectToAction("Index");
        }
        ProductCategoryConnector pc = new ProductCategoryConnector();
        pc.CategoryId = CategoryId;
        pc.ProductId = ProductId;
        _context.ProductsCategories.Add(pc);
        _context.SaveChanges();
        return RedirectToAction("ViewProduct", new {id = ProductId});
    }
    [HttpPost("product/removecategory")]
    public IActionResult RemoveCategoryFromProduct(int ProductId, int ProductCategoryConnectorId)
    {
        ProductCategoryConnector? foundConnector = _context.ProductsCategories.FirstOrDefault(p => p.ProductCategoryConnectorId == ProductCategoryConnectorId);
        if (foundConnector == null)
        {
            return RedirectToAction("Index");
        }
        _context.ProductsCategories.Remove(foundConnector);
        _context.SaveChanges();
        return RedirectToAction("ViewProduct", new {id = ProductId});
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}