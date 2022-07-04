using MongoDB.Driver;
using Playground.Api.MediaManager.Data.Models;

namespace Playground.Api.MediaManager.Data.Services;

public interface IMediaService
{
}

public class MediaService : IMediaService
{
    #region ctor

    private readonly IConfiguration _configuration;
    private readonly IMongoCollection<Media> _collection;

    public MediaService(IConfiguration configuration)
    {
        _configuration = configuration;

        string connectionString = _configuration.GetConnectionString("MongoConnection");

        var mongoSettings = MongoClientSettings.FromConnectionString(connectionString);
        mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);

        var client = new MongoClient(mongoSettings);
        var database = client.GetDatabase("");

        _collection = database.GetCollection<Media>("MediaCollection");
    }

    #endregion
}
