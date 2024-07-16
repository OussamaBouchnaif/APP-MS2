
using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service
{
    public class BenificierService : IBeneficiaryService
    {
        private readonly IRepository<Benificier> _BenificierRepository;
        private readonly IBenificierMapper _benificerMapper;

        public BenificierService(IRepository<Benificier> BenificierRepository ,IBenificierMapper benificierMapper)
        {
            _BenificierRepository = BenificierRepository;
            _benificerMapper = benificierMapper;
        }

        public IEnumerable<Benificier> GetAllBeneficiaries()
        {
            return _BenificierRepository.GetAll().ToList();
        }

        public Benificier GetBenificierById(int id)
        {
            return _BenificierRepository.FindById(id);
        }

        public Benificier FindBenificierByExpression(Expression<Func<Benificier, bool>> predicate)
        {
            return _BenificierRepository.FindByExpression(predicate);
        }

        public IEnumerable<Benificier> FindManyBeneficiariesByExpression(Expression<Func<Benificier, bool>> predicate)
        {
            return _BenificierRepository.FindManyByExpression(predicate).ToList();
        }

        public void AddBenificier(BenificierVM benificierVM)
        {
            if (benificierVM == null)
            {
                throw new ArgumentNullException(nameof(benificierVM));
            }
            Benificier benificier = _benificerMapper.MapToBenificier(benificierVM); 
            _BenificierRepository.Insert(benificier);
            SaveChanges();
        }

        public void UpdateBenificier( BenificierVM benificierVM, Benificier existingBenificier)
        {
            if (benificierVM == null || existingBenificier == null)
            {
                throw new ArgumentNullException(nameof(benificierVM));
            }

            _benificerMapper.UpdateBenificier(benificierVM, existingBenificier);

            _BenificierRepository.Update(existingBenificier);
            SaveChanges();
        }

        public void DeleteBenificier(int id)
        {
            var Benificier = _BenificierRepository.FindById(id);
            if (Benificier == null)
            {
                throw new ArgumentNullException(nameof(Benificier));
            }

            _BenificierRepository.Delete(Benificier);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _BenificierRepository.SaveChanges();
        }   
    }
}
