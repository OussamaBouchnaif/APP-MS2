using Admin.Mapper.Contract;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.EntityFrameworkCore;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IRepository<Benificier> _benificierRepository;
        private readonly IBenificierMapper _benificierMapper;

        public BeneficiaryService(IRepository<Benificier> benificierRepository, IBenificierMapper benificierMapper)
        {
            _benificierRepository = benificierRepository;
            _benificierMapper = benificierMapper;
        }

        public IEnumerable<Benificier> GetAllBeneficiaries()
        {
            return _benificierRepository.GetAll().ToList();
        }

        public Benificier GetBenificierById(int id)
        {
            return _benificierRepository.FindById(id);
        }

        public Benificier FindBenificierByExpression(Expression<Func<Benificier, bool>> predicate)
        {
            return _benificierRepository.FindByExpression(predicate);
        }

        public IEnumerable<Benificier> FindManyBeneficiariesByExpression(Expression<Func<Benificier, bool>> predicate)
        {
            return _benificierRepository.FindManyByExpression(predicate).ToList();
        }

        public void AddBenificier(BenificierVM benificierVM)
        {
            if (benificierVM == null)
            {
                throw new ArgumentNullException(nameof(benificierVM));
            }
            Benificier benificier = _benificierMapper.MapToBenificier(benificierVM);
            _benificierRepository.Insert(benificier);
            SaveChanges();
        }

        public void UpdateBenificier(BenificierVM benificierVM, Benificier existingBenificier)
        {
            if (benificierVM == null || existingBenificier == null)
            {
                throw new ArgumentNullException(nameof(benificierVM));
            }

            _benificierMapper.UpdateBenificier(benificierVM, existingBenificier);

            _benificierRepository.Update(existingBenificier);
            SaveChanges();
        }

        public bool DeleteBenificier(Benificier benificier)
        {
            if (benificier == null)
            {
                throw new ArgumentNullException(nameof(benificier));
            }

            _benificierRepository.Delete(benificier);
            SaveChanges();
            return true;
        }

        public void SaveChanges()
        {
            _benificierRepository.SaveChanges();
        }

        public async Task<StatistiquesData> GetStatistiquesAsync()
        {
            var totalBeneficiaires = await _benificierRepository.GetAll().CountAsync();

            var hommes = await _benificierRepository.FindManyByExpression(b => b.Sexe == "Homme").CountAsync();
            var femmes = await _benificierRepository.FindManyByExpression(b => b.Sexe == "Femme").CountAsync();

            var mineurs = await _benificierRepository.FindManyByExpression(b => b.Age < 18).CountAsync();
            var nonMineurs = await _benificierRepository.FindManyByExpression(b => b.Age >= 18).CountAsync();

            var beneficiariesByNationality = await _benificierRepository.GetAll()
                .GroupBy(b => b.Nationalite)
                .Select(g => new
                {
                    Nationalite = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var beneficiariesPerNationality = beneficiariesByNationality.ToDictionary(x => x.Nationalite, x => x.Count);

            var beneficiariesByCity = await _benificierRepository.GetAll()
                .GroupBy(b => b.Ville)
                .Select(g => new
                {
                    Ville = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var beneficiariesPerCity = beneficiariesByCity.ToDictionary(x => x.Ville, x => x.Count);

            return new StatistiquesData
            {
                TotalBeneficiaires = totalBeneficiaires,
                NombreHommes = hommes,
                NombreFemmes = femmes,
                NombreMineurs = mineurs,
                NombreNonMineurs = nonMineurs,
                BeneficiariesPerNationality = beneficiariesPerNationality,
                BeneficiariesPerCity = beneficiariesPerCity,
                Beneficiaries = await _benificierRepository.GetAll().ToListAsync() // Inclure les bénéficiaires dans les statistiques
            };
        }

        string IBeneficiaryService.GenerateUniqueSuffix()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        public Benificier FindByCodeUnique(string codeUnique)
        {
            return _benificierRepository.FindByExpression(b => b.codeUnique == codeUnique);
        }
    }
}