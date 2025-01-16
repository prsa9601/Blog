using Blog.Domain.SiteEntities;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.SiteEntities.Banners.Edit;

public class EditBannerCommand:IBaseCommand
{
   
    public long Id { get;  set; }
    public string Link { get;  set; }
    public IFormFile? ImageFile { get;  set; }
    public BannerPosition Position { get;  set; }
}