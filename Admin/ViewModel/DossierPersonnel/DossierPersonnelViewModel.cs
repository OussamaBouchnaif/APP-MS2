using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel.DossierPersonnel
{
    public class DossierPersonnelViewModel
    {
        int Id { get; set; }

        [Required(ErrorMessage = "Le lieu d'intervention est obligatoire.")]
        public string LieuxDintervention { get; set; }

        [Required(ErrorMessage = "L'identifiant du bénéficiaire est obligatoire.")]
        public int BenificierId { get; set; }

        public SituationFamilialeViewModel? Familiale { get; set; }
        public SituationAdministrativeViewModel? Administrative { get; set; }
        public ParcoursMigratoireViewModel? ParcoursMigratoire { get; set; }
        public SituationSocioEconomiqueViewModel? SocioEconomique { get; set; }
        public SituationPsychologiqueViewModel? Psychologique { get; set; }
        public SituationViolenceViewModel? Violence { get; set; }
    }
}
