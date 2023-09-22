using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.FileStream.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PngToJpgController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public PngToJpgController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpPost]
    public async Task<IActionResult> UploadImg(IFormFile file)
    {
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        string path = Path.Combine(_environment.WebRootPath, $"upload/{fileName}");

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            using (var img = Image.FromStream(memoryStream))
            {
                Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawImage(img, new Rectangle(new Point(), img.Size), new Rectangle(new Point(), img.Size), GraphicsUnit.Pixel);
                }
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
        }

        return Ok();
    }

}
