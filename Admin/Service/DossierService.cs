using Admin.Builder;
using Admin.Builder.Contract;
using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel.DossierPersonnel;
using Microsoft.EntityFrameworkCore;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service
{
    public class DossierService: IDossierService
    {
        private readonly IRepository<DossierPersonnel> _repository;
        private readonly IRepository<Benificier> _benificierRepository;
        private readonly IDossierMapper _dossierMapper;
        private readonly IDossierPersonnelBuilder _builder;

        public DossierService(
            IRepository<DossierPersonnel> repository,
            IRepository<Benificier> benificierRepository,
            IDossierMapper dossierMapper,
            IDossierPersonnelBuilder builder
            )
        {
            _repository = repository;
            _benificierRepository = benificierRepository;
            _dossierMapper = dossierMapper;
            _builder = builder;

        }

        public void CreateDossierPersonnel(DossierPersonnelViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var benificier = _benificierRepository.FindById(model.BenificierId);

            if (benificier == null) throw new InvalidOperationException("Bénéficiaire introuvable");

            _builder.SetLieuxDintervention(model.LieuxDintervention)
                .SetBenificier(benificier)
                .SetFamiliale(_dossierMapper.MapToSituationFamiliale(model.Familiale))
                .SetAdministrative(_dossierMapper.MapToSituationAdministrative(model.Administrative))
                .SetParcoursMigratoire(_dossierMapper.MapToParcoursMigratoire(model.ParcoursMigratoire))
                .SetSocioEconomique(_dossierMapper.MapToSituationSocioEconomique(model.SocioEconomique))
                .SetPsychologique(_dossierMapper.MapToSituationPsychologique(model.Psychologique))
                .SetViolence(_dossierMapper.MapToSituationViolence(model.Violence));

            var dossierPersonnel = _builder.Build();
            if (dossierPersonnel == null) throw new InvalidOperationException("Dossier personnel non créé");
            _repository.Insert(dossierPersonnel);
            _repository.SaveChanges();

        }

        public DossierPersonnel GetDossierPersonnel(int beneficiaryId)
        {
            if (beneficiaryId <= 0) throw new ArgumentException("Invalid beneficiary ID", nameof(beneficiaryId));

            var dossierPersonnel = _repository.GetAll()
                .Include(d => d.Benificier)
                .Include(d => d.Familiale)
                .Include(d => d.Administrative)
                .Include(d => d.ParcoursMigratoire)
                .Include(d => d.SocioEconomique)
                .Include(d => d.Psychologique)
                .Include(d => d.Violence)
                .FirstOrDefault(d => d.Benificier.Id == beneficiaryId);

            

            return dossierPersonnel;
        }
    
    }
}
