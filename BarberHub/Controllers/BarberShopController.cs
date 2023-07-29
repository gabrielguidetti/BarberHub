using BarberHub.Services;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberHub.Controllers
{
    [Authorize]
    public class BarberShopController : Controller
    {
        private IBarberShopService BarberShopService { get; set; }

        public BarberShopController(IBarberShopService barberShopService)
        {
            BarberShopService = barberShopService;
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult Create()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop != null)
                return RedirectToAction("BarberShop", "Perfil");

            return View();
        }

        [Authorize(Roles = "BarberShop")]
        [HttpPost]
        public IActionResult Create(BarberShopViewModel model)
        {
            model.UserId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var result = BarberShopService.Add(model);

            if(result == null)
            {
                ViewData["ValidateMessage"] = "Erro ao criar barbearia, verifique se todos os campos estão preenchidos!";
                return View();
            }

            return RedirectToAction("BarberShop", "Perfil");
        }
    }
}
