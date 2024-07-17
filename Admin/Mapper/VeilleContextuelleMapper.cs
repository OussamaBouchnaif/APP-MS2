using Admin.Mapper.Contract;
using Admin.Models;
using Admin.ViewModel;
using IdentityModel;

namespace Admin.Mapper
{
    public class VeilleContextuelleMapper : IVeilleContextuelleMapper
    {
        public VeilleContextuelle MapToEntity(VeilleContextuelleViewModel model)
        {
            return new VeilleContextuelle
            {
                Id = model.Id,
                DateEvenement = DateTime.Now,
                TypeEvenement = model.TypeEvenement,
                DetailsEvenement = model.DetailsEvenement,
                SourceInformation = model.SourceInformation,
                AutresSourceInformation = model.AutresSourceInformation,
                NombreMigrants = model.NombreMigrants,
                TypeMigrants = model.TypeMigrants,
                Nationalites = model.Nationalites,
                AutresNationalites = model.AutresNationalites,
                UtilisateurId = model.UtilisateurId,
                NombreHommes = model.NombreHommes,
                NombreFemmes = model.NombreFemmes,
                NombreMENA = model.NombreMENA,
                NombreEnfants = model.NombreEnfants,
                NombreSoudan = model.NombreSoudan,
                NombreSudsoudan = model.NombreSudsoudan,
                NombreGuinee = model.NombreGuinee,
                NombreCameroun = model.NombreCameroun,
                NombreCotedIvoire = model.NombreCotedIvoire,
                NombreMali = model.NombreMali,
                NombreNigeria = model.NombreNigeria,
                NombreSenegal = model.NombreSenegal,
                NombreRDC = model.NombreRDC,
                NombreAutreNationalites = model.NombreAutreNationalites,
                VerificationStatus = model.VerificationStatus
            };
        }

        public VeilleContextuelleViewModel MapToViewModel(VeilleContextuelle entity)
        {
            return new VeilleContextuelleViewModel
            {
                Id = entity.Id,
                DateEvenement = entity.DateEvenement,
                TypeEvenement = entity.TypeEvenement,
                DetailsEvenement = entity.DetailsEvenement,
                SourceInformation = entity.SourceInformation,
                AutresSourceInformation = entity.AutresSourceInformation,
                NombreMigrants = entity.NombreMigrants,
                TypeMigrants = entity.TypeMigrants,
                Nationalites = entity.Nationalites,
                AutresNationalites = entity.AutresNationalites,
                UtilisateurId = entity.UtilisateurId,
                NombreHommes = entity.NombreHommes,
                NombreFemmes = entity.NombreFemmes,
                NombreMENA = entity.NombreMENA,
                NombreEnfants = entity.NombreEnfants,
                NombreSoudan = entity.NombreSoudan,
                NombreSudsoudan = entity.NombreSudsoudan,
                NombreGuinee = entity.NombreGuinee,
                NombreCameroun = entity.NombreCameroun,
                NombreCotedIvoire = entity.NombreCotedIvoire,
                NombreMali = entity.NombreMali,
                NombreNigeria = entity.NombreNigeria,
                NombreSenegal = entity.NombreSenegal,
                NombreRDC = entity.NombreRDC,
                NombreAutreNationalites = entity.NombreAutreNationalites,
                VerificationStatus = entity.VerificationStatus
            };
        }
    }
}