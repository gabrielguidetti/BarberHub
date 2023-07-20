using BarberHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BarberHub.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}