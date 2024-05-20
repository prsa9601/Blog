using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.UserAgg.Repository;
using Blog.Domain.UserAgg.Services;
using Common.Application;
using Common.Application.SecurityUtil;

namespace Blog.Application.User.Register
{
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;

        public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = Domain.UserAgg.User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), request.UserName, _domainService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
