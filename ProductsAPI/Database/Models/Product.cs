using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Database.Models;

public class Product
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
}