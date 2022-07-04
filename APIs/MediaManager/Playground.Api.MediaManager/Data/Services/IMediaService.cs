namespace Playground.Api.MediaManager.Data.Services;

public interface IMediaService
{
    Task<Media> GetMedia(string id);

    Task<string> CreateMedia(string id);
}
