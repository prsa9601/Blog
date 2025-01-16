using Blog.Infrastructure.Persistent.Dapper;
using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Order.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.Order.GetCurrent;
public record GetCurrentUserOrderQuery(long UserId):IQuery<OrderDto?>;


public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
     private readonly BlogContext _blogContext;
    private readonly DapperContext _dapperContext;

    public GetCurrentUserOrderQueryHandler(BlogContext blogContext, DapperContext dapperContext)
    {
        _blogContext = blogContext;
        _dapperContext = dapperContext;
    }
    public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _blogContext.Orders
            .FirstOrDefaultAsync(f => f.UserId == request.UserId && f.Status==Domain.OrderAgg.OrderStatus.Pending, cancellationToken);
        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _blogContext.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}
