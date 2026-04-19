using System;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController:ControllerBase
{
    private readonly StoreContext context;

    public CategoriesController(StoreContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await context.Categories.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await context.Categories.FindAsync(id);

        if (category == null) return NotFound();

        return category;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        return category;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateCategory(int id, Category category)
    {
        if(category.Id !=id || !CategoryExists(id)) return BadRequest("Cannot update this category");

        context.Entry(category).State = EntityState.Modified;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult>Delete(int id)
    {
        var category = await context.Categories.FindAsync(id);

        if(category == null) return NotFound();

        context.Categories.Remove(category);

        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return context.Categories.Any(x=>x.Id == id);
    }
}
