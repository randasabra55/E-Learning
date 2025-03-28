namespace E_Learning_Core.Features.Coursess.Queries.Results
{
    public class GetCourseByIdResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Lesson> lessons { get; set; }
    }
    public class Lesson()
    {
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int Order { get; set; }
    }
}
