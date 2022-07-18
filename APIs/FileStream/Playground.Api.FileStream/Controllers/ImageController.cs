using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.FileStream.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public ImageController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet("{fileName}")]
    public async Task<FileContentResult> GetImg([FromRoute] string fileName)
    {
        string webRoot = _environment.WebRootPath;
        string path = Path.Combine(webRoot, $"upload/{fileName}");

        string imageFileExtension = Path.GetExtension(fileName);
        string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

        byte[] buffer = await System.IO.File.ReadAllBytesAsync(path);

        return File(buffer, mimetype);
    }

    [HttpPost]
    public async Task<IActionResult> UploadImg(IFormFile file)
    {
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        string path = Path.Combine(_environment.WebRootPath, $"upload/{fileName}");

        using (var stream = new System.IO.FileStream(path, FileMode.Create))
        await file.CopyToAsync(stream);

        return Ok(fileName);
    }

    private string GetImageMimeTypeFromImageFileExtension(string extension)
    {
        string mimetype = extension switch
        {
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".bmp" => "image/bmp",
            ".tiff" => "image/tiff",
            ".wmf" => "image/wmf",
            ".jp2" => "image/jp2",
            ".svg" => "image/svg+xml",
            _ => "application/octet-stream",
        };
        return mimetype;
    }
}
