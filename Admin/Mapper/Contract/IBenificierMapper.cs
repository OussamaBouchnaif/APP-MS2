using Admin.ViewModel;
using MS2Api.Model;

namespace Admin.Mapper.Contract
{
    public interface IBenificierMapper
    {
        Benificier MapToBenificier(BenificierVM benificierVm);

        Benificier UpdateBenificier(BenificierVM benificierVm, Benificier benificier);
    }
}
