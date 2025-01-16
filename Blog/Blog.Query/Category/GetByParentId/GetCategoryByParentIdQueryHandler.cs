using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Category.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.Category.GetByParentId;

internal class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
{
    private readonly BlogContext _context;

    public GetCategoryByParentIdQueryHandler(BlogContext context)
    {
        _context = context;
    }

    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .Include(c => c.Childs)
            .Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);

        return result.MapChildren();
    }
}