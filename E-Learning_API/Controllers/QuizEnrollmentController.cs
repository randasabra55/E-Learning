using E_Learning_API.Bases;
using E_Learning_Core.Features.QuizEnrollments.Commands.Models;
using E_Learning_Core.Features.QuizEnrollments.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizEnrollmentController : AppControllerBase
    {
        [HttpPost("EnrollToQuiz")]
        [Authorize]
        public async Task<IActionResult> EnrollToQuiz([FromBody] EnrollUserInQuizCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize]
        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] AddUserAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize]
        [HttpGet("GetScore{userId}/{quizId}")]
        public async Task<IActionResult> GetScore([FromRoute] int userId, int quizId)
        {
            var result = await Mediator.Send(new GetScoreQuery(userId, quizId));
            return NewResult(result);
        }
    }
}
