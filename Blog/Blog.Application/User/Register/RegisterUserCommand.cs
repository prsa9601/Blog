using Common.Application;
using Common.Domain.ValueObjects;

namespace Blog.Application.User.Register
{
    public class RegisterUserCommand : IBaseCommand
    {
        public RegisterUserCommand(PhoneNumber phoneNumber, string password, string userName)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            UserName = userName;
        }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
    }
}
