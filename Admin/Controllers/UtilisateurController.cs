using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        public IActionResult Index()
        {
            var Utilisateurs =_utilisateurService.GetAllUtilisateurs();
            return View(Utilisateurs);
        }
        [HttpGet]
        public IActionResult Add() {
            ViewBag.Sexes = GetSexesList();
            ViewBag.Roles = GetRoles();


            return View();
        }
        [HttpPost]
        public IActionResult Add(UtilisateurVM utilisateurVM)
        {
            if (ModelState.IsValid)
            {
                _utilisateurService.AddUtilisateur(utilisateurVM);
                return RedirectToAction("Index");
            }
            ViewBag.Sexes = GetSexesList();
            ViewBag.Roles = GetRoles();


            return View(utilisateurVM);
        }
        private List<SelectListItem> GetSexesList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Homme", Text = "Homme" },
                new SelectListItem { Value = "Femme", Text = "Femme" }
            };
        }
        private List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Agent", Text = "Agent" }
            };
        }
    }
}
