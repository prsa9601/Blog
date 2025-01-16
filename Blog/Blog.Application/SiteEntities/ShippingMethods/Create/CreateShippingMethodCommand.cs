using Common.Application;

namespace Blog.Application.SiteEntities.ShippingMethods.Create;

public class CreateShippingMethodCommand : IBaseCommand
{
    public string Title { get; set; }
    public int Cost { get; set; }
}