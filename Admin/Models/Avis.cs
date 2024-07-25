using MS2Api.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    public class Avis
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Contenue { get; set; }

        public Benificier Benificier { get; set; }

        public int BenificierId { get; set; }
    }
}