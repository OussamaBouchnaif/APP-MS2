using Admin.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBeneficiaryService _beneficiaryService;

        public DashboardController(IBeneficiaryService beneficiaryService)
        {
            _beneficiaryService = beneficiaryService;
        }

        public async Task<IActionResult> Index()
        {
            var statistiques = await _beneficiaryService.GetStatistiquesAsync();

            if (statistiques == null)
            {
                return View("Error");
            }

            return View(statistiques);
        }
    }
}