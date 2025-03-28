using E_Learning_API.Bases;
using E_Learning_Core.Features.Notificationss.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : AppControllerBase
    {
        [HttpGet("GetNotificationById/{id}")]
        public async Task<IActionResult> GetNotificationbyIdAsync(int id)
        {
            var result = await Mediator.Send(new GetNotificationByIdQuery(id));
            return NewResult(result);
        }

        [HttpGet("GetNotificationListForUser/{id}")]
        public async Task<IActionResult> GetNotificationListForUserAsync(int id)
        {
            var result = await Mediator.Send(new GetNotificationListQuery(id));
            return NewResult(result);
        }
    }
}
