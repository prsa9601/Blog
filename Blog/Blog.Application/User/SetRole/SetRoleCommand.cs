using Blog.Domain.RoleAgg.Repository;
using Blog.Domain.UserAgg.Repository;
using Common.Application;

namespace Blog.Application.User.SetRole
{
    public record class SetRoleCommand(long userId, List<long> rolesId) : IBaseCommand;
   
    public class SetRoleCommandHandler : IBaseCommandHandler<SetRoleCommand>
    {
        private readonly IRoleRepository _repository;
        private readonly IUserRepository _userRepository;

        public SetRoleCommandHandler(IRoleRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(SetRoleCommand request, CancellationToken cancellationToken)
        {
           

            //var role = await _repository.GetTracking(request.roleId);
            //if (role == null) 
            //    return OperationResult.NotFound();
            
            var user = await _userRepository.GetTracking(request.userId);
            user.SetUserRoles(request.rolesId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
