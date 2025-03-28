using E_Learning_API.Bases;
using E_Learning_Core.Features.Lessonss.Commands.Models;
using E_Learning_Core.Features.Lessonss.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Instructor")]
    public class LessonController : AppControllerBase
    {
        [Authorize(Roles = "Instructor")]
        [HttpPost("AddLesson")]
        public async Task<IActionResult> AddLesson([FromForm] AddLessonCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPut("EditLesson")]
        public async Task<IActionResult> EditLessonAsync([FromForm] EditLessonCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpDelete("DeleteLesson/{id:int}")]
        public async Task<IActionResult> DeleteLessonAsync(int id)
        {
            var result = await Mediator.Send(new DeleteLessonCommand(id));
            return NewResult(result);
        }

        [Authorize]
        [HttpGet("GetLessonsPaginated")]
        public async Task<IActionResult> GetLessonsAsync([FromQuery] GetLessonPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetLessonById/{id}")]
        public async Task<IActionResult> GetLessonbyIdAsync(int id)
        {
            var result = await Mediator.Send(new GetLessonByIdQuery(id));
            return NewResult(result);
        }
    }
}

