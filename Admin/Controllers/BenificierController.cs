using Admin.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
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
    }
}