using Admin.Models;
using Admin.ViewModel;

namespace Admin.Service.Contract
{
    public interface IMedicalService
    {
        DossierMedical GetBenificierById(int id);
        void AddDossierMedical(DossierMedicalVM medicalVM);
        void UpdateDossierMedical(DossierMedicalVM medicalVM, DossierMedical medical);
        void SaveChanges();
    }
}
