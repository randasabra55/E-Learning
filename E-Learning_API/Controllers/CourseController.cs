using E_Learning_API.Bases;
using E_Learning_Core.Features.Coursess.Commands.Models;
using E_Learning_Core.Features.Coursess.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Instructor")]
    public class CourseController : AppControllerBase
    {
        [Authorize(Roles = "Instructor")]
        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPut("EditCourse")]
        public async Task<IActionResult> EditCourseAsync([FromBody] EditCourseCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpDelete("DeleteCourse/{id:int}")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            var result = await Mediator.Send(new DeleteCourseCommand(id));
            return NewResult(result);
        }

        [Authorize]
        [HttpGet("GetCoursesPaginated")]
        public async Task<IActionResult> GetCoursesAsync([FromQuery] GetCoursePaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetCourseById/{id}")]
        public async Task<IActionResult> GetCoursebyIdAsync(int id)
        {
            var result = await Mediator.Send(new GetCourseByIdQuery(id));
            return NewResult(result);
        }

        [Authorize(Roles = "Admin,Instructor")]
        //[Authorize(Roles = "Instructor")]
        [HttpGet("GetUsersEnrolledInCoursePaginated/{id}")]
        public async Task<IActionResult> GetUsersEnrolledInCoursePaginatedAsync(int id)
        {
            var result = await Mediator.Send(new GetAllUsersEnrolledInCourseQuery(id));
            return Ok(result);
        }
    }
}
