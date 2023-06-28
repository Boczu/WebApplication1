using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Persistence;

namespace WebApplication1.Services.Products;

public class ProductService : IProductService
{
    private readonly DatabaseContext _context;

    public ProductService(DatabaseContext context) { _context = context; }

    public async Task<List<Product>> GetAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        var existingProduct = await GetByIdAsync(product.Id);

        if (existingProduct is null)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Product product)
    {
        var existingProduct = await GetByIdAsync(product.Id);

        if (existingProduct is not null)
        {
            existingProduct.Name = product.Name;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);

        if (product is not null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}