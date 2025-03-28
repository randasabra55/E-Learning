using E_Learning_API.Bases;
using E_Learning_Core.Features.Quizes.Commands.Models;
using E_Learning_Core.Features.Quizes.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : AppControllerBase
    {
        [Authorize(Roles = "Instructor")]
        [HttpPost("AddQuiz")]
        public async Task<IActionResult> AddQuiz([FromBody] AddQuizCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPut("EditQuiz")]
        public async Task<IActionResult> EditQuizAsync([FromBody] EditQuizCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpDelete("DeleteQuiz/{id:int}")]
        public async Task<IActionResult> DeleteQuizAsync(int id)
        {
            var result = await Mediator.Send(new DeleteQuizCommand(id));
            return NewResult(result);
        }

        [Authorize]
        [HttpGet("GetQuizzesPaginated")]
        public async Task<IActionResult> GetLessonsAsync([FromQuery] GetQuizPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetQuizById/{id}")]
        public async Task<IActionResult> GetQuizbyIdAsync(int id)
        {
            var result = await Mediator.Send(new GetQuizByIdQuery(id));
            return NewResult(result);
        }
    }
}
