using System.ComponentModel.DataAnnotations;

namespace MS2Api.Model
{
    public class DossierPersonnel
    {
        [Key]
        public int Id {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LieuxDintervention { get; set; }

        public SituationFamiliale? Familiale { get; set; }
        public SituationAdministrative? Administrative { get; set; }
        public ParcoursMigratoire? ParcoursMigratoire { get; set; }
        public SituationSocioEconomique? SocioEconomique { get; set; }
        public SituationPsychologique? Psychologique { get; set;}
        public SituationViolence? Violence { get; set; }

        public Benificier Benificier { get; set; }
        public int BenificierId { get; set; }
    }
}
