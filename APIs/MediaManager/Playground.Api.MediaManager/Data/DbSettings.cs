namespace Playground.Api.MediaManager.Data;

public class DbSettings
{
    public string DbName { get; set; }

    public string Host { get; set; }

    public string Port { get; set; }

    public string ConnectionString => $@"mongodb://{Host}:{Port}";
}
