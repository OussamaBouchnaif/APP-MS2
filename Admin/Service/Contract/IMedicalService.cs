using Admin.Models;
using Admin.ViewModel;

namespace Admin.Service.Contract
{
    public interface IMedicalService
    {
        List<DossierMedical> GetDossierMedicalById(int id);
        void AddDossierMedical(DossierMedicalVM medicalVM);
        void UpdateDossierMedical(DossierMedicalVM medicalVM, DossierMedical medical);
        void SaveChanges();
    }
}
