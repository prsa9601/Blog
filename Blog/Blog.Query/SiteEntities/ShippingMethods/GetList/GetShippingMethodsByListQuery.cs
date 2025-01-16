using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.SiteEntities.ShippingMethods.GetList;

public class GetShippingMethodsByListQuery : IQuery<List<ShippingMethodDto>>
{

}

internal class GetShippingMethodsByListQueryHandler : IQueryHandler<GetShippingMethodsByListQuery, List<ShippingMethodDto>>
{
    private readonly BlogContext _context;

    public GetShippingMethodsByListQueryHandler(BlogContext context)
    {
        _context = context;
    }

    public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodsByListQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).ToListAsync(cancellationToken);
    }
}