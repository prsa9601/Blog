using Common.Application.Validation;
using FluentValidation;

namespace Blog.Application.User.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(f => f.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(6).WithMessage("کلمه عبور باید بشتر از 6 کارکتر باشد");


            RuleFor(r => r.UserName).NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("UserName"));
        }
    }
}
