using Common.Application;

namespace Blog.Application.Order.DecreaseItemCount;
public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;