using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Reviewss.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Reviewss.Commands.Handlers
{
    public class ReviewCommandHandler : ResponseHandler,
                                      IRequestHandler<AddReviewCommand, Response<string>>,
                                      IRequestHandler<EditReviewCommand, Response<string>>,
                                      IRequestHandler<DeleteReviewCommand, Response<string>>

    {
        IReviewService reviewService;
        IMapper mapper;
        public ReviewCommandHandler(IReviewService reviewService, IMapper mapper)
        {
            this.reviewService = reviewService;
            this.mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = mapper.Map<Reviews>(request);
            var result = await reviewService.AddReview(review);

            if (result == "Success")
            {
                return Success("Addedd Successfully");
            }
            else return BadRequest<string>("Failed, please try again");
        }

        public async Task<Response<string>> Handle(EditReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await reviewService.GetReviewById(request.Id);
            if (review == null) return NotFound<string>("there is no review to edit it");
            var reviewMapper = mapper.Map(request, review);
            var result = await reviewService.EditReview(reviewMapper);

            if (result == "Success") return Success("Updated successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var result = await reviewService.DeleteReview(request.Id);
            if (result == "NotFound")
                return NotFound<string>("Review not fount to delete it");
            return Success("Deleted successfully");
        }
    }
}
