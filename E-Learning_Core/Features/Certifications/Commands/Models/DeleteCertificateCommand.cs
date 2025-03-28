using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Certifications.Commands.Models
{
    public class DeleteCertificateCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteCertificateCommand(int id)
        {
            Id = id;
        }
    }
}
