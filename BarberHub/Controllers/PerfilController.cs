using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Client()
        {
            return View();
        }

        public IActionResult BarberShop()
        {
            return View();
        }
    }
}
