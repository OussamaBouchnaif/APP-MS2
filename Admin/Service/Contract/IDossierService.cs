using Admin.ViewModel.DossierPersonnel;
using IdentityModel;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service.Contract
{
    public interface IDossierService
    {
        void CreateDossierPersonnel(DossierPersonnelViewModel model);
        DossierPersonnel GetDossierPersonnel(int beneficiaryId);
    }
}
