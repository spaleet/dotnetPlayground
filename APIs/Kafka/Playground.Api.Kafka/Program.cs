using Playground.Api.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<KafkaProducerHostedService>();
builder.Services.AddHostedService<KafkaConsumerHostedService>();

var app = builder.Build();

app.Run();
