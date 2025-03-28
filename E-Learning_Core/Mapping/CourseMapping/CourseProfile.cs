using AutoMapper;


namespace E_Learning_Core.Mapping.CourseMapping
{
    public partial class CourseProfile : Profile
    {
        public CourseProfile()
        {
            GetCoursesPaginatedMapping();
            GetUserByIdMapping();
            EditCourseMapping();
            AddCourseMapping();
            GetAllUsersEnrolledInCourseMappping();
        }
    }
}
