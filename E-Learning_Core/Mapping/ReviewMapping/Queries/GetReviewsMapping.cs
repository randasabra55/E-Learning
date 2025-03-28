using E_Learning_Core.Features.Reviewss.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile
    {
        public void GetReviewsMapping()
        {
            CreateMap<Reviews, GetReviewsPaginatedResult>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}
