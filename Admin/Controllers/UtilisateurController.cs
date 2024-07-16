using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UtilisateurController : Controller
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        public IActionResult Index()
        {
            var utilisateurs = _utilisateurService.GetAllUtilisateurs();
            return View(utilisateurs);
        }

        [HttpGet]
        public IActionResult Add()
        {
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var utilisateur = _utilisateurService.GetUtilisateurById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            
            return View(utilisateurVM);
        }
            var utilisateurVM = _utilisateurService.GetUtilisateurById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();

            return View(utilisateurVM);
        }

        [HttpPost]
        public IActionResult Edit(UtilisateurVM utilisateurVM)
        {
            if (ModelState.IsValid)
            {
                _utilisateurService.UpdateUtilisateur(utilisateurVM);
                return RedirectToAction("Index");
            }

            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();
            return View(utilisateurVM);
        }

        public IActionResult Delete(int id)
        {
            var utilisateur = _utilisateurService.GetUtilisateurById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _utilisateurService.DeleteUtilisateur(id);
            return RedirectToAction("Index");
        }
    }
}