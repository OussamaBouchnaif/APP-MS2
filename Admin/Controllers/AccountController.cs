using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<Utilisateur> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPasswordHasher<Utilisateur> _passwordHasher;
        private readonly IUtilisateurService _utilisateurService;

        public AccountController(
            IRepository<Utilisateur> userRepository,
            IHttpContextAccessor httpContextAccessor,
            IPasswordHasher<Utilisateur> passwordHasher,
            IUtilisateurService utilisateurService)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _passwordHasher = passwordHasher;
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var returnUrl = _httpContextAccessor.HttpContext.Session.GetString("ReturnUrl");
            if (ModelState.IsValid)
            {
                var user = _userRepository.FindByExpression(u => u.Email == model.Email);
                if (user != null)
                {
                    var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.MotDePasse, model.Password);
                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        _httpContextAccessor.HttpContext.Session.SetObjectAsJson("User", user);

                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl ?? Url.Action("Index", "Dashboard"));
                        }

                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        [HttpGet]
        public IActionResult Signin()
        {
            var model = new SigninViewModel
            {
                Roles = _utilisateurService.GetRolesList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Utilisateur
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Age = model.Age,
                    Tele = model.Tele,
                    Sexe = model.Sexe,
                    Email = model.Email,
                    Role = model.RoleSelected
                };

                newUser.MotDePasse = _passwordHasher.HashPassword(newUser, model.Password);

                _userRepository.Insert(newUser);
                _userRepository.SaveChanges();

                _httpContextAccessor.HttpContext.Session.SetObjectAsJson("User", newUser);

                TempData["SuccessMessage"] = "Vous êtes connecté avec succès.";

                return RedirectToAction("Index", "Utilisateur");
            }
            model.Roles = _utilisateurService.GetRolesList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            _httpContextAccessor.HttpContext.Session.Clear();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return RedirectToAction("Login", new { returnUrl });
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult LockScreen()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lock()
        {
            _httpContextAccessor.HttpContext.Session.SetString("IsLocked", "true");
            return RedirectToAction("LockScreen");
        }

        [HttpPost]
        public async Task<IActionResult> LockScreen(string password)
        {
            var userJson = _httpContextAccessor.HttpContext.Session.GetString("User");
            var returnUrl = _httpContextAccessor.HttpContext.Session.GetString("ReturnUrl");
            var user = JsonConvert.DeserializeObject<Utilisateur>(userJson);

            if (user != null)
            {
                var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.MotDePasse, password);
                if (verificationResult == PasswordVerificationResult.Success)
                {
                    _httpContextAccessor.HttpContext.Session.Remove("IsLocked");
                    _httpContextAccessor.HttpContext.Session.Remove("ReturnUrl");
                    return Redirect(returnUrl ?? Url.Action("Index", "Dashboard"));
                }
                ModelState.AddModelError(string.Empty, "Mot de passe incorrect.");
            }
            return View();
        }
    }
}