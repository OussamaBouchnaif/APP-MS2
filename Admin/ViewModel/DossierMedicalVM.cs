using MS2Api.Model;

namespace Admin.ViewModel
{
    public class DossierMedicalVM
    {
        public int Id { get; set; }
        public string? StructureType { get; set; }
        public string? PerformedService { get; set; }

        public bool IsPublic { get; set; }
        public string? StructureName { get; set; }
        public string? MotifAcoompagnement { get; set; }
        public string? PresentationEffectueé { get; set; }
        public decimal? Prix { get; set; }
        public string? Commentaires { get; set; }
        public string? Responsable { get; set; }
        public string? SignatureBenificier { get; set; }
        public int BenificierId { get; set; }
        public DateTime? Date { get; set; }
    }
}
