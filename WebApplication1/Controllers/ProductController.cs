using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Products;
namespace WebApplication1.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Products()
    {
        var product = await _productService.GetAsync();
        ViewData["Customers"] = product;

        return View();
    }

    [HttpGet]
    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _productService.AddAsync(product);
        return RedirectToAction("Products", "Product");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return RedirectToAction("Products");
        }

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteAsync(id);
        return RedirectToAction("Products", "Product");
    }
}