﻿using Playground.Api.MediaManager.Data;
using Playground.Api.MediaManager.Data.Services;

namespace Playground.Api.MediaManager;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<DbSetting>(config.GetSection("DbSettings"));

        services.AddScoped<IMediaService, MediaService>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}