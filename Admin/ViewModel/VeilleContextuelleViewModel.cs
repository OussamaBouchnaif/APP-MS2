using Admin.Enums;
using Admin.Flags;
using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace Admin.ViewModel
{
    public class VeilleContextuelleViewModel
    {
        [Key]
        public int Id { get; set; }

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
        public int NombreMigrants { get; set; }

        [Required]
        public TypeMigrants TypeMigrants { get; set; }

        [Required]
        public Nationalites Nationalites { get; set; }

        [StringLength(255)]
        public string? AutresNationalites { get; set; }

        public int UtilisateurId { get; set; }

        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Rejete;

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