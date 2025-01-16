using Common.Application;

namespace Blog.Application.SiteEntities.Banners.Delete;

public record DeleteBannerCommand(long Id) : IBaseCommand;