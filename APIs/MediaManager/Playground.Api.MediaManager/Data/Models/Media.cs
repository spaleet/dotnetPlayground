using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Playground.Api.MediaManager.Data.Models;

public class Media
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public byte[] Content { get; set; }

    public string ContentType { get; set; }

    public string FileName { get; set; }
}
