using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Certifications.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Certifications.Commands.Handlers
{
    public class CertificateCommandHandler : ResponseHandler,
                                      IRequestHandler<AddCertificateCommand, Response<string>>,
                                      IRequestHandler<EditCertificateCommand, Response<string>>,
                                      IRequestHandler<DeleteCertificateCommand, Response<string>>
    {
        ICertificateService certificateService;
        IMapper mapper;
        INotificationService notificationService;

        public CertificateCommandHandler(ICertificateService certificateService, IMapper mapper, INotificationService notificationService)
        {
            this.certificateService = certificateService;
            this.mapper = mapper;
            this.notificationService = notificationService;
        }

        public async Task<Response<string>> Handle(AddCertificateCommand request, CancellationToken cancellationToken)
        {

            var certificate = mapper.Map<Certificates>(request);
            var result = await certificateService.AddCertificateAsync(certificate, request.CertificateUrl);
            if (result == "User already has a certificate for this course")
            {
                return BadRequest<string>("User already has a certificate for this course");
            }
            else if (!string.IsNullOrEmpty(result))
            {
                var notification = new Notifications
                {
                    UserId = request.UserId,
                    Message = "Congratuations, You have been gain certificate because finished this course",
                    IsRead = false
                };
                try
                {
                    await notificationService.AddNotification(notification);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding notification: {ex.Message}");
                }
                return Success("Addedd Successfully");
            }
            else return BadRequest<string>("Failed, please try again");
        }

        public async Task<Response<string>> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            var result = await certificateService.DeleteCertificateAsync(request.Id);
            if (result == "NotFound")
                return NotFound<string>("certificate not fount to delete it");
            return Success("Deleted successfully");
        }

        public async Task<Response<string>> Handle(EditCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = await certificateService.GetCertificateByIdAsync(request.Id);
            if (certificate == null) return NotFound<string>("there is no certificate to edit it");
            var courseMapper = mapper.Map(request, certificate);
            var result = await certificateService.EditCertificateAsync(courseMapper, request.CertificateUrl);

            if (result == "Success") return Success("Updated successfully");
            else return BadRequest<string>();
        }
    }
}
