using Common.Application;

namespace Blog.Application.Product.RemoveImage
{
    public record RemoveProductImageCommand(long ProductId, long ImageId) : IBaseCommand;
}
