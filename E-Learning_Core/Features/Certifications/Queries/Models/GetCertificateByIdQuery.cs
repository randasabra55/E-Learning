
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Certifications.Queries.Results;
using MediatR;


namespace E_Learning_Core.Features.Certifications.Queries.Models
{
    public class GetCertificateByIdQuery : IRequest<Response<GetCertificateResult>>
    {
        public int Id { get; set; }
        public GetCertificateByIdQuery(int id)
        {
            Id = id;
        }
    }
}
