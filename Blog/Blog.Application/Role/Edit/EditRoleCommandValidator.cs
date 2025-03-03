﻿
using Common.Application.Validation;
using FluentValidation;

namespace Blog.Application.Role.Edit
{
    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.Title).NotEmpty().NotNull()
                .WithMessage(ValidationMessages.required("Title"));

        }
    }
}
