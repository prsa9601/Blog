using Blog.Domain.RoleAgg.Enums;
using Common.Query;

namespace Blog.Query.Role.DTOs
{
    public class RoleFilterData : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> permissions { get; set; }
    }
}
