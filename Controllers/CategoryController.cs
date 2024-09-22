using dropship.Data;
using dropship.Models;
using dropship.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dropship.Controllers
{
    public class CategoryController:Controller
    {
         private readonly ApplicationDbContext context;

    public CategoryController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddCategoryViewModel model)
    {
        Category category = new Category
        {
            CategoryName = model.CategoryName
        };
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var category = await context.Categories.ToListAsync();
        // this will pass the products list to products/List.cshtml file
        return View(category);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        Category category= await context.Categories.FindAsync(id);
        
            return View(category);
    
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category model)
    {
       Category category= await context.Categories.FindAsync(model.CategoryId);
            category.CategoryId = model.CategoryId;
            category.CategoryName = model.CategoryName;
            await context.SaveChangesAsync();
            return RedirectToAction("List","Category");
      
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Category model)
    {
         Category category= await context.Categories.FindAsync(model.CategoryId);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return RedirectToAction("List","Category");
    }
    }
}