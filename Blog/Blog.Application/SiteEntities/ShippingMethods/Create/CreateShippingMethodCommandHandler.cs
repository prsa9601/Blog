using Blog.Domain.SiteEntities;
using Blog.Domain.SiteEntities.Repositories;
using Common.Application;

namespace Blog.Application.SiteEntities.ShippingMethods.Create;

internal class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;

    public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new ShippingMethod(request.Cost, request.Title));
        await _repository.Save();
        return OperationResult.Success();
    }
}