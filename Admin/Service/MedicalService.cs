using Admin.Mapper.Contract;
using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using MS2Api.Model;

namespace Admin.Service
{
    public class MedicalService : IMedicalService
    {

        private readonly IRepository<DossierMedical> _medicalRepository;
        private readonly IMedicalMapper _medicalMapper;
        private readonly IRepository<Benificier> _benificierRepository;

        public MedicalService(IRepository<DossierMedical> repository, IMedicalMapper medicalMapper, IRepository<Benificier> benificierRepository)
        {
            _medicalRepository = repository;
            _medicalMapper = medicalMapper;
            _benificierRepository = benificierRepository;
        }

        public void AddDossierMedical(DossierMedicalVM medicalVM)
        {
            if (medicalVM == null)
            {
                throw new ArgumentNullException(nameof(medicalVM));
            }
            DossierMedical medical = _medicalMapper.MapToDossierMedical(medicalVM);
            _medicalRepository.Insert(medical);
            SaveChanges();
        }

        public DossierMedical GetBenificierById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _medicalRepository.SaveChanges();
        }

        public void UpdateDossierMedical(DossierMedicalVM medicalVM, DossierMedical medical)
        {
            throw new NotImplementedException();
        }
    }
}
