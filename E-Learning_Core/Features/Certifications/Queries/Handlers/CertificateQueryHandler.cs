using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Certifications.Queries.Models;
using E_Learning_Core.Features.Certifications.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Certifications.Queries.Handlers
{
    public class CertificateQueryHandler : ResponseHandler,
                                         IRequestHandler<GetCertificateByIdQuery, Response<GetCertificateResult>>,
                                         IRequestHandler<GetCertificatesPaginatedQuery, PaginatedResult<GetCertificateResult>>
    {
        ICertificateService certificateService;
        IMapper mapper;
        public CertificateQueryHandler(ICertificateService certificateService, IMapper mapper)
        {
            this.certificateService = certificateService;
            this.mapper = mapper;
        }
        public async Task<Response<GetCertificateResult>> Handle(GetCertificateByIdQuery request, CancellationToken cancellationToken)
        {
            var certificate = await certificateService.GetCertificateByIdAsync(request.Id);
            if (certificate == null)
                return NotFound<GetCertificateResult>("this certificate not found");
            //map
            var result = mapper.Map<GetCertificateResult>(certificate);
            return Success(result);
        }

        public async Task<PaginatedResult<GetCertificateResult>> Handle(GetCertificatesPaginatedQuery request, CancellationToken cancellationToken)
        {
            var list = certificateService.GetCertificatesAsync();
            var result = await mapper.ProjectTo<GetCertificateResult>(list)
                                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }
}
