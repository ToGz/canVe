using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;
using ProductsAPI.Database.Models;

namespace ProductsAPI.Queries;

public class ProductQueryRepository
{
    private readonly CosmosDbContext _context;

    public ProductQueryRepository(CosmosDbContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetByQueryString(string query)
        // TODO: If I find one by code I shouldn't really try by name
    {
        return _context.Products
            .Where(product => product.Name.Contains(query))
            .ToListAsync();
    }

    public Task<Product?> GetById(string productId)
    {
        return _context.Products
            .Where(product => product.Id.Equals(productId))
            .SingleOrDefaultAsync();
    }
}