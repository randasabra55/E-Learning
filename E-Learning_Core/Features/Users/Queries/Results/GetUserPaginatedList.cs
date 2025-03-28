namespace E_Learning_Core.Features.Users.Queries.Results
{
    public class GetUserPaginatedList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        // public string? ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; }
    }
}
