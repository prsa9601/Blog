using Blog.Query.Product.DTOs;
using Common.Query;

namespace Blog.Query.Product.GetBySlug
{
    public class GetProductBySlugQuery : IQuery<ProductDto?>
    {
        public GetProductBySlugQuery(string slug)
        {
            Slug = slug;
        }

        public string Slug { get; private set; }
    }
}
