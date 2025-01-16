using Blog.Application.Category.AddChild;
using Blog.Application.Category.Create;
using Blog.Application.Category.Delete;
using Blog.Application.Category.Edit;
using Blog.Query.Category.DTOs;
using Common.Application;

namespace Blog.Presentation.Facade.Category
{
    public interface ICategoryFacade
    {

        Task<OperationResult<long>> CreateCategory(CreateCategoryCommand command);
        Task<OperationResult> EditCategory(EditCategoryCommand command);
        Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
        Task<OperationResult> DeleteCategory(DeleteCategoryCommand command);


        Task<CategoryDto?> GetCategoryById(long id);
        Task<List<CategoryDto?>> GetCategories();
        Task<List<ChildCategoryDto?>> GetByParentId(long parentId);
    }
}
