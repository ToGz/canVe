using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;

namespace ProductsAPI.Queries;

public static class ProductQueryEndpoint
{
    public static void MapProductQueryEndpoint(this WebApplication app)
    {
        app.MapGet("/product", async (CosmosDbContext context, string id) =>
        {
            var product = await context.Products
                .Where(prod => prod.Id.Equals(id))
                .SingleAsync();
            
            return product;
        }).WithName("GetProduct");
    }
}