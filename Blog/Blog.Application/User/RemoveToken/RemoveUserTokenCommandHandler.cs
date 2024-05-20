using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.UserAgg.Repository;
using Common.Application;

namespace Blog.Application.User.RemoveToken
{
    public class RemoveUserTokenCommandHandler : IBaseCommandHandler<RemoveUserTokenCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<string>> Handle(RemoveUserTokenCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult<string>.NotFound();

            var token = user.RemoveToken(request.TokenId);
            await _userRepository.Save();
            return OperationResult<string>.Success(token);
        }
    }
}
