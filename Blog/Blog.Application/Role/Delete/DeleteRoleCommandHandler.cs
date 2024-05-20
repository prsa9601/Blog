using Blog.Domain.RoleAgg.Repository;
using Common.Application;

namespace Blog.Application.Role.Delete
{
    public class DeleteRoleCommandHandler : IBaseCommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _repository;
        public DeleteRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteRole(request.roleId);
            if (!result)
                return OperationResult.Error();
            return OperationResult.Success();
        }
    }
}
