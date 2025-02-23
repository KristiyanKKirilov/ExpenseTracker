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
        public IActionResult Create()
        {
            Category category = new ();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

    }
}
