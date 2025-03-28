namespace E_Learning_Core.Features.Coursess.Queries.Results
{
    public class GetAllUsersEnrolledInCourseResult
    {
        public List<Students> students { get; set; }
    }
    public class Students()
    {
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
