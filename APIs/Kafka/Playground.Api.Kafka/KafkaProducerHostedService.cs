using Confluent.Kafka;

namespace Playground.Api.Kafka;

public class KafkaProducerHostedService : IHostedService
{
    private readonly ILogger<KafkaProducerHostedService> _logger;
    private IProducer<Null, string> _producer;

    public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
    {
        _logger = logger;
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        _producer = new ProducerBuilder<Null, string>(config).Build();

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            string msg = $"Value is {i}";
            _logger.LogInformation(msg);

            await _producer.ProduceAsync("myApp", new Message<Null, string>
            {
                Value = msg
            }, cancellationToken);
        }

        _producer.Flush(TimeSpan.FromSeconds(5));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _producer?.Dispose();
        return Task.CompletedTask;
    }
}
