using Microsoft.AspNetCore.Mvc;
using Playground.Api.MediaManager.Data.Models;
using Playground.Api.MediaManager.Data.Services;

namespace Playground.Api.MediaManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    #region ctor

    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    #endregion

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var media = await _mediaService.GetMedia(id);

        if (media is null)
            return NotFound();

        return File(media.Content, media.ContentType);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(IFormFile file)
    {
        var request = new CreateMediaDto
        {
            ContentType = file.ContentType,
            FileName = file.FileName,
            Length = file.Length,
            OpenReadStream = file.OpenReadStream
        };

        return await _mediaService.CreateMedia(request);
    }
}