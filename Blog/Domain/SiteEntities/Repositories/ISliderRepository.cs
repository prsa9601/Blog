using Common.Domain.Repository;

namespace Blog.Domain.SiteEntities.Repositories
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        void Delete(Slider slider);
    }
}
