

using Blog.Query.Role.DTOs;

namespace Blog.Query.Role
{ 
    public static class RoleMapper
    {
        public static RoleFilterData MapListData(this Domain.RoleAgg.Role role)
        {
            return new RoleFilterData()
            {
                Title = role.Title,
                permissions = role.Permissions.Select(s => s.Permission).ToList(),
                Id = role.Id,
                CreationDate = role.CreationDate
            };
        }
    }
}
