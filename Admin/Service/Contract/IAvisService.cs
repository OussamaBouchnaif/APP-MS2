using Admin.Models;

namespace Admin.Service.Contract
{
    public interface IAvisService
    {
        IEnumerable<Avis> GetAllAvis();

        Avis GetLastAvis();
        void AddAvis(Avis avis);
    }
}