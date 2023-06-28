using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Transactions;
namespace WebApplication1.Controllers;

public class TransactionController : Controller
{
    private readonly ILogger<TransactionController> _logger;
    private readonly ITransactionService _transactionService;

    public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
    {
        _logger = logger;
        _transactionService = transactionService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Customers()
    {
        var transactions = await _transactionService.GetAsync();
        ViewData["Transaction"] = transactions;
        
        return View();
    }
    
    [HttpGet]
    public IActionResult CreateTransaction()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Transaction transaction)
    {
        await _transactionService.AddAsync(transaction);
        return RedirectToAction("Transactions", "Transaction");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var transaction = await _transactionService.GetByIdAsync(id);
        if (transaction == null)
        {
            return RedirectToAction("Transactions");
        }

        return View(transaction);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _transactionService.DeleteAsync(id);
        return RedirectToAction("Transactions", "Transaction");
    }
}