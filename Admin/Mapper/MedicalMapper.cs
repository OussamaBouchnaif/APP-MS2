using Admin.Mapper.Contract;
using Admin.Models;
using Admin.ViewModel;

namespace Admin.Mapper
{
    public class MedicalMapper : IMedicalMapper
    {
        public DossierMedical MapToDossierMedical(DossierMedicalVM viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            return new DossierMedical
            {
                Id = viewModel.Id,
                StructureType = viewModel.StructureType,
                PerformedService = viewModel.PerformedService,
                IsPublic = viewModel.IsPublic,
                StructureName = viewModel.StructureName,
                MotifAcoompagnement = viewModel.MotifAcoompagnement,
                PresentationEffectueé = viewModel.PresentationEffectueé,
                Prix = viewModel.Prix ?? 0,
                Commentaires = viewModel.Commentaires,
                Responsable = viewModel.Responsable,
                SignatureBenificier = viewModel.SignatureBenificier,
                BenificierId = viewModel.BenificierId,
                Date = viewModel.Date ?? DateTime.MinValue
            };
        }
    }
}
