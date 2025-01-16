using Common.Application;

namespace Blog.Application.Order.IncreaseItemCount
{
    public record IncreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}