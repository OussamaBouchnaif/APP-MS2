using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // la logique d'authentification
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // logique de déconnexion
            return RedirectToAction("Login");
        }
    }
}