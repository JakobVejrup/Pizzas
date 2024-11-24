using Microsoft.AspNetCore.Mvc;
using Pizzas.Data;
using Pizzas.Models;
using Microsoft.EntityFrameworkCore;


public class MenuController : Controller
{
    private readonly PizzasContext _context;

    public MenuController(PizzasContext context)
    {
        _context = context;
    }

    // GET: Menu/Create
    public IActionResult Create()
    {
        return View(); // Returner formularen til at oprette en pizza
    }

    // POST: Menu/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title, ImageURL, Price")] Dishes dish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirect til Index siden efter oprettelse
        }
        return View(dish); // Hvis validering fejler, vis formularen igen
    }
    // GET: Menu/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dish = await _context.Dishes.FindAsync(id);
        if (dish == null)
        {
            return NotFound();
        }
        return View(dish);  // Returner pizzaen til redigeringsformularen
    }

    // POST: Menu/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageURL,Price")] Dishes dish)
    {
        if (id != dish.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dish);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var dbDish = await _context.Dishes.AsNoTracking().FirstOrDefaultAsync(d => d.Id == dish.Id);
                if (dbDish == null)
                {
                    return NotFound();
                }

                ModelState.AddModelError("", "Den pizza, du forsøgte at opdatere, blev ændret af en anden bruger. Vær venlig at revidere og prøv igen.");
                return View(dish);
            }
            return RedirectToAction(nameof(Index));  // Redirect til index-siden efter ændringer
        }
        return View(dish);
    }
    public class MenuController1 : Controller
    {
        private readonly PizzasContext _context;

        public MenuController1(PizzasContext context)
        {
            _context = context;
        }

        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);  // Returner pizzaen til Delete.cshtml
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));  // Efter sletning, send brugeren tilbage til Index
        }
    }




}



