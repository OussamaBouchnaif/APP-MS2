using MS2Api.Model;

namespace Admin.Builder
{
    public class DossierPersonnelBuilder
    {
        private DossierPersonnel _dossierPersonnel;

        public DossierPersonnelBuilder()
        {
            _dossierPersonnel = new DossierPersonnel();
        }

        public DossierPersonnelBuilder SetLieuxDintervention(string lieux)
        {
            _dossierPersonnel.LieuxDintervention = lieux;
            return this;
        }

        public DossierPersonnelBuilder SetFamiliale(SituationFamiliale familiale)
        {
            _dossierPersonnel.Familiale = familiale ;
            return this;
        }

        public DossierPersonnelBuilder SetAdministrative(SituationAdministrative administrative)
        {
            _dossierPersonnel.Administrative = administrative;
            return this;
        }

        public DossierPersonnelBuilder SetParcoursMigratoire(ParcoursMigratoire parcoursMigratoire)
        {
            _dossierPersonnel.ParcoursMigratoire = parcoursMigratoire;
            return this;
        }

        public DossierPersonnelBuilder SetSocioEconomique(SituationSocioEconomique socioEconomique)
        {
            _dossierPersonnel.SocioEconomique = socioEconomique;
            return this;
        }

        public DossierPersonnelBuilder SetPsychologique(SituationPsychologique psychologique)
        {
            _dossierPersonnel.Psychologique = psychologique;
            return this;
        }

        public DossierPersonnelBuilder SetViolence(SituationViolence violence)
        {
            _dossierPersonnel.Violence = violence;
            return this;
        }

        public DossierPersonnelBuilder SetBenificier(Benificier benificier)
        {
            _dossierPersonnel.Benificier = benificier;
            _dossierPersonnel.BenificierId = benificier.Id;
            return this;
        }

        public DossierPersonnel Build()
        {
            _dossierPersonnel.CreatedAt = DateTime.UtcNow;
            return _dossierPersonnel;
        }
    }
}
