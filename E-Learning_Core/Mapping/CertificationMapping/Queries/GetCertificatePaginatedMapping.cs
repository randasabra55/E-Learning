using E_Learning_Core.Features.Certifications.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.CertificationMapping
{
    public partial class CertificationProfile
    {
        public void GetCertificatePaginatedMapping()
        {
            CreateMap<Certificates, GetCertificateResult>();
        }
    }
}
