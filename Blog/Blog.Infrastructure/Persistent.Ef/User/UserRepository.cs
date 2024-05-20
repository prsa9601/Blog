using Blog.Domain.UserAgg.Repository;
using Blog.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistent.Ef.User
{
    public class UserRepository : BaseRepository<Domain.UserAgg.User>,  IUserRepository
    {
        public UserRepository(BlogContext context) : base(context)
        {
        }

        public async Task<bool> Delete(long id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user == null)
                return false;
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
