using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class SocialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddDossierSocial(int BeneficiaryId)
        {
            ViewData["Id"] = BeneficiaryId;
            return View();
        }
    }
}