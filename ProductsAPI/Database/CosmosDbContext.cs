using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database.Models;

namespace ProductsAPI.Database;

public class CosmosDbContext : DbContext
{
    public CosmosDbContext(DbContextOptions options) : base(options) {}
    public DbSet<Product> Products { get; set; }
}