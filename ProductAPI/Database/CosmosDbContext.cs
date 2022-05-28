using Microsoft.EntityFrameworkCore;
using ProductAPI.Database.Models;

namespace ProductAPI.Database;

public class CosmosDbContext : DbContext
{
    public CosmosDbContext(DbContextOptions options) : base(options) {}
    public DbSet<Product> Products { get; set; }
}