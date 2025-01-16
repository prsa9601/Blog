using Blog.Domain.SiteEntities;
using Common.Query;

namespace Blog.Query.SiteEntities.DTOs;

public class BannerDto : BaseDto
{
    public string Link { get;  set; }
    public string ImageName { get;  set; }
    public BannerPosition Position { get;  set; }
}
 