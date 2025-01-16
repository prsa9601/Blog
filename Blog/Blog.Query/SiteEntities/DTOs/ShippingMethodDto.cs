using Common.Query;

namespace Blog.Query.SiteEntities.DTOs;

public class ShippingMethodDto:BaseDto
{
    public string Title { get; set; }
    public int Cost { get; set; }
}