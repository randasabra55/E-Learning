using AutoMapper;

namespace E_Learning_Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            AddReviewMapping();
            EditReviewMapping();
            GetReviewsMapping();
        }
    }
}
