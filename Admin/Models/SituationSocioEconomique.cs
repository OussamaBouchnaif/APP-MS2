using System.ComponentModel.DataAnnotations;

namespace MS2Api.Model
{
    public class SituationSocioEconomique
    {
        [Key]
        public int Id { get; set; }
        public string? NiveauEducation { get; set; }

        public string? FormationPersonnel { get; set;}
        public string ? Source { get; set; }
        public string? AutreSource { get; set; }
        public string? Habit{ get; set; }

        public string? AutreHabit { get; set; }
        public DossierPersonnel Dossier { get; set; }
        public int? DossierPersonnelId { get; set; }
    }
}
