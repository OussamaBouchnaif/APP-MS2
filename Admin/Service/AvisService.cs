using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Microsoft.EntityFrameworkCore;
using MS2Api.Data;

namespace Admin.Service
{
    public class AvisService : IAvisService
    {
        private readonly IRepository<Avis> _avisRepository;

        public AvisService(IRepository<Avis> avisRepository)
        {
            _avisRepository = avisRepository;
        }

        public IEnumerable<Avis> GetAllAvis()
        {
            return _avisRepository.GetAll()
                .Include(a => a.Benificier)
                .OrderByDescending(a => a.DateTime)
                .ToList();
        }

        public Avis GetLastAvis()
        {
            return _avisRepository.GetAll()
                .Include(a => a.Benificier)
                .OrderByDescending(a => a.DateTime)
                .FirstOrDefault();
        }

        public void AddAvis(Avis avis)
        {
            _avisRepository.Insert(avis);
            _avisRepository.SaveChanges();
        }

        public IEnumerable<Avis> GetAvisByBeneficiaryId(int beneficiaryId)
        {
            return _avisRepository.FindManyByExpression(a => a.BenificierId == beneficiaryId).Include(a => a.Benificier).ToList();
        }

        public Avis GetAvisById(int id)
        {
            return _avisRepository.FindById(id);
        }

        public void DeleteAvis(Avis avis)
        {
            _avisRepository.Delete(avis);
            _avisRepository.SaveChanges();
        }
    }
}