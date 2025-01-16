using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Category.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.Category.GetList;


internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly BlogContext _context;

    public GetCategoryListQueryHandler(BlogContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
            .Where(r=>r.ParentId==null)
            .Include(c=>c.Childs)
            .ThenInclude(c=>c.Childs)
            .OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
        return model.Map();
    }
}