using Blog.Domain.OrderAgg.Events;
using MediatR;

namespace Blog.Application.Order._EvenHandlers;

public class SendSmsOrderFinalizedEventHandler:INotificationHandler<OrderFinalized>
{
    public async Task Handle(OrderFinalized notification, CancellationToken cancellationToken)
    {
        await Task.Delay(10000, cancellationToken);
        Console.WriteLine("------------------------------------------------------------");
    }
}