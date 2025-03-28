using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class CertificateRepository : GenericRepository<Certificates>, ICertificateRepository
    {
        private DbSet<Certificates> certificates;

        public CertificateRepository(Context context) : base(context)
        {
            certificates = context.Set<Certificates>();
        }

        public async Task<Certificates?> GetCertificateByUserAndCourseAsync(int userId, int courseId)
        {
            return await certificates
            .FirstOrDefaultAsync(c => c.UserId == userId && c.CourseId == courseId);
        }

        public IQueryable<Certificates> GetCertificatesQuerable()
        {
            return certificates.AsNoTracking().AsQueryable();
        }
    }
}
