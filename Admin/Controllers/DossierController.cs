using Admin.Service.Contract;
using Admin.ViewModel.DossierPersonnel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

namespace Admin.Controllers
{
    //[ServiceFilter(typeof(AuthenticationFilter))]
    public class DossierController : Controller
    {
        private readonly IDossierService _dossierService;

        public DossierController(IDossierService dossierService)
        {
            _dossierService = dossierService;
        }

        public IActionResult Index(int BeneficiaryId)
        {
            DossierPersonnel dossierPersonnel = _dossierService.GetDossierPersonnel(BeneficiaryId);
            if (dossierPersonnel == null)
            {
                TempData["Message"] = "Le dossier personnel est introuvable pour ce bénéficiaire.";
                return RedirectToAction("Index", "Benificier");
            }
            return View(dossierPersonnel);
        }

        [HttpGet]
        public IActionResult AddDossier(int BeneficiaryId)
        {
            DossierPersonnel dossierPersonnel = _dossierService.GetDossierPersonnel(BeneficiaryId);
            if (dossierPersonnel != null)
            {
                TempData["Message"] = "Ce bénéficiaire a déjà un dossier.";
                return RedirectToAction("Index", "Benificier");
            }
            ViewData["Id"] = BeneficiaryId;
            return View();
        }

        [HttpPost]
        public JsonResult AddDossier(DossierPersonnelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _dossierService.CreateDossierPersonnel(model);
                return Json(new { success = true, message = "Dossier créé avec succès!" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors = errors });
        }
    }
}
