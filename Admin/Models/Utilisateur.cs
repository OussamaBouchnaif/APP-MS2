using Admin.Models;

namespace MS2Api.Model
{
    public class Utilisateur : Personne
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; }

        public IList<VeilleContextuelle> veilleContextuelles { get; set; }
    }
}