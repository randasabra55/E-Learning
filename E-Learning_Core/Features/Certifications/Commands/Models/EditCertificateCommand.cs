using E_Learning_Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Learning_Core.Features.Certifications.Commands.Models
{
    public class EditCertificateCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public IFormFile CertificateUrl { get; set; }
        /*public int UserId { get; set; }
        public int CourseId { get; set; }*/
    }
}
