using WebApplication1.Models;

namespace WebApplication1.Services.Products;

public interface IProductService
{
    Task<List<Product>> GetAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}