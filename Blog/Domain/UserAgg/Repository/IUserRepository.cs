using Common.Domain.Repository;

namespace Blog.Domain.UserAgg.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> Delete(long id);
    }
}
