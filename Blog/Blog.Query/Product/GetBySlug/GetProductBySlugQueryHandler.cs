using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Product.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.Product.GetBySlug
{
    public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
    {
        private readonly BlogContext _context;

        public GetProductBySlugQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(f => f.Slug == request.Slug, cancellationToken);
            var model = product.Map();

            if (model == null)
                return null;

            await model.SetCategories(_context);
            return model;
        }
    }
}
