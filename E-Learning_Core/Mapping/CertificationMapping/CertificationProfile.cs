using AutoMapper;

namespace E_Learning_Core.Mapping.CertificationMapping
{
    public partial class CertificationProfile : Profile
    {
        public CertificationProfile()
        {
            AddCertificationMapping();
            EditCertificationMapping();
            GetCertificateByIdMapping();
            GetCertificatePaginatedMapping();
        }
    }
}
