using Blog.Query.Product.DTOs;
using Common.Query;

namespace Blog.Query.Product.GetById
{
    public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto?>;
}
