using E_Learning_API.Bases;
using E_Learning_Core.Features.Certifications.Commands.Models;
using E_Learning_Core.Features.Certifications.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : AppControllerBase
    {
        [Authorize(Roles = "Instructor")]
        [HttpPost("AddCertificate")]
        public async Task<IActionResult> AddCertificate([FromForm] AddCertificateCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPut("EditCertificate")]
        public async Task<IActionResult> EditCertificateAsync([FromForm] EditCertificateCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Instructor")]
        [HttpDelete("DeleteCertificate/{id:int}")]
        public async Task<IActionResult> DeleteCertificateAsync(int id)
        {
            var result = await Mediator.Send(new DeleteCertificateCommand(id));
            return NewResult(result);
        }

        [Authorize]
        [HttpGet("GetCertificatesPaginated")]
        public async Task<IActionResult> GetCertificatesPaginated([FromQuery] GetCertificatesPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetCertificateById/{id}")]
        public async Task<IActionResult> GetCertificatebyIdAsync(int id)
        {
            var result = await Mediator.Send(new GetCertificateByIdQuery(id));
            return NewResult(result);
        }
    }
}
