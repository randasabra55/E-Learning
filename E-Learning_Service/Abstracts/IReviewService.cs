using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IReviewService
    {
        public Task<string> AddReview(Reviews review);
        public Task<string> EditReview(Reviews review);
        public Task<Reviews> GetReviewById(int reviewId);
        public Task<string> DeleteReview(int reviewId);
        public IQueryable<Reviews> GetReviewsQuerable();
        public IQueryable<Reviews> GetReviewsByCourseIdQuerable(int courseId);
    }
}
