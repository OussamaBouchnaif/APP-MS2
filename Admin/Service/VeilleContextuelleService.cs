using Admin.Flags;
using Admin.Mapper.Contract;
using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;

namespace Admin.Service
{
    public class VeilleContextuelleService : IVeilleContextuelleService
    {
        private readonly IRepository<VeilleContextuelle> _veilleContextuelleRepository;
        private readonly IVeilleContextuelleMapper _mapper;

        public VeilleContextuelleService(IRepository<VeilleContextuelle> veilleContextuelleRepository, IVeilleContextuelleMapper mapper)
        {
            this._veilleContextuelleRepository = veilleContextuelleRepository;
            _mapper = mapper;
        }

        public void AddVeille(VeilleContextuelleViewModel model, int[] sourceInformation, int[] typeMigrants, int[] nationalites)
        {
            var veille = _mapper.MapToEntity(model);
            veille.SourceInformation = (SourceInformation)sourceInformation.Aggregate(0, (current, value) => current | value);
            veille.TypeMigrants = (TypeMigrants)typeMigrants.Aggregate(0, (current, value) => current | value);
            veille.Nationalites = (Nationalites)nationalites.Aggregate(0, (current, value) => current | value);

            _veilleContextuelleRepository.Insert(veille);
            _veilleContextuelleRepository.SaveChanges();
        }

        public IEnumerable<VeilleContextuelle> GetAllVeilles()
        {
            return _veilleContextuelleRepository.GetAll().ToList();
        }
    }
}