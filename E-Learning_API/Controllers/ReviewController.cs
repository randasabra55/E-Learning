using E_Learning_API.Bases;
using E_Learning_Core.Features.Reviewss.Commands.Models;
using E_Learning_Core.Features.Reviewss.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : AppControllerBase
    {
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut("EditReview")]
        public async Task<IActionResult> EditReviewAsync([FromBody] EditReviewCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete("DeleteReview/{id:int}")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            var result = await Mediator.Send(new DeleteReviewCommand(id));
            return NewResult(result);
        }

        /*[HttpGet("GetAnswersPaginated")]
        public async Task<IActionResult> GetAnswerssAsync([FromQuery] GetAnswersPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }*/

        [HttpGet("GetReviewsForCoursePaginated/{id}")]
        public async Task<IActionResult> GetReviewsForSpecificCourseAsync(int id)
        {
            var result = await Mediator.Send(new GetReviewsPaginatedAboutCourseQuery(id));
            return Ok(result);
        }
    }
}
