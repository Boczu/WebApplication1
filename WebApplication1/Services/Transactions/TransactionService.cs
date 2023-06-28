using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Persistence;



namespace WebApplication1.Services.Transactions;

public class TransactionService : ITransactionService
{
    private readonly DatabaseContext _context;

    public TransactionService(DatabaseContext context) { _context = context; }

    public async Task<List<Transaction>> GetAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction?> GetByIdAsync(int id)
    {
        return await _context.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == id);
    }

    public async Task AddAsync(Transaction transaction)
    {
        var existingTransaction = await GetByIdAsync(transaction.Id);

        if (existingTransaction is null)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        var existingTransaction = await GetByIdAsync(transaction.Id);

        if (existingTransaction is not null)
        {
            existingTransaction.Id = transaction.Id;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var transaction = await GetByIdAsync(id);

        if (transaction is not null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}