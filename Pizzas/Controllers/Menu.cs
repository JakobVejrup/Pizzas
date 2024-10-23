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
        public async Task <IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }
    }
}
