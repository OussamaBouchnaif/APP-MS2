using Admin.Mapper.Contract;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MS2Api.Model;

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
            var utilisateurVM = _utilisateurMapper.MapToUtilisateurVM(utilisateur);

            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();

            return View(utilisateurVM);
        }

        [HttpPost]
        public IActionResult Edit(UtilisateurVM utilisateurVM)
        {
            if (ModelState.IsValid)
            {
                var utilisateur = _utilisateurService.GetUtilisateurById(utilisateurVM.Id);
                if (utilisateur == null)
                {
                    return NotFound();
                }
                _utilisateurService.UpdateUtilisateur(utilisateurVM, utilisateur);
                return RedirectToAction("Index");
            }

            ViewBag.Sexes = _utilisateurService.GetSexesList();
            ViewBag.Roles = _utilisateurService.GetRolesList();

            return View(utilisateurVM);
        }

        public IActionResult Delete(int Id)
        {
            Utilisateur utilisateur = _utilisateurService.GetUtilisateurById(Id);
            _utilisateurService.DeleteUtilisateur(utilisateur);
            return RedirectToAction(nameof(Index));
        }
    }
}