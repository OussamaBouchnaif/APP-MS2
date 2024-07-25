using Admin.Mapper.Contract;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

namespace Admin.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
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
            var model = new BenificierVM
            {
                GeneratedCode = _beneficiaryService.GenerateUniqueSuffix()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BenificierVM benificierVM)
        {
            if (ModelState.IsValid)
            {
                benificierVM.codeUnique = benificierVM.PrefixCode + benificierVM.GeneratedCode;
                _beneficiaryService.AddBenificier(benificierVM);
                return Json(new { success = true });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
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
                return Json(new { success = true });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }

        public IActionResult Delete(int Id)
        {
            Benificier benificier = _beneficiaryService.GetBenificierById(Id);
            var result = _beneficiaryService.DeleteBenificier(benificier);
            if (result)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false, error = "La suppression a échoué." });
        }
    }
}