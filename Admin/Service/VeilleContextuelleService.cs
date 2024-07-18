using Admin.Enums;
using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

namespace Admin.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class VeilleContextuelleController : Controller
    {
        private readonly IVeilleContextuelleService veilleContextuelleService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IVeilleContextuelleMapper veilleContextuelleMapper;

        public VeilleContextuelleController(IVeilleContextuelleService veilleContextuelleService, IHttpContextAccessor httpContextAccessor, IVeilleContextuelleMapper veilleContextuelleMapper)
        {
            this.veilleContextuelleService = veilleContextuelleService;
            this.httpContextAccessor = httpContextAccessor;
            this.veilleContextuelleMapper = veilleContextuelleMapper;
        }

        public IActionResult Index()
        {
            var veilleList = veilleContextuelleService.GetFilteredVeilles();
            return View(veilleList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = httpContextAccessor.HttpContext.Session.GetObjectFromJson<Utilisateur>("User");
            var model = new VeilleContextuelleViewModel
            {
                UtilisateurId = user.Id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(VeilleContextuelleViewModel model, int[] SourceInformation, int[] TypeMigrants, int[] Nationalites)
        {
            if (ModelState.IsValid)
            {
                veilleContextuelleService.AddVeille(model, SourceInformation, TypeMigrants, Nationalites);
                return Ok(new { message = "La veille contextuelle a été ajoutée avec succès." });
            }
            var user = httpContextAccessor.HttpContext.Session.GetObjectFromJson<Utilisateur>("User");
            model.UtilisateurId = user.Id;
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int veilleId, VerificationStatus status)
        {
            veilleContextuelleService.UpdateVerificationStatus(veilleId, status);
            return Ok(new { message = "Le statut a été mis à jour avec succès." });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var veille = veilleContextuelleService.GetVeilleById(id);
            if (veille == null)
            {
                return NotFound();
            }
            var veilleVM = veilleContextuelleMapper.MapToViewModel(veille);
            veilleVM.AgentMS2 = veille.Utilisateur != null ? veille.Utilisateur.Nom + ' ' + veille.Utilisateur.Prenom : "N/A";

            var topNationalities = veilleContextuelleService.GetTopNationalities(veille);
            ViewBag.TopNationalities = topNationalities;

            return View(veilleVM);
        }

        [HttpGet]
        public IActionResult GetStatistiques(int id)
        {
            var veille = veilleContextuelleService.GetVeilleById(id);
            if (veille == null)
            {
                return NotFound();
            }

            var data = new
            {
                GenderData = new
                {
                    Hommes = veille.NombreHommes ?? 0,
                    Femmes = veille.NombreFemmes ?? 0,
                    Enfants = veille.NombreEnfants ?? 0,
                    MENA = veille.NombreMENA ?? 0
                },
                NationalityData = new
                {
                    Soudan = veille.NombreSoudan ?? 0,
                    SudSoudan = veille.NombreSudsoudan ?? 0,
                    Guinee = veille.NombreGuinee ?? 0,
                    Cameroun = veille.NombreCameroun ?? 0,
                    CotedIvoire = veille.NombreCotedIvoire ?? 0,
                    Mali = veille.NombreMali ?? 0,
                    Nigeria = veille.NombreNigeria ?? 0,
                    Senegal = veille.NombreSenegal ?? 0,
                    RDC = veille.NombreRDC ?? 0,
                    Autres = veille.NombreAutreNationalites ?? 0
                },
            };

            return Json(data);
        }

        public (string, int)[] GetTopNationalities(VeilleContextuelle veille)
        {
            var nationalities = new Dictionary<string, int>
                {
                    { "Soudan", veille.NombreSoudan ?? 0 },
                    { "Sud Soudan", veille.NombreSudsoudan ?? 0 },
                    { "Guinée", veille.NombreGuinee ?? 0 },
                    { "Cameroun", veille.NombreCameroun ?? 0 },
                    { "Côte d'Ivoire", veille.NombreCotedIvoire ?? 0 },
                    { "Mali", veille.NombreMali ?? 0 },
                    { "Nigeria", veille.NombreNigeria ?? 0 },
                    { "Sénégal", veille.NombreSenegal ?? 0 },
                    { "RDC", veille.NombreRDC ?? 0 },
                    { "Autres", veille.NombreAutreNationalites ?? 0 }
                };

            return nationalities
                .OrderByDescending(n => n.Value)
                .Take(3)
                .Select(n => (n.Key, n.Value))
                .ToArray();
        }
    }
}