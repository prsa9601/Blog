using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Blog.Application.Product.AddImage
{
    public class AddImageProductCommandValidator : AbstractValidator<AddImageProductCommand>
    {
        public AddImageProductCommandValidator()
        {
            RuleFor(b => b.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(b => b.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }
}