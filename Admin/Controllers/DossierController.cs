using Admin.Service.Contract;
using Admin.ViewModel.DossierPersonnel;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class DossierController : Controller
    {
        private readonly IDossierService _dossierService;

        public DossierController(IDossierService dossierService)
        {
            _dossierService = dossierService;
        }

        [HttpGet]
        public IActionResult AddDossier(int Id)
        {
            ViewData["Id"] = Id;
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

        [HttpGet]
        public IActionResult AddDossierMedical(int Id)
        {
            ViewData["Id"] = Id;
            return View();
        }
    }
}