using Blog.Domain.SiteEntities;
using Common.Domain.Repository;

namespace Blog.Domain.SiteEntities.Repositories;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}