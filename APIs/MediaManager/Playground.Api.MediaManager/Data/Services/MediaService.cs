using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Playground.Api.MediaManager.Data.Models;

namespace Playground.Api.MediaManager.Data.Services;

public class MediaService : IMediaService
{
    #region ctor

    private readonly IMongoCollection<Media> _collection;

    public MediaService(IOptions<DbSetting> dbSettingOptions)
    {
        var dbSetting = dbSettingOptions.Value;

        var mongoSettings = MongoClientSettings.FromConnectionString(dbSetting.ConnectionString);
        mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);

        var client = new MongoClient(mongoSettings);
        var database = client.GetDatabase(dbSetting.DbName);

        _collection = database.GetCollection<Media>(dbSetting.CollectionName);
    }

    #endregion

    #region GetMedia

    public async Task<Media> GetMedia(string id)
    {
        var filter = Builders<Media>.Filter.Eq(x => x.Id, id);

        var res = await _collection.FindAsync(filter);

        return await res.FirstOrDefaultAsync();
    }

    #endregion

    #region CreateMedia

    public async Task<string> CreateMedia(CreateMediaDto request)
    {
        using var stream = new MemoryStream();
        await request.OpenReadStream().CopyToAsync(stream);

        var media = new Media
        {
            Content = stream.ToArray(),
            FileName = request.FileName,
            ContentType = request.ContentType
        };

        await _collection.InsertOneAsync(media);

        return media.Id;
    }

    #endregion


}
