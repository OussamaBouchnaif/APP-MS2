using Admin.Enums;
using Admin.Models;
using Admin.ViewModel;

namespace Admin.Service.Contract
{
    public interface IVeilleContextuelleService
    {
        IEnumerable<VeilleContextuelle> GetAllVeilles();

        void AddVeille(VeilleContextuelleViewModel model, int[] sourceInformation, int[] typeMigrants, int[] nationalites);

        IEnumerable<VeilleContextuelleViewModel> GetFilteredVeilles();

        void UpdateVerificationStatus(int veilleId, VerificationStatus status);

        VeilleContextuelle GetVeilleById(int id);

        (string, int)[] GetTopNationalities(VeilleContextuelle veille);
    }
}