using Common.Application;
using Common.Domain.ValueObjects;

namespace Blog.Application.Category.Create
{
    public record CreateCategoryCommand(string Title, string Slug, SeoData SeoData)
         : IBaseCommand<long>;
}
