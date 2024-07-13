using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service.Contract
{
    public interface IBeneficiaryService
    {
        IEnumerable<Benificier> GetAllBeneficiaries();
        Benificier GetBeneficiaryById(int id);
        Benificier FindBeneficiaryByExpression(Expression<Func<Benificier, bool>> predicate);
        IEnumerable<Benificier> FindManyBeneficiariesByExpression(Expression<Func<Benificier, bool>> predicate);
        void AddBeneficiary(Benificier beneficiary);
        void UpdateBeneficiary(Benificier beneficiary);
        void DeleteBeneficiary(int id);
        void SaveChanges();
    }
}
