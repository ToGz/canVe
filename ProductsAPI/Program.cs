using Microsoft.EntityFrameworkCore;
using ProductsAPI.Commands;
using ProductsAPI.Database;
using ProductsAPI.Integrations;
using ProductsAPI.Integrations.BarcodeLookup.BarcodeLookupMock;
using ProductsAPI.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CosmosDbContext>(options =>
    options.UseCosmos(
        builder.Configuration.GetConnectionString("CosmosDBConnection"),
        builder.Configuration.GetValue<string>("DBName")
    ));

if (builder.Environment.IsDevelopment()) // look for a better way of doing this
{
    builder.Services.AddTransient<ILookupClient, BarcodeLookupClientMock>();
}
else
{
    builder.Services.AddTransient<ILookupClient, BarcodeLookupClient>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // TODO: Look this up
    await using (var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateAsyncScope())
    {
        var context = scope?.ServiceProvider.GetRequiredService<CosmosDbContext>();
        await context!.Database.EnsureCreatedAsync();
    }
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductQueryEndpoint();
app.MapProductCommandEndpoint();

app.Run();