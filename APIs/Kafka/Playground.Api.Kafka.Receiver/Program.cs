using Playground.Api.Kafka.Receiver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<KafkaConsumerHostedService>();

var app = builder.Build();

app.Run();
