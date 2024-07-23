using System.ComponentModel.DataAnnotations;

namespace MS2Api.Model
{
    public class SituationViolence
    {
        [Key]
        public int Id { get; set; }

        public string? Victim { get; set; }
        public bool? Indicateur { get; set; }
        public bool? VictimArretation { get; set; }
        public string? Victimrefoulement { get; set; }

        public DossierPersonnel Dossier { get; set; }
        public int? DossierPersonnelId { get; set; }
    }
}