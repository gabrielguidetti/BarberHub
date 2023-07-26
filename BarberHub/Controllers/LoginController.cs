using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BarberHub.ViewModel;
using BarberHub.Services.Interfaces;

namespace BarberHub.Controllers
{
    public class LoginController : Controller
    {
        private IUserService UserService { get; set; }

        public LoginController(IUserService userService)
        {
                UserService = userService;
        }

        public IActionResult Enter()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if(claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enter(UserViewModel modelLogin)
        {
            var model = UserService.ValidableLogin(modelLogin);

            if (model != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, model.Type.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.Now.AddHours(8),
                    IssuedUtc = DateTime.Now,
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessageLogin"] = "E-mail ou senha inválidos!";

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            var result = UserService.Add(model);

            if (result == null)
            {
                ViewData["ValidateMessageRegister"] = "Erro ao criar usuário, verifique se todos os campos estão preenchidos e se as senhas coincidem!";
                return View();
            }

            ViewData["ValidateMessageLogin"] = "Conta criada com sucesso!";
            return View("Enter");
        }
    }
}
