using Admin.Models;
using Admin.Service;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

namespace Admin.Controllers
{
    public class AvisController : Controller
    {
        private readonly IAvisService _avisService;

        public AvisController(IAvisService avisService)
        {
            _avisService = avisService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var benificier = HttpContext.Session.GetObjectFromJson<Benificier>("Benificier");
            if (benificier == null)
            {
                ViewBag.Message = "Veuillez saisir un code unique valide.";
                return View(new AvisListViewModel());
            }

            var avisList = _avisService.GetAvisByBeneficiaryId(benificier.Id).ToList();
            var model = new AvisListViewModel
            {
                Avis = avisList,
                AvisViewModel = new AvisViewModel()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EnvoyerAvis(string Contenue)
        {
            if (string.IsNullOrWhiteSpace(Contenue))
            {
                return Json(new { success = false, message = "Le contenu ne peut pas être vide." });
            }

            var benificier = HttpContext.Session.GetObjectFromJson<Benificier>("Benificier");
            if (benificier == null)
            {
                return Json(new { success = false, message = "Veuillez saisir un code unique valide avant d'envoyer un avis." });
            }

            var avis = new Avis
            {
                DateTime = DateTime.Now,
                Contenue = Contenue,
                BenificierId = benificier.Id
            };

            _avisService.AddAvis(avis);

            return Json(new { success = true, message = "Avis envoyé avec succès." });
        }

        [HttpGet]
        public IActionResult AfficherTousLesAvis()
        {
            var avisList = _avisService.GetAllAvis().ToList();
            var model = new AvisListViewModel
            {
                Avis = avisList
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteAvis(int id)
        {
            var avis = _avisService.GetAvisById(id);
            if (avis != null)
            {
                _avisService.DeleteAvis(avis);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Avis non trouvé." });
        }
    }
}