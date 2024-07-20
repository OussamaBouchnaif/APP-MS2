using Admin.Builder;
using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel.DossierPersonnel;
using MS2Api.Model;

namespace Admin.Service
{
    public class DossierService: IDossierService
    {
        private readonly IRepository<DossierPersonnel> _repository;
        private readonly IRepository<Benificier> _benificierRepository;
        private readonly IDossierMapper _dossierMapper;

        public DossierService(IRepository<DossierPersonnel> repository, IRepository<Benificier> benificierRepository,IDossierMapper dossierMapper)
        {
            _repository = repository;
            _benificierRepository = benificierRepository;
            _dossierMapper = dossierMapper;
        }

        public void CreateDossierPersonnel(DossierPersonnelViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var benificier = _benificierRepository.FindById(model.BenificierId);

            if (benificier == null) throw new InvalidOperationException("Bénéficiaire introuvable");

            var builder = new DossierPersonnelBuilder()
                .SetLieuxDintervention(model.LieuxDintervention)
                .SetBenificier(benificier)
                .SetFamiliale( _dossierMapper.MapToSituationFamiliale(model.Familiale))
                .SetAdministrative(_dossierMapper.MapToSituationAdministrative(model.Administrative))
                .SetParcoursMigratoire(_dossierMapper.MapToParcoursMigratoire(model.ParcoursMigratoire))
                .SetSocioEconomique(_dossierMapper.MapToSituationSocioEconomique(model.SocioEconomique));
            //.SetPsychologique(model.Psychologique != null ? new SituationPsychologique { /* map properties */ } : null)
            //.SetViolence(model.Violence != null ? new SituationViolence { /* map properties */ } : null)

            var dossierPersonnel = builder.Build();
            if (dossierPersonnel == null) throw new InvalidOperationException("Dossier personnel non créé");
            _repository.Insert(dossierPersonnel);
            _repository.SaveChanges();

        }
    }
}
