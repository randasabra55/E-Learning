using E_Learning_Core.Features.Certifications.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.CertificationMapping
{
    public partial class CertificationProfile
    {
        public void EditCertificationMapping()
        {
            CreateMap<EditCertificateCommand, Certificates>();
        }
    }
}
