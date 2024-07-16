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
            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();


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
            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();


            return View(utilisateurVM);
        }
      
    }
}
