using Blog.Query.Order.DTOs;
using Common.Query;

namespace Blog.Query.Order.GetByFilter;

public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}