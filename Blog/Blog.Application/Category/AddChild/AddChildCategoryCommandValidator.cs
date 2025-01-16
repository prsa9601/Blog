using Common.Application.Validation;
using FluentValidation;

namespace Blog.Application.Category.AddChild
{
    public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
              .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
              .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}