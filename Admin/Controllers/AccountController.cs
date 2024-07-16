using Admin.Service;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserIdentityService userService;
        private readonly IUtilisateurService utilisateurService;

        public AccountController(IUserIdentityService userService, IUtilisateurService utilisateurService)
        {
            this.userService = userService;
            this.utilisateurService = utilisateurService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await this.userService.PasswordSignInAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Errors", "Identifiant incorrect");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Signin()
        {
            var model = new SigninViewModel
            {
                Roles = utilisateurService.GetRolesList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SigninViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = utilisateurService.GetRolesList();
                return View(model);
            }

            var (result, utilisateur) = await this.userService.CreateUserAsync(model);

            if (result.Succeeded)
            {
                //var resultRole = await this.userService.AddToRoleAsync(utilisateur, model.RoleSelected);
                //if (resultRole.Succeeded)
                //{
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError(item.Code, item.Description);
                //    }
                //    model.Roles = utilisateurService.GetRolesList();
                //    return View(model);
                //}
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                model.Roles = utilisateurService.GetRolesList();
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await this.userService.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}