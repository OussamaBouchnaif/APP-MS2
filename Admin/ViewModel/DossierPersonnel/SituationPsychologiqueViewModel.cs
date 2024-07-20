namespace Admin.ViewModel.DossierPersonnel
{
    public class SituationPsychologiqueViewModel
    {
        public int Id { get; set; }
        public DateTime Enceinte { get; set; }
        public string? MaladieChronique { get; set; }
        public bool SituationDeDetresse { get; set; }
        public string? MaladieMentale { get; set; }
        public string? Autre { get; set; }
        public string? Handicap { get; set; }
        public int? DossierPersonnelId { get; set; }

    }
}
