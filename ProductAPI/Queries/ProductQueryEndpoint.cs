using Microsoft.Azure.Cosmos.Linq;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Database;

namespace ProductAPI.Queries;

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