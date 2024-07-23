using Admin.Mapper.Contract;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

namespace Admin.Controllers
{
    //[ServiceFilter(typeof(AuthenticationFilter))]
    public class BenificierController : Controller
    {
        private readonly IBeneficiaryService _beneficiaryService;
        private readonly IBenificierMapper _benificierMapper;

        public BenificierController(IBeneficiaryService beneficiaryService, IBenificierMapper benificierMapper)
        {
            _beneficiaryService = beneficiaryService;
            _benificierMapper = benificierMapper;
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

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Benificier benificier = _beneficiaryService.GetBenificierById(Id);
            var benificierVM = _benificierMapper.MapToBenificierVM(benificier);
            return View(benificierVM);
        }

        [HttpPost]
        public IActionResult Update(BenificierVM benificierVM, int Id)
        {
            Benificier benificier = _beneficiaryService.GetBenificierById(Id);
            if (ModelState.IsValid)
            {
                _beneficiaryService.UpdateBenificier(benificierVM, benificier);
                return RedirectToAction(nameof(Index));
            }
            return View(benificierVM);
        }

        public IActionResult Delete(int Id)
        {
            Benificier benificier = _beneficiaryService.GetBenificierById(Id);
            _beneficiaryService.DeleteBenificier(benificier);
            return RedirectToAction(nameof(Index));
        }
    }
}