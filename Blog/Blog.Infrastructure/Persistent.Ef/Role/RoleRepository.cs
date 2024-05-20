using Blog.Domain.RoleAgg.Repository;
using Blog.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistent.Ef.Role
{
    public class RoleRepository : BaseRepository<Domain.RoleAgg.Role> , IRoleRepository
    {
        public RoleRepository(BlogContext context) : base(context)
        {
        }

        public async Task<bool> DeleteRole(long roleId)
        {
            var role = await Context.Roles.FirstOrDefaultAsync(i => i.Id == roleId);
            if (role == null)
                return false;
            Context.Roles.Remove(role);
            await Context.SaveChangesAsync();
            return true;
        }
    }                                                                    
}
