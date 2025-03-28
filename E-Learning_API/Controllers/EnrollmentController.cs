using E_Learning_API.Bases;
using E_Learning_Core.Features.Enrollmentss.Commands.Models;
using E_Learning_Core.Features.Enrollmentss.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollmentController : AppControllerBase
    {
        [HttpPost("EnrollCourse")]
        public async Task<IActionResult> EnrollCourse([FromBody] EnrollStudentCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet("GetCoursesEnrolled{studentId:int}")]
        public async Task<IActionResult> GetCoursesEnrolled([FromRoute] int studentId)
        {
            var result = await Mediator.Send(new GetCoursesEnrolledByUserQuery(studentId));
            return NewResult(result);
        }
    }
}
