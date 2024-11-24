using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pizzas.Data;
using Pizzas.Models;

namespace Pizzas.Controllers
{
    public class DishesController : Controller
    {
        private readonly PizzasContext _context;

        public DishesController(PizzasContext context)
        {
            _context = context;
        }

        //Get Dishes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dishes.ToListAsync());
        }

        //Get dishes details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishes = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dishes == null)
            {
                return NotFound();
            }

            return View(dishes);
        }

        //Get Dishes Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Dishes Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageURL,Price")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dishes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dishes);
        }

        //Get Dishes Edit 5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishes = await _context.Dishes.FindAsync(id);
            if (dishes == null)
            {
                return NotFound();
            }
            return View(dishes);
        }

        //Post Dishes Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageURL,Price")] Dishes dishes)
        {
            if (id != dishes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dishes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishesExists(dishes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dishes);
        }

        //Get Dishes Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishes = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dishes == null)
            {
                return NotFound();
            }

            return View(dishes);
        }

        //Post Dishes Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dishes = await _context.Dishes.FindAsync(id);
            if (dishes != null)
            {
                _context.Dishes.Remove(dishes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishesExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
