namespace E_Learning_Data.Requests
{
    public class GetCoursePaginatedRequest
    {
        public string? CourseName { get; set; }
        public string? InstructorName { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
