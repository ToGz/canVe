using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;
using ProductsAPI.Database.Models;
using ProductsAPI.Integrations;
using ProductsAPI.Integrations.BarcodeLookup.BarcodeLookupMock;

namespace ProductsAPI.Queries;

public static class ProductQueryEndpoint
{
    /*
     TODO: We need two endpoints here:
        GetByID
        Search for product by name / code 
    */
    public static void MapProductQueryEndpoint(this WebApplication app)
    {
        app.MapGet("/product", async (string query) =>
        {
            await GetProductsFromDatabase(query);
        }).WithName("GetProduct");
    }
    
    public static void MapProductIdQueryEndpoint(this WebApplication app)
    {
        app.MapGet("/product/{id}", async (CosmosDbContext context, string id) =>
        {
            
        }).WithName("GetProductById");
    }

    private static async Task<Product> GetProductsFromDatabase(string id)
    {
        //var product = await context.Products
        //    .Where(prod => prod.Id.Equals(id))
        //    .SingleAsync();

        (new BarcodeLookupClientMock()).FindProductByKeywords(id);
            
        return null;
    }
}