using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dropship.Models;
using dropship.Data;
using dropship.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dropship.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext context;

    public ProductController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new AddProductViewModel{
            // fetching all categories from db
             Categories = await context.Categories.ToListAsync(),
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProductViewModel model)
    {
            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Quantity = model.Quantity,
                Tags = model.Tags
            };
            foreach (var categoryId in model.SelectedCategoryIds)
            {
                // Console.WriteLine(categoryId);
                var productCategory = new ProductCategory
                {
                    Product = product,
                    CategoryId = categoryId
                };
                context.ProductCategories.Add(productCategory);
            }
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return RedirectToAction("List");
        
    }

    [HttpGet]
    public async Task<IActionResult> List(string productName)
    {
        Console.WriteLine(productName);
        var products = await context.Products.Include(p=> p.ProductCategories).ThenInclude(c=> c.Category).ToListAsync();
        // this will pass the products list to products/List.cshtml file
        if(!string.IsNullOrEmpty(productName))
        {
        products = products.Where(p => p.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        return View(products);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        Product product= await context.Products.FindAsync(id);
        
            return View(product);
    
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product model)
    {
       Product product= await context.Products.FindAsync(model.ProductId);
            product.ProductId = model.ProductId;
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Quantity = model.Quantity;
            product.Tags = model.Tags;

            await context.SaveChangesAsync();
            return RedirectToAction("List","Product");
      
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product model)
    {
         Product product= await context.Products.FindAsync(model.ProductId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction("List","Product");
    }
}
