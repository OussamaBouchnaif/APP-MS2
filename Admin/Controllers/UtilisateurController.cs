using Admin.Mapper.Contract;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;
using System.Security.Claims;

namespace Admin.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class UtilisateurController : Controller
    {
        private readonly IUtilisateurService _utilisateurService;
        private readonly IUtilisateurMapper _utilisateurMapper;

        public UtilisateurController(IUtilisateurService utilisateurService, IUtilisateurMapper utilisateurMapper)
        {
            _utilisateurService = utilisateurService;
            _utilisateurMapper = utilisateurMapper;
        }

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userClaims = User.Claims;
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
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();
            return View(utilisateurVM);
        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var utilisateur = _utilisateurService.GetUtilisateurById(id);
        //    if (utilisateur == null)
        //    {
        //        return NotFound();
        //    }

        //    var utilisateurVM = _utilisateurMapper.MapToUtilisateurVM(utilisateur);
        //    ViewBag.Sexes = _utilisateurService.GetSexesList();
        //    ViewBag.Roles = _utilisateurService.GetRolesList();
        //    return View(utilisateurVM);
        //}

        //[HttpPost]
        //public IActionResult Edit(UtilisateurVM utilisateurVM, int Id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var utilisateur = _utilisateurService.GetUtilisateurById(Id);
        //        if (utilisateur == null)
        //        {
        //            return NotFound();
        //        }

        //        _utilisateurService.UpdateUtilisateur(utilisateurVM, utilisateur);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ViewBag.Sexes = _utilisateurService.GetSexesList();
        //    ViewBag.Roles = _utilisateurService.GetRolesList();
        //    return View(utilisateurVM);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var utilisateur = _utilisateurService.GetUtilisateurById(id);
                if (utilisateur == null)
                {
                    return Json(new { success = false, message = "Utilisateur non trouv�" });
                }

                _utilisateurService.DeleteUtilisateur(utilisateur);
                return Json(new { success = true, message = "Utilisateur supprim� avec succ�s" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var user = HttpContext.Session.GetObjectFromJson<Utilisateur>("User");

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var utilisateurVM = _utilisateurMapper.MapToUtilisateurVM(user);
            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();
            return View(utilisateurVM);
        }

        [HttpGet("Profile/{id}")]
        public IActionResult Profile(int id)
        {
            var utilisateurVM = _utilisateurService.GetProfile(id);
            if (utilisateurVM == null)
            {
                return NotFound();
            }

            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();
            return View(utilisateurVM);
        }

        [HttpPost]
        public IActionResult Profile(UtilisateurVM utilisateurVM, int Id)
        {
            var utilisateur = _utilisateurService.GetUtilisateurById(Id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _utilisateurService.UpdateUtilisateur(utilisateurVM, utilisateur);
                return RedirectToAction("Index");
            }

            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();
            return View(utilisateurVM);
        }

        [HttpPost("Profile/UpdateAjax")]
        public IActionResult UpdateAjax(UtilisateurVM utilisateurVM)
        {
            if (ModelState.IsValid)
            {
                var utilisateur = _utilisateurService.GetUtilisateurById(utilisateurVM.Id);
                if (utilisateur == null)
                {
                    return Json(new { success = false, message = "Utilisateur non trouv�" });
                }

                _utilisateurService.UpdateUtilisateur(utilisateurVM, utilisateur);
                return Json(new { success = true, message = "Modification r�ussie" });
            }

            return Json(new { success = false, message = "Erreur de validation" });
        }
    }
}