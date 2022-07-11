using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.FileStream.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public VideoController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public FileResult GetVideo()
    {
        string path = Path.Combine(_environment.WebRootPath, "upload/video_mg.mp4");

        return PhysicalFile(path, "application/octet-stream", enableRangeProcessing: true);
    }
}
