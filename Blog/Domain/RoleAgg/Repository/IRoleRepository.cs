using Common.Domain.Repository;

namespace Blog.Domain.RoleAgg.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<bool> DeleteRole(long roleId);
    }
}
