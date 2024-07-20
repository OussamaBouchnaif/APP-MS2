namespace Admin.ViewModel.DossierPersonnel
{
    public class SituationViolenceViewModel
    {
        public int Id { get; set; }
        public string? Victim { get; set; }
        public bool Indicateur { get; set; }
        public bool VictimArretation { get; set; }
        public string? Victimrefoulement { get; set; }

        public int? DossierPersonnelId { get; set; }
    }
}
