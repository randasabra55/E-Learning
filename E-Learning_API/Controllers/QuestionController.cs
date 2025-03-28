using E_Learning_API.Bases;
using E_Learning_Core.Features.Questions.Commands.Models;
using E_Learning_Core.Features.Questions.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles ="Instructor")]
    public class QuestionController : AppControllerBase
    {
        [Authorize(Roles = "Instructor")]
        [HttpPost("AddQuestion")]
        public async Task<IActionResult> AddQuestion([FromBody] AddQuestionCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPut("EditQuestion")]
        public async Task<IActionResult> EditQuestionAsync([FromBody] EditQuestionCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpDelete("DeleteQuestion/{id:int}")]
        public async Task<IActionResult> DeleteQuestionAsync(int id)
        {
            var result = await Mediator.Send(new DeleteQuestionCommand(id));
            return NewResult(result);
        }

        [Authorize]
        [HttpGet("GetQuestinsPaginated")]
        public async Task<IActionResult> GetQuestionsAsync([FromQuery] GetQuestionPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetQuestionById/{id}")]
        public async Task<IActionResult> GetQuestionbyIdAsync(int id)
        {
            var result = await Mediator.Send(new GetQuestionByIdQuery(id));
            return NewResult(result);
        }
    }
}
