using Common.Application;

namespace Blog.Application.Order.RemoveItem
{
    public record RemoveOrderItemCommand(long UserId, long ItemId) : IBaseCommand;
}