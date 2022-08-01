using Confluent.Kafka;

namespace Playground.Api.Kafka;

public class KafkaConsumerHostedService : IHostedService
{
    private readonly ILogger<KafkaConsumerHostedService> _logger;
    private IConsumer<Null, string> _consumer;

    public KafkaConsumerHostedService(ILogger<KafkaConsumerHostedService> logger)
    {
        _logger = logger;
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "myApp-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Null, string>(config).Build();

    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _consumer.Subscribe("myApp");
        try
        {
            var response = _consumer.Consume(cancellationToken);

            if (response.Message != null)
                _logger.LogInformation("Recievd : {msg}", response.Message.Value);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _consumer?.Unsubscribe();
        _consumer?.Dispose();

        return Task.CompletedTask;
    }
}
