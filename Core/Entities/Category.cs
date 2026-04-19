using System;

namespace Core.Entities;

public class Category :BaseEntity
{
    public required string Name { get; set; }
    public  string? Description { get; set; }
    public  int ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category> Children { get; set; } = new List<Category>();
    public ICollection<Product>Products { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
