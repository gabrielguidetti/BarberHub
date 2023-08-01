using BarberHub.Models;
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
        public IActionResult CreateBarberShopPanel()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop != null)
                return RedirectToAction("Index");

            return View();
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop == null)
                return RedirectToAction("CreateBarberShopPanel");

            return View(barberShop);
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult Edit()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop == null)
                return RedirectToAction("CreateBarberShopPanel");

            return View(barberShop);
        }

        [Authorize(Roles = "BarberShop")]
        [HttpPost]
        public IActionResult Edit(BarberShopViewModel model)
        {
            var result = BarberShopService.Update(model);

            if (result == null)
            {
                ViewData["ValidateMessage"] = "Erro ao editar barbearia, verifique se todos os campos estão preenchidos!";
                return View();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "BarberShop")]
        public IActionResult Create()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value);

            var barberShop = BarberShopService.GetByUser(userId);

            if (barberShop != null)
                return RedirectToAction("Index");

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

            return RedirectToAction("Index");
        }
    }
}
