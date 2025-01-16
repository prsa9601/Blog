using Blog.Application.Category.Delete;
using Blog.Domain.CategoryAgg.Repository;
using Common.Application;

public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.DeleteCategory(request.categoryId);
        if (result)
        {
            await _repository.Save();
            return OperationResult.Success();
        }

        return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
    }
}
