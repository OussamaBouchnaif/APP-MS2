using Admin.Enums;
using Admin.Flags;
using IdentityServer4.Models;
using MS2Api.Model;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class VeilleContextuelle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateEvenement { get; set; }

        [Required]
        public TypeEvenement TypeEvenement { get; set; }

        [StringLength(255)]
        public string DetailsEvenement { get; set; }

        [Required]
        public SourceInformation SourceInformation { get; set; }

        [StringLength(255)]
        public string? AutresSourceInformation { get; set; }

        [Required]
        [Range(10, 200, ErrorMessage = "Le nombre de migrants doit être un multiple de 10 entre 10 et 200")]
        public int NombreMigrants { get; set; }

        [Required]
        public TypeMigrants TypeMigrants { get; set; }

        [Required]
        public Nationalites Nationalites { get; set; }

        [StringLength(255)]
        public string? AutresNationalites { get; set; }

        public Utilisateur Utilisateur { get; set; }
        public int UtilisateurId { get; set; }

        [Required]
        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.CinquanteCinquante;

        public int? NombreHommes { get; set; }
        public int? NombreFemmes { get; set; }
        public int? NombreMENA { get; set; }
        public int? NombreEnfants { get; set; }

        public int? NombreSoudan { get; set; }
        public int? NombreSudsoudan { get; set; }
        public int? NombreGuinee { get; set; }
        public int? NombreCameroun { get; set; }
        public int? NombreCotedIvoire { get; set; }
        public int? NombreMali { get; set; }
        public int? NombreNigeria { get; set; }
        public int? NombreSenegal { get; set; }
        public int? NombreRDC { get; set; }
        public int? NombreAutreNationalites { get; set; }
    }
}