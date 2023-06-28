using WebApplication1.Models;

namespace WebApplication1.Services.Transactions;

public interface ITransactionService
{
    Task<List<Transaction>> GetAsync();
    Task<Transaction?> GetByIdAsync(int id);
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(int id);
}