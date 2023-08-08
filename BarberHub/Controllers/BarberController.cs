using BarberHub.Services;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberHub.Controllers
{
    [Authorize]
    public class BarberController : Controller
    {
        private IBarberService BarberService { get; set; }
        private IBarberShopService BarberShopService { get; set; }

        public BarberController(IBarberService barberService, 
                                IBarberShopService barberShopService)
        {
            BarberService = barberService;
            BarberShopService = barberShopService;

        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult Create(int barberShopId)
        {
            var model = new BarberViewModel() { BarberShopId = barberShopId };
            return View(model);
        }

        [Authorize(Roles = "BarberShop")]
        [HttpPost]
        public IActionResult Create(BarberViewModel model)
        {
            var result = BarberService.Add(model);

            if(result == null)
            {
                ViewData["ValidateMessage"] = "Erro ao criar barbeiro, verifique se todos os campos estão preenchidos!";
                return View();
            }

            return RedirectToAction("Index","BarberShop");
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult Edit(int id)
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            var barber = BarberService.Get(id);

            if (barber.BarberShopId != barberShop.Id)
                RedirectToAction("Index", "BarberShop");

            return View(barber);
        }

        [Authorize(Roles = "BarberShop")]
        [HttpPost]
        public IActionResult Edit(BarberViewModel model)
        {
            var result = BarberService.Update(model);

            if (result == null)
            {
                ViewData["ValidateMessage"] = "Erro ao criar barbeiro, verifique se todos os campos estão preenchidos!";
                return View();
            }

            return RedirectToAction("Index", "BarberShop");
        }
    }
}
