using Common.Application;

namespace Blog.Application.Users.DeleteAddress;

public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;