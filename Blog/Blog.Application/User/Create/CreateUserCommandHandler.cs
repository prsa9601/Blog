using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.UserAgg.Repository;
using Blog.Domain.UserAgg.Services;
using Common.Application;
using Common.Application.SecurityUtil;

namespace Blog.Application.User.Create
{
    public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _userDomainService;

        public CreateUserCommandHandler(IUserRepository repository, IUserDomainService userDomainService)
        {
            _repository = repository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new Domain.UserAgg.User(request.Name, request.Family, Sha256Hasher.Hash(request.Password),
                request.PhoneNumber
                , request.UserName, _userDomainService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
