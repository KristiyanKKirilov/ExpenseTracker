using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> All()
        {
            List<Category> categories = await _context.Set<Category>().ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            Category? category = await _context.Categories.FindAsync(id);

            if(category == null)
            {
                return View(new Category());
            }

            
            return View(category);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateEdit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);

            if (existingCategory == null)
            {
                await _context.AddAsync(category);
            }
            else
            {
                _context.Update(existingCategory);
                existingCategory.Title = category.Title;
                existingCategory.Type = category.Type;
                existingCategory.Icon = category.Icon;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (existingCategory == null)
            {
                return BadRequest();
            }

            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));


        }

    }
}
