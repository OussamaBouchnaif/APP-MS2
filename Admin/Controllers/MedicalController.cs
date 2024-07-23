using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class MedicalController : Controller
    {


        private readonly IMedicalService _medicalService;
        private readonly IBeneficiaryService _benService;

        public MedicalController(IMedicalService medicalService,IBeneficiaryService beneficiaryService)
        {
            _medicalService = medicalService;
            _benService = beneficiaryService;
        }

        public IActionResult Index(int BeneficiaryId)
        {
            var dossiermedical = _medicalService.GetDossierMedicalById(BeneficiaryId);
            if(dossiermedical == null)
            {
                TempData["Message"] = "Le dossier Medical est introuvable pour ce bénéficiaire.";
                return RedirectToAction("Index", "Benificier");
            }
            var viewModel = new DossierMedicalViewModel
            {
                Benificier = _benService.GetBenificierById(BeneficiaryId),
                DossiersMedicaux = dossiermedical
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult AddDossierMedical(int BeneficiaryId)
        {
            ViewData["Id"] = BeneficiaryId;
            return View();
        }

        [HttpPost]
        public IActionResult AddDossierMedical(DossierMedicalVM model)
        {
            if (ModelState.IsValid)
            {
                _medicalService.AddDossierMedical(model);
                return RedirectToAction("Index", "Benificier");
            }

            return View(model); 
        }
    }
}
