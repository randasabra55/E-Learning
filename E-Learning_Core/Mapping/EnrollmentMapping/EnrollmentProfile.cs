using AutoMapper;

namespace E_Learning_Core.Mapping.EnrollmentMapping
{
    public partial class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            GetCourseEnrolledMapping();
        }
    }
}
