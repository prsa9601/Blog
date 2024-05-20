using Common.Query;
using Common.Query.Filter;

namespace Blog.Query.User.DTOs;

public class UserDto : BaseDto
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string AvatarName { get; set; }
    public List<UserRoleDto> Roles { get; set; }
}
public class UserProfileDto : BaseDto
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string AvatarName { get; set; }
}
public class UserRoleDto
{
    public long RoleId { get; set; }
    public string RoleTitle { get; set; }
}


public class UserFilterData : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string AvatarName { get; set; }
}

public class UserFilterParams:BaseFilterParam
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public long? Id { get; set; }
}
public class UserFilterResult : BaseFilter<UserFilterData,UserFilterParams>
{

}