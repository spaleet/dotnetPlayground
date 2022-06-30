using MediatR;

namespace Playground.Api.Events;

public class SayHelloEvent : INotification
{
    public string Message { get; set; }
}

public class SayHelloEventHandle : INotificationHandler<SayHelloEvent>
{
    private readonly ILogger<SayHelloEvent> _logger;

    public SayHelloEventHandle(ILogger<SayHelloEvent> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(SayHelloEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Event fired: {DomainEvent} Message: {msg}",
                               notification.GetType().Name,
                               notification.Message);

        return Task.CompletedTask;
    }
}

