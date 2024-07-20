using System.ComponentModel.DataAnnotations;

namespace MS2Api.Model
{
    public class SituationAdministrative
    {
        [Key]
        public int Id { get; set; }
        public bool? CarteMarocaine { get; set; }
        public string? Autre { get; set; }
        public bool? ValidationPassport { get; set; }
        public bool? CarteConsulaire { get; set; }
        public bool? ActeDeNaissance { get; set; }
        public bool? AucunPiece { get; set; }
        public bool? CarteSejourValid { get; set; }
        public bool? StatusDeRefugie { get; set; }
        public bool? RecepisseDedemande { get; set; }
        public bool? Visa { get; set; }
        public bool? AucunTite {  get; set; }

        public DossierPersonnel Dossier { get; set; }
        public int? DossierPersonnelId { get; set; }


    }
}
