using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS2Api.Model
{
    public abstract class Personne
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom{ get; set; }
        public int Age {  get; set; }

        public string Sexe {  get; set; }
        public string Tele { get; set; }
        
    }
}
