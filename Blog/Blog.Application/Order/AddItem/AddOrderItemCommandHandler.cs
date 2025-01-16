using Blog.Application.Order.AddItem;
using Blog.Domain.OrderAgg.Repository;
using Blog.Domain.ProductAgg.Repository;
using Common.Application;

namespace Blog.Application.Order.AddItem;

public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _repository;
    private readonly IProductRepository _productRepository;

    public AddOrderItemCommandHandler(IOrderRepository repository, IProductRepository productRepository)
    {
        _repository = repository;
        _productRepository = productRepository;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _productRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();

        if (inventory.Count < request.Count)
            return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
        {
            order = new Domain.OrderAgg.Order(request.UserId);
            order.AddItem(new Domain.OrderAgg.OrderItem(request.InventoryId, request.Count, inventory.Price));
            _repository.Add(order);
        }
        else
        {
            order.AddItem(new Domain.OrderAgg.OrderItem(request.InventoryId, request.Count, inventory.Price));
        }


        if (ItemCountBeggerThanInventoryCount(inventory, order))
            return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

        await _repository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBeggerThanInventoryCount(Domain.ProductAgg.Repository.IProductRepository.InventoryResult inventory, Domain.OrderAgg.Order order)
    {
        var orderItem = order.Items.First(f => f.InventoryId == inventory.Id);
        if (orderItem.Count > inventory.Count)
            return true;

        return false;
    }
}