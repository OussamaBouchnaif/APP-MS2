using Admin.ViewModel.DossierPersonnel;

namespace Admin.Service.Contract
{
    public interface IDossierService
    {
        void CreateDossierPersonnel(DossierPersonnelViewModel model);
    }
}
