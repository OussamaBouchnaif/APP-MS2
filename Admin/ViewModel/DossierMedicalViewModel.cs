using Admin.Models;
using MS2Api.Model;

namespace Admin.ViewModel
{
    public class DossierMedicalViewModel
    {
        public Benificier Benificier { get; set; }
        public List<DossierMedical> DossiersMedicaux { get; set; }
    }
}
