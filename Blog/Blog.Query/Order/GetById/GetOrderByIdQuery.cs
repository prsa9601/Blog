using Blog.Query.Order.DTOs;
using Common.Query;

namespace Blog.Query.Order.GetById;

public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;