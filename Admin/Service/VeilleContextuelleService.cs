using Admin.Enums;
using Admin.Flags;
using Admin.Mapper;
using Admin.Mapper.Contract;
using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewModel;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<VeilleContextuelleViewModel> GetFilteredVeilles()
        {
            return _veilleContextuelleRepository.GetAll()
                .Select(v => new VeilleContextuelleViewModel
                {
                    Id = v.Id,
                    DateEvenement = v.DateEvenement,
                    TypeEvenement = v.TypeEvenement,
                    SourceInformation = v.SourceInformation,
                    DetailsEvenement = v.DetailsEvenement,
                    VerificationStatus = v.VerificationStatus,
                }).ToList();
        }

        public IEnumerable<VeilleContextuelle> GetAllVeilles()
        {
            return _veilleContextuelleRepository.GetAll().ToList();
        }

        public void UpdateVerificationStatus(int veilleId, VerificationStatus status)
        {
            var veille = _veilleContextuelleRepository.FindById(veilleId);
            if (veille != null)
            {
                veille.VerificationStatus = status;
                _veilleContextuelleRepository.Update(veille);
                _veilleContextuelleRepository.SaveChanges();
            }
        }

        public VeilleContextuelle GetVeilleById(int id)
        {
            var veille = _veilleContextuelleRepository.GetAll()
            .Include(v => v.Utilisateur)
            .FirstOrDefault(v => v.Id == id);

            if (veille == null)
                return null;
            return veille;
        }

        public (string, int)[] GetTopNationalities(VeilleContextuelle veille)
        {
            var nationalities = new Dictionary<string, int>
                {
                    { "Soudan", veille.NombreSoudan ?? 0 },
                    { "Sud Soudan", veille.NombreSudsoudan ?? 0 },
                    { "Guinée", veille.NombreGuinee ?? 0 },
                    { "Cameroun", veille.NombreCameroun ?? 0 },
                    { "Côte d'Ivoire", veille.NombreCotedIvoire ?? 0 },
                    { "Mali", veille.NombreMali ?? 0 },
                    { "Nigeria", veille.NombreNigeria ?? 0 },
                    { "Sénégal", veille.NombreSenegal ?? 0 },
                    { "RDC", veille.NombreRDC ?? 0 },
                    { "Autres", veille.NombreAutreNationalites ?? 0 }
                };

            return nationalities
                .OrderByDescending(n => n.Value)
                .Take(3)
                .Select(n => (n.Key, n.Value))
                .ToArray();
        }
    }
}