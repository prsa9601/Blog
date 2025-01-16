using Blog.Query.SiteEntities.DTOs;
using Common.Query;

namespace Blog.Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;