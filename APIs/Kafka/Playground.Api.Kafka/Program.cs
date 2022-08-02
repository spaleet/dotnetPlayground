using Playground.Api.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<KafkaProducerHostedService>();

var app = builder.Build();

app.Run();
