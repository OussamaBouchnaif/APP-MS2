using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MS2Api.Model;

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

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BenificierVM benificierVM) 
        {
            if(ModelState.IsValid)
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
            return View(benificier);    
        }

        [HttpPost]
        public IActionResult Update(BenificierVM benificierVM,int Id)
        {
            Benificier benificier = _beneficiaryService.GetBenificierById(Id);
            if(ModelState.IsValid) 
            {
                _beneficiaryService.UpdateBenificier( benificierVM, benificier);
                return RedirectToAction(nameof(Index));
            }
            return View(benificier);
        }

        public IActionResult Delete(int Id) 
        {
            Benificier benificier = _beneficiaryService.GetBenificierById(Id);
            _beneficiaryService.DeleteBenificier(benificier);
            return RedirectToAction(nameof(Index));
        }
    }
}