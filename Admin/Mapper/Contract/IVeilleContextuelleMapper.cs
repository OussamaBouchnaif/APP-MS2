using Admin.Models;
using Admin.ViewModel;

namespace Admin.Mapper.Contract
{
    public interface IVeilleContextuelleMapper
    {
        VeilleContextuelle MapToEntity(VeilleContextuelleViewModel model);

        VeilleContextuelleViewModel MapToViewModel(VeilleContextuelle entity);
    }
}