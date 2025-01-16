using Common.Domain.Repository;

namespace Blog.Domain.SiteEntities.Repositories
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        void Delete(Banner banner);
    }
}