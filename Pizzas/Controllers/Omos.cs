using Microsoft.AspNetCore.Mvc;

namespace Pizzas.Controllers
{
    public class OmosController : Controller
    {
        // GET: Omos/Index
        public IActionResult Index()
        {
            return View();  // Returner view'et til "Om os"-siden
        }
    }
}

