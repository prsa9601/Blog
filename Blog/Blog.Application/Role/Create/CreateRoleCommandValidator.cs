
using Common.Application.Validation;
using FluentValidation;

namespace Blog.Application.Role.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(r => r.Title).NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("Title"));
        }
    }
}
