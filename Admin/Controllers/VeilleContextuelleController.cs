using Admin.Repository;
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

        public VeilleContextuelleController(IVeilleContextuelleService veilleContextuelleService, IHttpContextAccessor httpContextAccessor)
        {
            this.veilleContextuelleService = veilleContextuelleService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var veilleList = veilleContextuelleService.GetAllVeilles();
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
                return RedirectToAction("Index");
            }
            var user = httpContextAccessor.HttpContext.Session.GetObjectFromJson<Utilisateur>("User");
            model.UtilisateurId = user.Id;
            return View(model);
        }
    }
}