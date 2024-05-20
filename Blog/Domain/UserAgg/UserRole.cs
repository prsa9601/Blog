using Common.Domain;

namespace Blog.Domain.UserAgg;

public class UserRole : BaseEntity
{
    public UserRole(long roleId)
    {
        RoleId = roleId;
    }
    public long UserId { get; set; }
    public long RoleId { get; set; }
    
}