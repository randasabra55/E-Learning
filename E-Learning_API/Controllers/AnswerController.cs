using E_Learning_API.Bases;
using E_Learning_Core.Features.Answers.Commands.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Instructor")]
    public class AnswerController : AppControllerBase
    {
        [HttpPost("AddAnswers")]
        public async Task<IActionResult> AddAnswers([FromBody] AddAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut("EditAnswers")]
        public async Task<IActionResult> EditAnswersAsync([FromBody] EditAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete("DeleteAnswer/{id:int}")]
        public async Task<IActionResult> DeleteAnswersAsync(int id)
        {
            var result = await Mediator.Send(new DeleteAnswerCommand(id));
            return NewResult(result);
        }

        /*[HttpGet("GetAnswersPaginated")]
        public async Task<IActionResult> GetAnswerssAsync([FromQuery] GetAnswersPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }*/

        /* [HttpGet("GetAnswerById/{id}")]
         public async Task<IActionResult> GetAnswerbyIdAsync(int id)
         {
             var result = await Mediator.Send(new GetAnswerByIdQuery(id));
             return NewResult(result);
         }*/
    }
}
