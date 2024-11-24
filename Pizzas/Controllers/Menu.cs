using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzas.Data;
using Pizzas.Models;
namespace Pizzas.Controllers
{
    public class Menu : Controller
    {
        private readonly PizzasContext _context;
        public Menu(PizzasContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes
                       select d;
            if(!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Title.Contains(searchString));
                return View(await dishes.ToListAsync());
            }
            return View(await _context.Dishes.ToListAsync());
        }

        public async Task<IActionResult> Details (int? id)
        {
            var dishes = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredients)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dishes == null)
            {
                return NotFound();
            }
            return View(dishes);
        }
    }
}
