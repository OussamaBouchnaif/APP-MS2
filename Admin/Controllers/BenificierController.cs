using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin, Agent")]
    public class BenificierController : Controller
    {
        private readonly IBeneficiaryService _beneficiaryService;

        public BenificierController(IBeneficiaryService beneficiaryService)
        {
            _beneficiaryService = beneficiaryService;
        }

        public IActionResult Index()
        {
            var beneficiaries = _beneficiaryService.GetAllBeneficiaries();

            return View(beneficiaries);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BenificierVM benificierVM)
        {
            if (ModelState.IsValid)
            {
                _beneficiaryService.AddBenificier(benificierVM);
                return RedirectToAction(nameof(Index));
            }

            return View(benificierVM);
        }
    }
}