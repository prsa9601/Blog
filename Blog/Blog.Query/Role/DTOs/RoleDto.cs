using Blog.Domain.RoleAgg.Enums;
using Common.Query;

namespace Blog.Query.Role.DTOs
{
    public class RoleDto : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
