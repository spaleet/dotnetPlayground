using Playground.Api.MediaManager.Data.Models;

namespace Playground.Api.MediaManager.Data.Services;

public interface IMediaService
{
    Task<Media> GetMedia(string id);
}
