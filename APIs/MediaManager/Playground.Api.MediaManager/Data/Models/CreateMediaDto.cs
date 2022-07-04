namespace Playground.Api.MediaManager.Data.Models;

public class CreateMediaDto
{
    public string FileName { get; set; }
    
    public long Length { get; set; }
    
    public string ContentType { get; set; }

    public Func<Stream> OpenReadStream { get; set; }
}
