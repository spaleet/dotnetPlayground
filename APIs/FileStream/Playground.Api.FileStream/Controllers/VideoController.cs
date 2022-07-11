using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.FileStream.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoController : ControllerBase
{
    private readonly ILogger<VideoController> _logger;

    public VideoController(ILogger<VideoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetVideo()
    {
        return Ok();
    }
}
