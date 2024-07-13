
using Admin.Repository;
using Admin.Service.Contract;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service
{
    public class BenificierService : IBeneficiaryService
    {
        private readonly IRepository<Benificier> _BenificierRepository;

        public BenificierService(IRepository<Benificier> BenificierRepository)
        {
            _BenificierRepository = BenificierRepository;
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

        public void AddBenificier(Benificier Benificier)
        {
            if (Benificier == null)
            {
                throw new ArgumentNullException(nameof(Benificier));
            }

            _BenificierRepository.Insert(Benificier);
            SaveChanges();
        }

        public void UpdateBenificier(Benificier Benificier)
        {
            if (Benificier == null)
            {
                throw new ArgumentNullException(nameof(Benificier));
            }

            _BenificierRepository.Update(Benificier);
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

        public Benificier GetBeneficiaryById(int id)
        {
            throw new NotImplementedException();
        }

        public Benificier FindBeneficiaryByExpression(Expression<Func<Benificier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddBeneficiary(Benificier beneficiary)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeneficiary(Benificier beneficiary)
        {
            throw new NotImplementedException();
        }

        public void DeleteBeneficiary(int id)
        {
            throw new NotImplementedException();
        }
    }
}
