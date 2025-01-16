using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Category.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Blog.Query.Category.GetById;

internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly BlogContext _context;

    public GetCategoryByIdQueryHandler(BlogContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
            .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);
        return model.Map();
    }
}