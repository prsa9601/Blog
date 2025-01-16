﻿using Blog.Domain.OrderAgg;
using Blog.Domain.OrderAgg.Repository;
using Common.Application;

namespace Blog.Application.Order.SendOrder;

public class SendOrderCommand : IBaseCommand
{
    public SendOrderCommand(long orderId)
    {
        OrderId = orderId;
    }

    public long OrderId { get; private set; }
}

public class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public SendOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetTracking(request.OrderId);
        if(order==null)
            return OperationResult.NotFound();

        order.ChangeStatus(OrderStatus.Shipping);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}