using System.ComponentModel.DataAnnotations;

namespace MS2Api.Model
{
    public class SituationFamiliale
    {
        [Key]
        public int Id { get; set; }

        public bool? Mineur { get; set; }
        public bool? Accompagne { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public string? Contact { get; set; }

        public string? SituationMatrimoniale { get; set; }
        public bool? EnfantAcharge { get; set; }
        public int? Nombre { get; set; }
        public int? Age { get; set; }

        public DossierPersonnel Dossier { get; set; }
        public int? DossierPersonnelId { get; set; }


    }
}
