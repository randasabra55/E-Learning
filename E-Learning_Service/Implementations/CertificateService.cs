using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace E_Learning_Service.Implementations
{
    public class CertificateService : ICertificateService
    {
        ICertificateRepository certificateRepository;
        IWebHostEnvironment webHost;
        IHttpContextAccessor httpContextAccessor;
        public CertificateService(ICertificateRepository certificateRepository, IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor)
        {
            this.certificateRepository = certificateRepository;
            this.webHost = webHost;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AddCertificateAsync(Certificates certificate, IFormFile imageFile)
        {
            var existingCertificate = await certificateRepository
                                            .GetCertificateByUserAndCourseAsync(certificate.UserId, certificate.CourseId);

            if (existingCertificate != null)
            {
                return "User already has a certificate for this course";
            }
            //add image
            var request = httpContextAccessor.HttpContext?.Request;
            if (request == null) return "Failed to get request context";
            var webRootPath = webHost.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }
            var uploadsFolder = Path.Combine(webHost.WebRootPath, "uploads", "Images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString().Substring(0, 5) + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            var fileUrl = $"{request.Scheme}://{request.Host}/uploads/Images/{uniqueFileName}";

            certificate.CertificateUrl = fileUrl;
            await certificateRepository.AddAsync(certificate);
            //return "Success";
            return fileUrl;
            /* await certificateRepository.AddAsync(certificate);
             return "Success";*/
        }

        public async Task<string> DeleteCertificateAsync(int certificateId)
        {
            var certificate = await certificateRepository.GetByIdAsync(certificateId);
            if (certificate == null) return "NotFound";
            await certificateRepository.DeleteAsync(certificate);
            return "Success";
        }

        public async Task<string> EditCertificateAsync(Certificates certificate, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var request = httpContextAccessor.HttpContext?.Request;
                if (request == null) return "Failed to get request context";
                var oldFilePath = Path.Combine(webHost.WebRootPath, certificate.CertificateUrl.TrimStart('/'));
                if (File.Exists(oldFilePath))
                    File.Delete(oldFilePath);
                var uploadsFolder = Path.Combine(webHost.WebRootPath, "uploads", "Images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString().Substring(0, 5) + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                var fileUrl = $"{request.Scheme}://{request.Host}/uploads/Images/{uniqueFileName}";

                certificate.CertificateUrl = fileUrl;
            }

            await certificateRepository.UpdateAsync(certificate);
            return "Success";
        }

        public async Task<Certificates> GetCertificateByIdAsync(int certificateId)
        {
            return await certificateRepository.GetByIdAsync(certificateId);
        }

        public IQueryable<Certificates> GetCertificatesAsync()
        {
            return certificateRepository.GetCertificatesQuerable();
        }
    }
}
