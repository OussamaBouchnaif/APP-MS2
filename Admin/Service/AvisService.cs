using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Microsoft.EntityFrameworkCore;

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
    }
}