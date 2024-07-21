using Admin.Service.Contract;
using Admin.ViewModel.DossierPersonnel;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
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
        public IActionResult AddDossier(DossierPersonnelViewModel model)
        {
            if(ModelState.IsValid)
            {
                _dossierService.CreateDossierPersonnel(model);
                return RedirectToAction("Index", "Benificier");

            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            ViewBag.Errors = errors;

            return View(model);  
        }
    }
}
