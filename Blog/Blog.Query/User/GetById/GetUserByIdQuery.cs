 using Blog.Query.User.DTOs;
using Common.Query;

namespace Blog.Query.User.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }

    public long UserId { get; private set; }
}