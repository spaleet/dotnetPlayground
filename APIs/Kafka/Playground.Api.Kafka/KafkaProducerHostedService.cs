using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace Playground.Api.Kafka;

public class KafkaProducerHostedService : IHostedService
{
    private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(5));
    private readonly ILogger<KafkaProducerHostedService> _logger;
    private IProducer<long, string> _producer;

    public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
    {
        _logger = logger;
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        _producer = new ProducerBuilder<long, string>(config).Build();

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        int up = 0;

        while (await _timer.WaitForNextTickAsync(cancellationToken) && !cancellationToken.IsCancellationRequested)
        {
            string msg = $"Value is {up}";

            var res = await _producer.ProduceAsync("myApp", new Message<long, string>
            {
                Value = msg,
                Key = DateTime.UtcNow.Ticks
            }, cancellationToken);

            _logger.LogInformation(res.Message.Value);

            up++;

            if (res.Status != PersistenceStatus.Persisted)
            {
                // delivery might have failed after retries. This message requires manual processing.
                _logger.LogError($"ERROR: Message not ack'd by all brokers (value: '{msg}'). Delivery status: {res.Status}");
            }
        }

        //_producer.Flush(TimeSpan.FromSeconds(10));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _producer?.Dispose();
        return Task.CompletedTask;
    }
}
