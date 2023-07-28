using BarberHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberHub.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private IBarberShopService BarberShopService { get; set; }

        public PerfilController(IBarberShopService barberShopService)
        {
            BarberShopService = barberShopService;
        }

        [Authorize(Roles = "Client")]
        public IActionResult Client()
        {
            return View();
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult BarberShop()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop == null)
                return RedirectToAction("CreateBarberShopPanel");

            return View();
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult CreateBarberShopPanel()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop != null)
                return RedirectToAction("BarberShop");

            return View();
        }
    }
}
