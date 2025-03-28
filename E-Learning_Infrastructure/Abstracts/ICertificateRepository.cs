using E_Learning_Data.Entities;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface ICertificateRepository : IGenericRepository<Certificates>
    {
        public IQueryable<Certificates> GetCertificatesQuerable();
        public Task<Certificates?> GetCertificateByUserAndCourseAsync(int userId, int courseId);

    }

}
