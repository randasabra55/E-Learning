using E_Learning_Data.Entities;
using Microsoft.AspNetCore.Http;

namespace E_Learning_Service.Abstracts
{
    public interface ICertificateService
    {
        public Task<string> AddCertificateAsync(Certificates certificate, IFormFile imageFile);
        public Task<string> EditCertificateAsync(Certificates certificate, IFormFile imageFile);
        public Task<string> DeleteCertificateAsync(int certificateId);
        public IQueryable<Certificates> GetCertificatesAsync();
        public Task<Certificates> GetCertificateByIdAsync(int certificateId);
        //public Task<bool> IsTitleExistExcludeSelf(string title, int courseId);
    }
}
