namespace Admin.ViewModel.DossierPersonnel
{
    public class SituationSocioEconomiqueViewModel
    {
        public int Id { get; set; }
        public string? NiveauEducation { get; set; }

        public string? FormationPersonnel { get; set; }
        public string? Source { get; set; }
        public string? Habit { get; set; }

        public int? DossierPersonnelId { get; set; }
    }
}
