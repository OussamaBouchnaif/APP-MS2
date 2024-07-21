using MS2Api.Model;

namespace Admin.Builder.Contract
{
    public interface IDossierPersonnelBuilder
    {
        DossierPersonnelBuilder SetLieuxDintervention(string lieux);

        DossierPersonnelBuilder SetFamiliale(SituationFamiliale familiale);

        DossierPersonnelBuilder SetAdministrative(SituationAdministrative administrative);

        DossierPersonnelBuilder SetParcoursMigratoire(ParcoursMigratoire parcoursMigratoire);

        DossierPersonnelBuilder SetSocioEconomique(SituationSocioEconomique socioEconomique);

        DossierPersonnelBuilder SetPsychologique(SituationPsychologique psychologique);

        DossierPersonnelBuilder SetViolence(SituationViolence violence);

        DossierPersonnelBuilder SetBenificier(Benificier benificier);

        DossierPersonnel Build();
    }
}