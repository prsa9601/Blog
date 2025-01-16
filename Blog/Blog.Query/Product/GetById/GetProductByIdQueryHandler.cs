using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Product.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.Product.GetById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly BlogContext _context;

        public GetProductByIdQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(f => f.Id == request.ProductId, cancellationToken);

            var model = product.Map();
            if (model == null)
                return null;
            await model.SetCategories(_context);
            return model;
        }
    }
}
