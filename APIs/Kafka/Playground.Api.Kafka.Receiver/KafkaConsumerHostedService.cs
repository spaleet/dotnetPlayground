using Confluent.Kafka;

namespace Playground.Api.Kafka.Receiver;

public class KafkaConsumerHostedService : IHostedService
{
    private readonly ILogger<KafkaConsumerHostedService> _logger;
    private IConsumer<long, string> _consumer;

    public KafkaConsumerHostedService(ILogger<KafkaConsumerHostedService> logger)
    {
        _logger = logger;
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "myApp-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnablePartitionEof = true
        };

        _consumer = new ConsumerBuilder<long, string>(config)
            .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}. Is Fatal: {e.IsFatal}"))
            .Build();

    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _consumer.Subscribe("myApp");
        try
        {
            while (true)
            {
                var result = _consumer.Consume(TimeSpan.FromSeconds(5));

                if (result is null)
                    continue;
                
                var message = result?.Message?.Value;

                _logger.LogInformation($"Received: {result.Message.Key}:{message} from partition: {result.Partition.Value}");

                _consumer.Commit(result);
                //_consumer.StoreOffset(result);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _consumer?.Unsubscribe();
        _consumer?.Dispose();

        return Task.CompletedTask;
    }
}
