using Admin.ViewModel.DossierPersonnel;
using MS2Api.Model;

namespace Admin.Mapper.Contract
{
    public interface IDossierMapper
    {
        SituationFamiliale MapToSituationFamiliale(SituationFamilialeViewModel viewModel);
        SituationAdministrative MapToSituationAdministrative(SituationAdministrativeViewModel viewModel);
        ParcoursMigratoire MapToParcoursMigratoire(ParcoursMigratoireViewModel viewModel);
        SituationSocioEconomique MapToSituationSocioEconomique(SituationSocioEconomiqueViewModel viewModel);
    }
}
