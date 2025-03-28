using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;

namespace E_Learning_Service.Implementations
{
    public class ReviewService : IReviewService
    {
        IReviewRepository reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public async Task<string> AddReview(Reviews review)
        {
            await reviewRepository.AddAsync(review);
            return "Success";
        }

        public async Task<string> DeleteReview(int reviewId)
        {
            var review = await reviewRepository.GetByIdAsync(reviewId);
            if (review == null)
                return "NotFound";
            await reviewRepository.DeleteAsync(review);
            return "Success";
        }

        public async Task<string> EditReview(Reviews review)
        {
            await reviewRepository.UpdateAsync(review);
            return "Success";
        }

        public async Task<Reviews> GetReviewById(int reviewId)
        {
            return await reviewRepository.GetByIdAsync(reviewId);
        }

        public IQueryable<Reviews> GetReviewsByCourseIdQuerable(int courseId)
        {
            return reviewRepository.GetReviewsByCourseIdQuerable(courseId);
        }

        public IQueryable<Reviews> GetReviewsQuerable()
        {
            return reviewRepository.GetReviewsQuerable();
        }
    }
}
