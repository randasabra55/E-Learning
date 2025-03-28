using E_Learning_Core.Features.Certifications.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Certifications.Queries.Models
{
    public class GetCertificatesPaginatedQuery : IRequest<PaginatedResult<GetCertificateResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
