using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel.DossierPersonnel
{
    public class DossierPersonnelViewModel
    {
        int Id { get; set; }
        [Required]
        public string LieuxDintervention { get; set; }
        [Required]
        public int BenificierId { get; set; }
        public SituationFamilialeViewModel? Familiale { get; set; }
        public SituationAdministrativeViewModel? Administrative { get; set; }
        public ParcoursMigratoireViewModel? ParcoursMigratoire { get; set; }
        public SituationSocioEconomiqueViewModel? SocioEconomique { get; set; }
        public SituationPsychologiqueViewModel? Psychologique { get; set; }
        public SituationViolenceViewModel? Violence { get; set; }
    }
}
