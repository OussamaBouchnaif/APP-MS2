using Admin.Models;
using Admin.ViewModel;

namespace Admin.Mapper.Contract
{
    public interface IMedicalMapper
    {
        DossierMedical MapToDossierMedical(DossierMedicalVM viewModel);
    }
}
