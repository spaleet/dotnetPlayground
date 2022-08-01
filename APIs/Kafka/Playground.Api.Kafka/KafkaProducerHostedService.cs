using Confluent.Kafka;
using Confluent.Kafka.Admin;

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
        await CreateTopic();


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

    private async Task CreateTopic()
    {
        using var adminClient = new AdminClientBuilder(
            new AdminClientConfig  
            { 
                BootstrapServers = "localhost:9092"
            }).Build();
        try
        {
            await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                    new TopicSpecification { Name = "myApp", ReplicationFactor = 1, NumPartitions = 1 } });
        }
        catch (CreateTopicsException e)
        {
            Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
        }
    }
}
