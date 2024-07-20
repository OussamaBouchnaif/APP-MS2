using Admin.Mapper.Contract;
using Admin.ViewModel.DossierPersonnel;
using MS2Api.Model;

namespace Admin.Mapper
{
    public class DossierMapper : IDossierMapper
    {
        public SituationFamiliale MapToSituationFamiliale(SituationFamilialeViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return new SituationFamiliale
            {
                Id = viewModel.Id,
                Mineur = viewModel.Mineur,
                Accompagne = viewModel.Accompagne,
                Name = viewModel.Name,
                Link = viewModel.Link,
                Contact = viewModel.Contact,
                SituationMatrimoniale = viewModel.SituationMatrimoniale,
                EnfantAcharge = viewModel.EnfantAcharge,
                Nombre = viewModel.Nombre,
                Age = viewModel.Age,
                DossierPersonnelId = viewModel.DossierPersonnelId
                // Map other properties as needed
            };
        }

        public SituationAdministrative MapToSituationAdministrative(SituationAdministrativeViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return new SituationAdministrative
            {
                Id = viewModel.Id,
                CarteMarocaine = viewModel.CarteMarocaine,
                ValidationPassport = viewModel.ValidationPassport,
                CarteConsulaire = viewModel.CarteConsulaire,
                ActeDeNaissance = viewModel.ActeDeNaissance,
                CarteSejourValid = viewModel.CarteSejourValid,
                StatusDeRefugie = viewModel.StatusDeRefugie,
                RecepisseDedemande = viewModel.RecepisseDedemande,
                Visa = viewModel.Visa,
                DossierPersonnelId = viewModel.DossierPersonnelId
                // Map other properties as needed
            };
        }

        public ParcoursMigratoire MapToParcoursMigratoire(ParcoursMigratoireViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return new ParcoursMigratoire
            {
                Id = viewModel.Id,
                MotifDepart = viewModel.MotifDepart,
                AnneeEntree = viewModel.AnneeEntree,
                Voie = viewModel.Voie,
                VilleEntree = viewModel.VilleEntree,
                Duree = viewModel.Duree,
                DureeEntree = viewModel.DureeEntree,
                NouvelleArrivante = viewModel.NouvelleArrivante,
                DossierPersonnelId = viewModel.DossierPersonnelId
                // Map other properties as needed
            };
        }

        public SituationSocioEconomique MapToSituationSocioEconomique(SituationSocioEconomiqueViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return new SituationSocioEconomique
            {
                Id = viewModel.Id,
                NiveauEducation = viewModel.NiveauEducation,
                FormationPersonnel = viewModel.FormationPersonnel,
                Source = viewModel.Source,
                Habit = viewModel.Habit,
                DossierPersonnelId = viewModel.DossierPersonnelId
                // Map other properties as needed
            };
        }

    }
}
