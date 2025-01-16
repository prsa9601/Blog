using Common.Application;

namespace Blog.Application.Product.Remove
{
    public record class RemoveProductCommand(long productId) : IBaseCommand;

}
