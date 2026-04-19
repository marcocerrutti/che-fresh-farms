using System;
using System.Security.AccessControl;

namespace Core.Entities;

public class Product :BaseEntity
{
    
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string Type { get; set; }
    public required string Brand { get; set; }
    public int QuantityInStock { get; set; }
    public string? Unit { get; set; }

    public bool IsOrganic { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    public int SupplierId { get; set; }
    public required Supplier Supplier { get; set; }
    
}
