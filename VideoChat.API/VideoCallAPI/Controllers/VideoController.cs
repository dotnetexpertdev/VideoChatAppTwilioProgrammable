using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoCallAPI.Services;

namespace VideoCallAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var tokenn = _videoService.GetTwilioJwt(User.Identity.Name);
            return new JsonResult(new { token = tokenn });
        }

        [HttpGet("rooms")]
        public async Task<IActionResult> GetRooms()
        {
            return new JsonResult(await _videoService.GetAllRoomsAsync());
        }
    }
}
