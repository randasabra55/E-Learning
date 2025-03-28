using E_Learning_Core.Features.Reviewss.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.ReviewMapping
{
    public partial class ReviewProfile
    {
        public void EditReviewMapping()
        {
            CreateMap<EditReviewCommand, Reviews>();
        }
    }
}
