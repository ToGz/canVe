using ProductsAPI.Database;
using ProductsAPI.Database.Models;

namespace ProductsAPI.Commands;

public static class ProductCommandEndpoint
{
    public static void MapProductCommandEndpoint(this WebApplication app)
    {
        
        app.MapPost("/product", async (CosmosDbContext context, string name) =>
        {
            var product = new Product()
            {
                Name = name
            };

            try
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
            }
            catch (Exception _)
            {
                return Results.Problem();
            }
    
            return Results.Ok(product.Id.ToString());
        }).WithName("AddProduct");
    }
}