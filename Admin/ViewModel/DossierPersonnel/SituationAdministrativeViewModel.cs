namespace Admin.ViewModel.DossierPersonnel
{
    public class SituationAdministrativeViewModel
    {
        public int Id { get; set; }
        public bool CarteMarocaine { get; set; }
        public bool ValidationPassport { get; set; }
        public bool CarteConsulaire { get; set; }
        public bool ActeDeNaissance { get; set; }
        public bool CarteSejourValid { get; set; }
        public bool StatusDeRefugie { get; set; }
        public bool RecepisseDedemande { get; set; }
        public bool Visa { get; set; }

        public int? DossierPersonnelId { get; set; }
    }
}
