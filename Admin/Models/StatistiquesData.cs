namespace MS2Api.Model
{
    public class StatistiquesData
    {
        public int TotalBeneficiaires { get; set; }
        public int NombreHommes { get; set; }
        public int NombreFemmes { get; set; }
        public int NombreMineurs { get; set; }
        public int NombreNonMineurs { get; set; }
        public Dictionary<string, int> BeneficiariesPerNationality { get; set; }
        public IEnumerable<Benificier> Beneficiaries { get; set; }
        public IEnumerable<Utilisateur> Utilisateurs { get; set; } // Assurez-vous que ce champ est nécessaire ou peut être retiré si non utilisé
        public List<Utilisateur> Agents { get; set; }
        public Dictionary<string, int> BeneficiariesPerCity { get; set; }
    }
}